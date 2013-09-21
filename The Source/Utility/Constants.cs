using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Utility
{
	public static class Constants
	{
		public const int INTRODUCTION = 0;
		public const int GEOMETRY = 1;
		public const int MILL = 2;
		public const int GRIND = 3;
		public const int GCODE = 4;
		public const int BUILD = 5;

		//public const int SUMMARY = 5;
		
		public const String UNITS = "Units of measure";
		public const String DECIMALS = "Decimal places";
		public const String BASERADIUS = "Base radius";
		public const String FLANKRADIUS = "Flank radius";
		public const String LIFT = "Lobe lift";
		public const String ACTION = "<U>CAM</U> Duration degrees";
		public const String RPM = "RPM of CAM";
		public const String GPRECODE = "G80 G90 G40 G50 G49 G17 G92.1";
		public const String GPOSTCODE = "M30";
		public const String INCHES = "inches";
		public const String MM = "mm";


		public const String HEADERROR = "Errors on page.";
		//public const String  = "";

		public static double R90 { get { return Change.toRadians(90); }}
		public static double R180 { get { return Change.toRadians(180); }}
		public static double R360 { get { return Change.toRadians(360); }}
	
	}
}