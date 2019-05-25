using System;
using System.Text.RegularExpressions;

namespace Cheth
{
    public class View
    {
        private Logic logic = new Logic();
        public void mainMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\n------------------------------- Main Menu -------------------------------");
                Console.WriteLine("Enter 1 to create transport network");
                Console.WriteLine("Enter 2 to print distance of routes");
                Console.WriteLine("Enter 3 to print number of trips starting at C and ending at C with maximum of 3 stops");
                Console.WriteLine("Enter 4 to print number of trips starting at A and ending at C with exactly of 4 stops");
                Console.WriteLine("Enter 5 to print length of the shortest route from A to C");
                Console.WriteLine("Enter 6 to print length of the shortest route from B to B");
                Console.WriteLine("Enter 7 to print number of different routes from C to C with a distance of less than 30");
                Console.WriteLine("\n-------------------------------------------------------------------------");
                Console.WriteLine("Your option : ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CreateTransportNetwork();
                        break;
                    case "2":
                        getDistance();
                        break;
                    case "3":
                        startingAtCEndC();
                        break;
                    case "4":
                        StartingAtAEndC();
                        break;
                    case "5":
                        getShortestPathAtoC();
                        break;
                    case "6":
                        getShortestPathBtoB();
                        break;
                    case "7":
                        differentRoutesCtoC();
                        break;
                    default:
                        Console.WriteLine("Thank you for using our system. Bye!");
                        end = true;
                        break;
                }

            }
        }

        private void CreateTransportNetwork()
        {
            Console.WriteLine("Enter routes separated by comma ex: AB5, BC4...");
            string routesTemp = Console.ReadLine().Trim();
            string routes = Regex.Replace(routesTemp, @"\s+", "");
            Console.WriteLine("Press S if you want to submit");
            Console.WriteLine("Press any other key if you want to cancel");
            Console.WriteLine("Your option");

            string option = Console.ReadLine().ToUpper();
            if (option == "S")
            {
                try
                {
                    logic.ProcessRoutes(routes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getDistance()
        {
            Console.WriteLine("Enter routes to get distance Ex: A-B-C");
            string journyTemp = Console.ReadLine().ToUpper();
            string journy = Regex.Replace(journyTemp, @"[\s-]+", "");
            Console.WriteLine("Press S if you want to submit");
            Console.WriteLine("Press any other key if you want to cancel");
            Console.WriteLine("Your option");

            string option = Console.ReadLine().ToUpper().Trim();
            if (option == "S")
            {
                try
                {
                    Console.WriteLine("Distance of route {0} : {1}", journy, logic.DistanceOfRoutes(journy));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Press any key to go back to main menu");
                Console.WriteLine("Press S to re enter different route");
                string repete = Console.ReadLine().ToUpper();
                if (repete == "S")
                {
                    getDistance();
                }
                Console.ReadKey();
            }
        }

        private void startingAtCEndC()
        {
            Console.WriteLine("The number of trips starting at C and ending at C with a maximum of 3 stops");
            try
            {
                Console.WriteLine("Number of trips : {0} ", logic.StartingAndEndCwithThreeStops());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }

        private void StartingAtAEndC()
        {
            Console.WriteLine("The number of trips starting at A and ending at C with a maximum of 4 stops");
            try
            {
                Console.WriteLine("Number of trips : {0} ", logic.StartingAndEndCwithThreeStops());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }

        private void getShortestPathAtoC()
        {
            Console.WriteLine("The length of the shortest path from A to C");
            try
            {
                Console.WriteLine("Distance of the shortest path : {0}", logic.ShortestRouteAtoC());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }

        private void getShortestPathBtoB()
        {
            Console.WriteLine("The length of the shortest path from B to B");
            try
            {
                Console.WriteLine("Distance of the shortest path : {0}", logic.ShortestRouteBtoB());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }

        private void differentRoutesCtoC()
        {
            Console.WriteLine("Number of different routes from C to C with distance less than 30");
            try
            {
                Console.WriteLine("Number of different routes : {0}",logic.DifferentRoutesCtoCDistanceLessThanThirty());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }
    }
}
