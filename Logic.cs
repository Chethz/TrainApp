using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cheth
{
    public class Logic
    {
        //to store vertise and edges to required vertices
        private RailNetwork _RailNetwork = new RailNetwork();

        //adding number of cities to the list depending on user input
//        public void createNetwork(string noOfCities)
//        {
//            try {
//                bool isNumber = int.TryParse(noOfCities, out int n);
//
//                if (!isNumber)
//                    throw new Exception(ErrorMessages.InvalidNoOfCitiest);
//                _RailNetwork.addTownsToRailMap(n);
//            } catch (Exception ex)
//            {
//                throw ex;
//            }
//            
//        }

        //add destination and distance to the list of town
//        public void addDestinations(char source, char destination, int distance)
//        {
//            Town sourceTown = null;
//            Town destinationTown = null;
//            try
//            {
//                foreach (var town in _RailNetwork.RailMapList)
//                {
//                    if (source == town.Name)
//                    {
//                        sourceTown = town;
//                    }
//
//                    if (destination == town.Name)
//                    {
//                        destinationTown = town;
//                    }
//                }
//                _RailNetwork.AddEdge(sourceTown.Name, destinationTown, distance);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


        //Split user inputs by , and break them in to sores city, destination city and distance as per user input
        //pass values to AddEdge function
        public void ProcessRoutes(string routes)
        {
            try
            {
                string[] routeArray = routes.Split(',');

                foreach (var route in routeArray)
                {
                    _RailNetwork.CreateEdge(route);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        //Calculate distance of given routes
        public int DistanceOfRoutes(string journey)
        {
            try
            {
                int distance = 0;
                Town sourseTown = null;
                char destinationTown = '\0';
                char[] travelRoute = journey.ToCharArray();


                for (int i = 0; i < travelRoute.Length-2; i++)
                {
                    //check for char is a character
                    if(!Char.IsLetter(travelRoute[i]))
                        throw new Exception(ErrorMessages.InvalidInput);
                    
                    sourseTown = _RailNetwork.GetTown(travelRoute[i]);
                    destinationTown = travelRoute[i + 1];
                    //if (travelRoute[i+1] >= travelRoute.Length)
                    //{
                    //    destinationTown = travelRoute[i + 1];
                    //}

                    if (sourseTown != null && sourseTown.IsRouteExists(destinationTown))
                    {
                        distance += sourseTown.Distance(destinationTown);
                    }
                    else
                    {
                        throw new Exception(ErrorMessages.NoRouteFound);
                    }
                }

                return distance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //check for empty town and throw exception
        //check for existing route for destination town
        //use foreach loop to input next destination city in to the recursive function
        public int NumberOfTripsWithMaximumStops(char sourceTown, char destinationTown, int maxStops, int totalStops,
            int totalTrips)
        {
            if (totalStops <= maxStops)
            {
                Town tempTown = _RailNetwork.GetTown(sourceTown);
                if (tempTown == null)
                    throw new Exception(ErrorMessages.NoRouteFound);

                if (tempTown.IsRouteExists(destinationTown))
                {
                    return totalTrips + 1;
                }
                else
                {
                    foreach (var destinations in tempTown.DestinationList)
                    {
                        totalTrips = NumberOfTripsWithMaximumStops(destinations.DestinationTown.Name, destinationTown,
                            maxStops, totalStops + 1, totalTrips);
                    }
                }
            }

            return totalTrips;
        }

        //call NumberOfTripsWithMaximumStops funtion to check available routes from C to C
        public int StartingAndEndCwithThreeStops()
        {
            try
            {
               int trips = NumberOfTripsWithMaximumStops('C', 'C', 3, 0, 0);
               return trips;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //call NumberOfTripsWithMaximumStops funtion to check available routes from A to C
        public int StartingAtAAndEndCwithFourStops()
        {
            try
            {
                int trips = NumberOfTripsWithMaximumStops('A', 'C', 4, 0, 0);
                return trips;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Calculte shortes route
        //Check source town for null values
        //check for existing routes
        //update distance
        //if shortest distance grate it replace 
        //mark true for visited towns
        //
        public int ShortestRoute(char sourceTown, char destiantionT, int distance, int shortestDistance, List<char> visited)
        {   
            Town tempTown = _RailNetwork.GetTown(sourceTown);
            if (tempTown == null)
                throw new Exception(ErrorMessages.InvalidInput);
            if (tempTown.IsRouteExists(destiantionT))
            {
                distance += tempTown.Distance(destiantionT);
                shortestDistance = shortestDistance > distance || shortestDistance == 0 ? distance : shortestDistance;
                return shortestDistance;
            }
            else
            {
                foreach (Route route in tempTown.DestinationList.Where(town =>
                    !visited.Contains(town.DestinationTown.Name))) 
                {
                    //route.Visited = true;
                    visited.Add(sourceTown);
                    shortestDistance = ShortestRoute(route.DestinationTown.Name, destiantionT,
                        distance + route.Distance, shortestDistance, visited);
                }
            }

            return shortestDistance;
        }


        public int GetDifferentRoutes(char sourceTown, char destinationTown, int distance, int maxDistance, int routeCount)
        {
            var tempTown = _RailNetwork.GetTown(sourceTown);
            if (tempTown != null)
            {
                //distance = distance + city.Distance(destinationTown);
                var tempDistance = tempTown.Distance(destinationTown);
                if (distance + tempDistance >= maxDistance) return routeCount;
                if (tempTown.IsRouteExists(destinationTown))
                {
                    routeCount = routeCount + 1;
                }

                foreach (Route route in tempTown.DestinationList)
                {
                    routeCount = GetDifferentRoutes(route.DestinationTown.Name, destinationTown, distance + route.Distance, maxDistance, routeCount);
                }
            }
            return routeCount;
        }

        //calling ShortestRoute function
        public int ShortestRouteAtoC()
        {
            int shortestRoute = ShortestRoute('A', 'C', 0, 0, new List<char>());
            return shortestRoute;
        }

        //calling ShortestRoute function
        public int ShortestRouteBtoB()
        {
            int shortestRoute = ShortestRoute('B', 'B', 0, 0, new List<char>());
            return shortestRoute;
        }

        public int DifferentRoutesCtoCDistanceLessThanThirty()
        {
           int routes = GetDifferentRoutes('C', 'C', 0, 30, 0);
           return routes;
        }

    }
}
