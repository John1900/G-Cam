using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Utility
{
	public static class NextHigher
	{
		public static float get(double value)
		{
			double temp = Math.Ceiling(value * 100);
			float power = 0;

			while (temp > 10)
			{
				temp = Math.Ceiling(temp / 10.0);
				power++;
			}

			return (float)(temp * Math.Pow(10, power) / 100);
		}
	}
}