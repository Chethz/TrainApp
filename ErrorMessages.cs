using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    public class ErrorMessages
    {
        private static string _InvalidInput = "ERROR : Please input valid source, destination and distance";

        public static string InvalidInput
        {
            get { return _InvalidInput; }
        }

        private static string _InvalidSourceOrDestination = "ERROR : Entered source or destination not valid";

        public static string InvalidSourceOrDestination
        {
            get { return _InvalidSourceOrDestination; }
        }

        private static string _DestinationCityExist = "ERROR : City already have an destination city";

        public static string DestinationCityExist
        {
            get { return _DestinationCityExist; }
        }

        private static string _InvalidNoOfCities = "ERROR : Please enter valid number number of cities";

        public static string InvalidNoOfCitiest
        {
            get { return _InvalidNoOfCities; }
        }

        private static string _InvalidDistanceOrTown = "ERROR : Please enter valid destination town or distance";

        public static string InvalidDistanceOrTown
        {
            get { return _InvalidDistanceOrTown; }
        }

        private static string _InvalidRoute = "ERROR : Please enter valid list of routes";

        public static string InvalidRoute
        {
            get { return _InvalidRoute; }
        }

        private static string _InvalidDistance = "ERROR : Please enter valid distance";

        public static string InvalidDistance
        {
            get { return _InvalidDistance; }
        }

        private static string _NoRouteFound = "ERROR : NO SUCH ROUTE FOUND";

        public static string NoRouteFound
        {
            get { return _NoRouteFound; }
        }

        private static string _TownNotFound = "ERROR : Invalid town name";
        public static string TownNotFound
        {
            get { return _TownNotFound; }
        }
    }
}
