//	
//	Stores and retrieves string data to session state
//
//	Used for any string data plus user entries where the data is saved exactly as entered.  
//	On returning to the entry screen user will see what they entered
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;


namespace G_Cam.Utility
{
    static class Data
    {
		const String UNITS = "a";
		const String NAME = "b";
		const String DESCRIPTION = "c";
		const String BASERADIUS = "d";
		const String LIFT = "e";
		const String FLANKRADIUS = "f";
		const String ACTION = "g";
		const String RPM = "h";
		const String ROTARYAXIS = "i";
		const String OFFSETAXIS = "j";
		const String PRECISION = "k";
		const String DECIMALS = "l";
		const String WHEELDIAMETER = "m";
		const String NOSERADIUS = "n";
		const String NOSEANGLE = "o";					// Angle of top transition at nose centre
		const String TRANSITIONTOPLIFTERR = "p";		//Polar is saved as radius and angle
		const String TRANSITIONTOPLIFTERA = "q";		//Polar is saved as radius and angle
		const String TRANSITIONTOPGRINDERR = "0";		//Polar is saved as radius and angle
		const String TRANSITIONTOPGRINDERA = "6";		//Polar is saved as radius and angle
		const String TRANSITIONBOTR = "r";
		const String TRANSITIONBOTA = "s";
		const String FLANKORIGINX = "t";				//Coord is saved as x and y
		const String FLANKORIGINY = "u";
		const String FLANKANGLE = "v";					// Angle of both transitions at flank centre
		const String ROTARYDIRECTION = "w";
		const String OFFSETDIRECTION = "x";
		const String BLANKDIAMETER = "y";
		const String MAXPASS = "z";
		const String FINISHPASS = "2";
		const String PRECODE = "3";
		const String POSTCODE = "4";
		const String FINISHDIRECTION = "5";
		const String ACTUALBASEDIAMETER = "7";
		const String GCODE = "8";
        const String STEP = "9";

		const String PENDINGPANEL = "!";
		const String BACKLASH = "@";
		const String SAFE = "#";

		const String WARNING = "$";
		const String ROTARYFEED = "^";
		const String POSITIONALFEED = "&";
		const String OUTSTANDINGERRORS = "*";
		const String RESTORE = "(";
		const String SAVEFILENAME = ")";
		const String ALTERNATEPATH = "_";

		const String CROSSFEEDAXIS = "1";
		const String CROSSFEEDMAX = "%";
		const String CROSSFEEDSTEP = "+";

		const String LIFTERDIAMETER = "=";

		const String GRAPHTYPE = "[";

		
		// Provided by user - basic strings

		public static String sUnits { set { putString(UNITS, value); } get { return getString(UNITS, Constants.INCHES); } }
		public static String sName { set { putString(NAME, value); } get { return getString(NAME); } }
		public static String sDescription { set { putString(DESCRIPTION, value); } get { return getString(DESCRIPTION); } }
		public static String sLift { set { putString(LIFT, value); } get { return getString(LIFT); } }
		public static String sBaseRadius { set { putString(BASERADIUS, value); } get { return getString(BASERADIUS); } }
		public static String sFlankRadius { set { putString(FLANKRADIUS, value); } get { return getString(FLANKRADIUS); } }
		public static String sAction { set { putString(ACTION, value); } get { return getString(ACTION); } }
		public static String sRpm { set { putString(RPM, value); } get { return getString(RPM); } }
		public static String sRotaryAxis { set { putString(ROTARYAXIS, value); } get { return getString(ROTARYAXIS); } }
		public static String sOffsetAxis { set { putString(OFFSETAXIS, value); } get { return getString(OFFSETAXIS); } }
		public static String sRotaryDirection { set { putString(ROTARYDIRECTION, value); } get { return getString(ROTARYDIRECTION, "S"); } }
		public static String sOffsetDirection { set { putString(OFFSETDIRECTION, value); } get { return getString(OFFSETDIRECTION, "I"); } }
		public static String sFinishDirection { set { putString(FINISHDIRECTION, value); } get { return getString(FINISHDIRECTION, "O"); } }
		public static String sPrecision { set { putString(PRECISION, value); } get { return getString(PRECISION); } }
		public static String sDecimals { set { putString(DECIMALS, value); } get { return getString(DECIMALS, "4"); } }
		public static String sWheelDiameter { set { putString(WHEELDIAMETER, value); } get { return getString(WHEELDIAMETER); } }
		public static String sBlankDiameter { set { putString(BLANKDIAMETER, value); } get { return getString(BLANKDIAMETER); } }
		public static String sMaxPass { set { putString(MAXPASS, value); } get { return getString(MAXPASS); } }
		public static String sFinishPass { set { putString(FINISHPASS, value); } get { return getString(FINISHPASS); } }
		public static String sPreCode { set { putString(PRECODE, value); } get { return getString(PRECODE, Constants.GPRECODE); } }
		public static String sPostCode { set { putString(POSTCODE, value); } get { return getString(POSTCODE, Constants.GPOSTCODE); } }
        public static String sActualBaseDiameter { set { putString(ACTUALBASEDIAMETER, value); } get { return getString(ACTUALBASEDIAMETER); } }
		public static String sGCode { set { putString(GCODE, value); } get { return getString(GCODE); } }
        public static String sStep { set { putString(STEP, value); } get { return getString(STEP); } }
		public static String sBacklash { set { putString(BACKLASH, value); } get { return getString(BACKLASH); } }
		public static String sSafe { set { putString(SAFE, value); } get { return getString(SAFE); } }
		public static String sWarning { set { putString(WARNING, value); } get { return getString(WARNING); } }
		public static String sPositionalFeed { set { putString(POSITIONALFEED, value); } get { return getString(POSITIONALFEED); } }
		public static String sRotaryFeed { set { putString(ROTARYFEED, value); } get { return getString(ROTARYFEED); } }
		public static String sCrossAxis { set { putString(CROSSFEEDAXIS, value); } get { return getString(CROSSFEEDAXIS); } }
		public static String sCrossAxisEnd { set { putString(CROSSFEEDMAX, value); } get { return getString(CROSSFEEDMAX); } }
		public static String sCrossAxisStep { set { putString(CROSSFEEDSTEP, value); } get { return getString(CROSSFEEDSTEP); } }
		public static String sSaveFilename { set { putString(SAVEFILENAME, value); } get { return getString(SAVEFILENAME, ""); } }
		public static String sGraphType { set { putString(GRAPHTYPE, value); } get { return getString(GRAPHTYPE, ""); } }
		
		public static void setOutstandingError(int index, bool valid)
		{
			StringBuilder sb = new StringBuilder(getString(OUTSTANDINGERRORS, "          "));
			char v = 'Y';
			if (!valid) { v = 'X'; }
			sb[index] = v;
			putString(OUTSTANDINGERRORS, sb.ToString());
		}

		public static bool getOutstandingError(int index)
		{
			StringBuilder sb = new StringBuilder(getString(OUTSTANDINGERRORS, "          "));
			return (sb[index] == 'Y');
		}


		public static bool bRestore { set { putBool(RESTORE, value); } get { return getBool(RESTORE); } }
		public static bool bAlternatePath { set { putBool(ALTERNATEPATH, value); } get { return getBool(ALTERNATEPATH); } }

		// Companion doubles and integers for the user entered strings.  Don't need this for strings

		public static double dBaseRadius { set { putDouble(BASERADIUS, value); } get { return getDouble(BASERADIUS); } }
		public static double dLift { set { putDouble(LIFT, value); } get { return getDouble(LIFT); } }
		public static double dFlankRadius { set { putDouble(FLANKRADIUS, value); } get { return getDouble(FLANKRADIUS); } }
		public static double dAction { set { putDouble(ACTION, value); } get { return getDouble(ACTION); } }
		public static double dPrecision { set { putDouble(PRECISION, value); } get { return getDouble(PRECISION); } }
		public static double dWheelDiameter { set { putDouble(WHEELDIAMETER, value); } get { return getDouble(WHEELDIAMETER); } }
		public static double dBlankDiameter { set { putDouble(BLANKDIAMETER, value); } get { return getDouble(BLANKDIAMETER); } }
		public static double dMaxPass { set { putDouble(MAXPASS, value); } get { return getDouble(MAXPASS); } }
		public static double dFinishPass { set { putDouble(FINISHPASS, value); } get { return getDouble(FINISHPASS); } }
        public static double dActualBaseDiameter { set { putDouble(ACTUALBASEDIAMETER, value); } get { return getDouble(ACTUALBASEDIAMETER); } }
        public static double dStep { set { putDouble(STEP, value); } get { return getDouble(STEP); } }
		public static double dBacklash { set { putDouble(BACKLASH, value); } get { return getDouble(BACKLASH); } }
		public static double dSafe { set { putDouble(SAFE, value); } get { return getDouble(SAFE); } }
		public static double dRotaryFeed { set { putDouble(ROTARYFEED, value); } get { return getDouble(ROTARYFEED); } }
		public static double dPositionalFeed { set { putDouble(POSITIONALFEED, value); } get { return getDouble(POSITIONALFEED); } }
		public static double dCrossFeedEnd { set { putDouble(CROSSFEEDMAX, value); } get { return getDouble(CROSSFEEDMAX); } }
		public static double dCrossFeedStep { set { putDouble(CROSSFEEDSTEP, value); } get { return getDouble(CROSSFEEDSTEP); } }
		public static double dLifterDiameter { set { putDouble(LIFTERDIAMETER, value); } get { return getDouble(LIFTERDIAMETER); } }
		
		public static int iRpm { set { putInteger(RPM, value); } get { return getInteger(RPM); } }
		public static int iDecimals { set { putInteger(DECIMALS, value); } get { return getInteger(DECIMALS); } }
		public static int iPendingPanel { set { putInteger(PENDINGPANEL, value); } get { return getInteger(PENDINGPANEL); } }

		// Provided by user - integers with checking, saved to both string and int if valid numeric
 
		public static Boolean setPrecisionIfInteger(String value) { return setIfInteger(PRECISION, value); }
		public static Boolean setRpmIfInteger( String value) {	return setIfInteger(RPM, value); }
		public static Boolean setDecimalsIfInteger ( String value) { return setIfInteger(DECIMALS, value); }


		// Provided by user - doubles with checking, saved to both string and double if valid numeric

		public static Boolean setBaseRadiusIfDouble(String value) {	return setIfDouble(BASERADIUS, value); }
		public static Boolean setLiftIfDouble(String value) { return setIfDouble(LIFT, value); }
		public static Boolean setFlankRadiusIfDouble(String value) { return setIfDouble(FLANKRADIUS, value); }
		public static Boolean setActionIfDouble(String value) { return setIfDouble(ACTION, value); }
		public static Boolean setWheelDiameterIfDouble(String value) { return setIfDouble(WHEELDIAMETER, value); }
		public static Boolean setBlankDiameterIfDouble(String value) { return setIfDouble(BLANKDIAMETER, value); }
		public static Boolean setMaxPassIfDouble(String value) { return setIfDouble(MAXPASS, value); }
		public static Boolean setFinishPassIfDouble(String value) { return setIfDouble(FINISHPASS, value); }
		public static Boolean setPrecisionIfDouble(String value) { return setIfDouble(PRECISION, value); }
        public static Boolean setActualBaseDiameterIfDouble(String value) { return setIfDouble(ACTUALBASEDIAMETER, value); }
        public static Boolean setStepIfDouble(String value) { return setIfDouble(STEP, value); }
		public static Boolean setBacklashIfDouble(String value) { return setIfDouble(BACKLASH, value); }
		public static Boolean setSafeIfDouble(String value) { return setIfDouble(SAFE, value); }
		public static Boolean setRotaryFeedIfDouble(String value) { return setIfDouble(ROTARYFEED, value); }
		public static Boolean setPositionalFeedIfDouble(String value) { return setIfDouble(POSITIONALFEED, value); }
		public static Boolean setCrossAxisEndIfDouble(String value) { return setIfDouble(CROSSFEEDMAX, value); }
		public static Boolean setCrossAxisStepIfDouble(String value) { return setIfDouble(CROSSFEEDSTEP, value); }

		// Calculated

		public static double dNoseRadius { set { putDouble(NOSERADIUS, value); } get { return getDouble(NOSERADIUS); } }

		// Angle between the flank radii to lower and upper transitions
		public static double dFlankAngle { set { putDouble(FLANKANGLE, value); } get { return getDouble(FLANKANGLE); } }

		// Transition point between flank arc and nose
		public static Polar pLifterTransitionTop
		{
			set { putPolar(TRANSITIONTOPLIFTERR, TRANSITIONTOPLIFTERA, value); }
			get { return getPolar(TRANSITIONTOPLIFTERR, TRANSITIONTOPLIFTERA); } 
		}

		public static Coord cTransitionTopGrinder
		{
			get { return new Coord(getDouble(TRANSITIONTOPGRINDERR) * Math.Sin(getDouble(TRANSITIONTOPGRINDERA)), 
						          getDouble(TRANSITIONTOPGRINDERR) * Math.Cos(getDouble(TRANSITIONTOPGRINDERA))); }
		}

		// Transition point between flank arc and base
		public static Polar pTransitionBot
		{
			set { putPolar(TRANSITIONBOTR, TRANSITIONBOTA, value); }
			get { return getPolar(TRANSITIONBOTR, TRANSITIONBOTA); }
		}
		
		public static Coord cTransitionBot
		{
			get { return new Coord(getDouble(TRANSITIONBOTR) * Math.Sin(getDouble(TRANSITIONBOTA)), 
						           getDouble(TRANSITIONBOTR) * Math.Cos(getDouble(TRANSITIONBOTA))); }
		}

		public static Polar pTransitionTopGrinder
		{
			set { putPolar(TRANSITIONTOPGRINDERR, TRANSITIONTOPGRINDERA, value); }
			get { return getPolar(TRANSITIONTOPGRINDERR, TRANSITIONTOPGRINDERA); }
		}

		public static Coord cTransitionTopLifter
		{
			get
			{
				return new Coord(getDouble(TRANSITIONTOPLIFTERR) * Math.Sin(getDouble(TRANSITIONTOPLIFTERA)),
							  getDouble(TRANSITIONTOPLIFTERR) * Math.Cos(getDouble(TRANSITIONTOPLIFTERA)));
			}
		}


		// Centre of the flank circle
		public static Coord cFlankOrigin
		{
			set { putCoord(FLANKORIGINX, FLANKORIGINY, value); }
			get { return getCoord(FLANKORIGINX, FLANKORIGINY); }
		}
		

		private static void putString(String key, String value)
		{
			HttpContext.Current.Session["S" + key] = value;
		}
	
		private static String getString(String key)
		{
			return getString(key, "");
		}

		private static String getString(String key, String def)
		{
			String s = "";
			try
			{
				s = HttpContext.Current.Session["S" + key].ToString();
			}
			catch (Exception e)
			{
				e = e;
				s = def;
			}
			return s;
		}

		private static void putInteger(String key, int value)
		{
			HttpContext.Current.Session["I" + key] = value.ToString();
		}

		private static int getInteger(String key)
		{
			int i = 0;
			try
			{
				i = Convert.ToInt32(HttpContext.Current.Session["I" + key].ToString());
			}
			catch (Exception e)
			{
				e = e;
				i = 0;
			}
			return i;
		}

		private static void putDouble(String key, double value)
		{
			HttpContext.Current.Session["D" + key] = value.ToString();
		}

		private static double getDouble(String key)
		{
			double d = 0;
			try
			{
				d = Convert.ToDouble(HttpContext.Current.Session["D" + key].ToString());
			}
			catch (Exception e)
			{
				e = e;
			}
			return d;
		}

		private static void putBool(String key, Boolean value)
		{
			String txt = "N";
			if(value) { txt = "Y"; }
			HttpContext.Current.Session["B" + key] = txt;
		}

		private static Boolean getBool(String key)
		{
			bool b = false;
			try
			{
				if (HttpContext.Current.Session["B" + key].ToString().Equals("Y")) { b = true; };
			}
			catch (Exception e)
			{
				e = e;
				b = false;
			}
			return b;
		}


		private static void putPolar(String keyR, String keyA, Polar value)
		{
			putDouble(keyR, value.r);
			putDouble(keyA, value.a);
		}

		private static Polar getPolar(String keyR, String keyA)
		{
			return new Polar(getDouble(keyR), getDouble(keyA));
		}

		private static void putCoord(String keyX, String keyY, Coord value)
		{
			putDouble(keyX, value.x);
			putDouble(keyY, value.y);
		}

		private static Coord getCoord(String keyX, String keyY)
		{
			return new Coord(getDouble(keyX), getDouble(keyY));
		}


		public static Boolean setIfInteger(String key, String value)
		{
			int i = 0;
			Boolean state = false;
			putInteger(key, 0);
			if (int.TryParse(value.Trim(), out i))
			{
				putInteger(key, i);
				state = true;
			}
			return state;
		}

		public static Boolean setIfDouble(String key, String value)
		{
			double d = 0;
			Boolean state = false;
			putDouble(key, 0);
			if (double.TryParse(value.Trim(), out d))
			{
				putDouble(key, d);
				state = true;
			}
			return state;
		}

    }

}