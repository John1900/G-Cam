using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Simple repository for assembling the G Code.  Handles supression of blank lines

namespace G_Cam.Classes
{
	public class CodeBlock
	{

		private String code = "";
		private String prevLine = "";
		private double prevAngle = 0;
		private String prevF = " ";
		private int positionalDirection = 0;		// Direction of positional axis.  +/- 1

		public CodeBlock()
		{
			positionalDirection = -1;
			if (Data.sOffsetDirection.Equals("I")) { positionalDirection = +1; }
		}

		
		public void add(String line)
		{
			add(line, "");
		}


		public void add(String line, String feed)
		{
			if (!line.Equals(prevLine))
			{
				code += line + feed + Environment.NewLine; ;
				prevLine = line;
			}
		}


		public void line(double r, double a)
		{
			String f = "F" + Data.sPositionalFeed;

			if(f.Equals(prevF)) { f = ""; }
			else { prevF = f; }

			add("G01" + " " + 
					Data.sRotaryAxis + Change.toString(a).PadRight(15) + 
					Data.sOffsetAxis + Change.toString(r * positionalDirection).PadRight(15) + 
					f);
		}
	
		public void rotate(double angle)
		{
			String f = "F" + Data.sRotaryFeed;

			if (f.Equals(prevF)) { f = ""; }
			else { prevF = f; }

			add("G00" + " " + Data.sRotaryAxis + Change.toString(angle).PadRight(15) + f);
			prevAngle = angle;
		}

		public void retract()
		{
			double r = Data.dSafe * positionalDirection;
			add( "G00" + " " + Data.sOffsetAxis + Change.toString(r) );
		}

		public void setCrossFeed(double value)
		{
			retract();
			add("(Crossfeed to: " + Change.toString(value) + ")");
			add( "G00" + " " + Data.sCrossAxis + Change.toString(value));
		}

		public String getCode()
		{
			return code;
		}
	}
}