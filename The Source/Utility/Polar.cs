using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Encapsulates a pair of doubles for polar or cartisian coordinate 

namespace G_Cam.Utility
{
    public class Polar
    {
        public double r { get; set; }         // Radius
        public double a { get; set; }         // Polar angle in RADIANS
		public double aDeg { get { return Change.toDegrees(a); } }         // Polar angle in Degrees

        public Polar()
        {
            this.r = 0;
            this.a = 0;
        }

        public Polar(double r, double a)
        {
            this.r = r;
            this.a = a;
        }
    }
}