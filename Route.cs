using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    class Route
    {
        private int _Distance;

        public Town DestinationTown { get; }

        public bool Visited { get; set; }
        public int Distance
        {
            get { return _Distance; }
        }

        public Route(Town destinationTown, int distance)
        {
            this.DestinationTown = destinationTown;
            this._Distance = distance;
        }
    }
}
