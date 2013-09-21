using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Encapsulates a pair of doubles for polar or cartisian coordinate 

namespace G_Cam.Utility
{
    public class Coord
    {
        public double x { get; set; }         
        public double y { get; set; }         
	

        public Coord()
        {
            this.x = 0;
            this.y = 0;
        }

		public Coord(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}