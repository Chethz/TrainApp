using System;
using System.Collections.Generic;
using System.Linq;

namespace Cheth
{
    public class Town
    {
        private char _Name;

        public char Name
        {
            get { return _Name; }
        }

        //list of destinations
        private List<Route> _DestinationList = new List<Route>();

        public List<Route> DestinationList
        {
            get { return _DestinationList; }
        }

        //Constructor
        public Town(char name)
        {
            _Name = name;
        }

        //convert string to char to store in the _Name variable
        //Throw exception if input isn't in valid
        public Town(string name)
        {
            if(!char.TryParse(name, out _Name))
                throw new Exception(ErrorMessages.InvalidInput);
        }

        //Add routes to _destinationList
        //check for null values for town and negative values for distance
        //check for existing route under same name
        public void AddRoute(Town town, int distance)
        {
            if(town == null || distance <= 0)
                throw new Exception(ErrorMessages.InvalidDistanceOrTown);
            if(IsRouteExists(town.Name))
                throw new Exception(ErrorMessages.DestinationCityExist);
            var route = new Route(town, distance);
            _DestinationList.Add(route);
        }

        //check for existing routes
        //use linq to filter data
        public bool IsRouteExists(char destinationTown)
        {
            return DestinationList.Where(destination => destination.DestinationTown.Name == destinationTown).FirstOrDefault() != null;
        }

        //get distance for the routes
        //use linq to filter data
        public int Distance(char destinationTown)
        {
            return DestinationList.Where(destinationT => destinationT.DestinationTown.Name == destinationTown).Select(toDistance => toDistance.Distance)
                .FirstOrDefault();
        }
    }
}
