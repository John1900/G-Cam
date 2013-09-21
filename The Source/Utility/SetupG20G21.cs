using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Utility
{
	public static class SetupG20G21
	{
		public static void set()
		{
			String gUnits = Data.sPreCode;
			gUnits = gUnits.Replace(" G20", "");
			gUnits = gUnits.Replace(" G21", "");
			gUnits = gUnits.Replace("G20", "");
			gUnits = gUnits.Replace("G21", "");

			if (Data.sUnits.Equals(Constants.INCHES)) { gUnits += " G20"; }
			else { gUnits += " G21"; }

			Data.sPreCode = gUnits;
		}
	}
}