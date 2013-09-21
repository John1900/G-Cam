using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Utility
{
	static class Change
	{
		// Convert degrees to radians
        public static double toRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }

        // Convert radians to degrees
		public static double toDegrees(double radians)
		{
			return radians * 180 / Math.PI;
		}

		// Convert to string with correct decimal places
		public static String toString(double value)
		{
			String mask = "{0:N" + Data.iDecimals.ToString() + "}";
			return string.Format(mask, value); 
		}
	}
}