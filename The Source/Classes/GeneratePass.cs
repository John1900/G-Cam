using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

		// Generate the GCode for one pass
		// increments depth on each pass
		// Uses, and updates, lower and upper limits as grinding progresses
		// Moves are ignored unless they fall outside the precision limit
		// Duplicate lines ar supressed

namespace G_Cam.Classes
{
	public class GeneratePass
	{
		private CodeBlock code;						// Repository for code
		private List<Polar> offsets;				// Offsets of grinding wheel axis from centre of base circle
		private double currentDepth;
		private double newDepth;
		private int lowerLimit;						// Limits the cut.  These are indexes, not degrees 
		private int upperLimit;			
		private double backlashCompensation = 0;
		private double grinderAdjust;				// Adjust for grinder wear

		private double maxOffset = 0;
		private double maxOffsetAngle = 0;


		public GeneratePass(CodeBlock code, List<Polar> offsets)
		{
			this.code = code;
			this.offsets = offsets;
			lowerLimit = 0;
			upperLimit = offsets.Count - 1;

			if (Data.sRotaryDirection.Equals("I"))
			{
				if (Data.dBacklash != 0) { backlashCompensation = -Data.dBacklash; }
			}
			else
			{
				offsets.Reverse();
				if (Data.dBacklash != 0) { backlashCompensation = Data.dBacklash; }
			}
		}

		public void generateNextPass(double newDepth, double grinderAdjust)
		{
			if (Data.sCrossAxis.Equals(""))
			{
				pass(newDepth, grinderAdjust);
			}
			else
			{
				for (double c = 0; c <= Data.dCrossFeedEnd; c += Data.dCrossFeedStep)
				{
					code.setCrossFeed(c);
					pass(newDepth, grinderAdjust);
				}
			}
		}


		public void pass(double newDepth, double grinderAdjust)
		{
			if (offsets.Count == 0) { return; }

			code.retract();

			this.newDepth = newDepth;
			this.grinderAdjust = grinderAdjust;

			// Skip any leadup we don't need to grind

			for (int i = lowerLimit; i <= upperLimit; i++)
			{
				double r = correctedR(i);

				if (r < currentDepth)
				{
					lowerLimit = i;
					break;
				}
			}

			double prevOffset = Math.Abs(correctedR(lowerLimit));			
			double holdAngle = offsets.ElementAt(lowerLimit).aDeg;
			bool haveHold = false;

			// Go to start and compensate for backlash
			code.retract();
			code.rotate(offsets.ElementAt(lowerLimit).aDeg + backlashCompensation);
			code.rotate(offsets.ElementAt(lowerLimit).aDeg);
			code.line(correctedR(lowerLimit), offsets.ElementAt(lowerLimit).aDeg);

			for(int i = lowerLimit; i <= upperLimit; i++)
			{
				double r = correctedR(i);
				double a = offsets.ElementAt(i).aDeg;

				if (r > currentDepth)
				{
					upperLimit = i - 1;
					break;
				}
			
				double shift = Math.Abs(Math.Abs(r) - Math.Abs(prevOffset));

				if (shift > (2 * Data.dPrecision))
				{
					if (shift > maxOffset)
					{
						maxOffset = shift;
						maxOffsetAngle = a;
					}
				}

				if (Math.Abs(r - prevOffset) < Data.dPrecision)
				{
					holdAngle = a;
					haveHold = true;
				}
				else
				{
					if (haveHold)
					{
						code.line(prevOffset, holdAngle);
						holdAngle = 0;
						haveHold = false;
					}
					code.line(r, a);
					prevOffset = r;
				}
			}

			if (upperLimit >= 0)
			{
				code.line(correctedR(upperLimit), offsets.ElementAt(upperLimit).aDeg);			// End of track
			}
			code.retract();
			currentDepth = newDepth;
		}

		private double correctedR(int index)
		{
			// Negative values cut deeper
			double r = 0 - (offsets.ElementAt(index).r - Data.dWheelDiameter / 2 - Data.dBaseRadius - grinderAdjust);

			if (newDepth != 0)
			{
				if (r < newDepth) { r = newDepth; }
			}

			return r;
		}

		public Polar getMaxOffset()
		{
			return new Polar(maxOffset, maxOffsetAngle);
		}
	}
}
