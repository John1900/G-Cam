using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Classes
{
	public class CompGeometry
	{
		private double F;               //flank radius
		private double B;               // base radius
		private double L; 				// lift
		private double N;				// Nose radius
		private double W;				// Grinding wheel radius
		private double a;               // action angle

		public CompGeometry()
		{
			F = Data.dFlankRadius;
			B = Data.dBaseRadius;
			L = Data.dLift;
			W = Data.dWheelDiameter / 2;
			a = Data.dAction / 2;
			
			Data.cFlankOrigin = compFlankCentre();
			
			Data.dNoseRadius = compNoseRadius();
			N = Data.dNoseRadius;

			Data.dFlankAngle = flankAngle();

			Data.pLifterTransitionTop = compLifterTransitionTop();
			Data.pTransitionTopGrinder = compTopGrinderTransition();
			Data.pTransitionBot = new Polar(B, a);
		}

		// Coordinates of flank centre.  Hypotenuse is F-B and angle is a.
		private Coord compFlankCentre()
		{
			double x = (F - B) * Math.Sin(a);
			double y = (F - B) * Math.Cos(a);
			return new Coord(x, y);
		}

		// Angle between flank radius through nose centre and flank radius
		// through bs centre.  These radii cross the intersections between base, flank
		// and nose arcs.
		private double flankAngle()
		{
			return Math.Asin((B + L - N) * Math.Sin(Constants.R180 - a) / (F - N));
		}

		// Nose radius.  
		// The top of the nose circle is B + L above base centre
		// A flank radii though the nose centre will cross the nose perimeter 
		// where it joins the flank arc
		private double compNoseRadius()
		{
			double fX = Data.cFlankOrigin.x;
			double fY = Data.cFlankOrigin.y;
			double m = B + L + fY;


			// (F - N)^2 = x^2 + (m + y)^2
			// F^2 + N^2 -2FN = x^2 + m^2 + N^2 - 2mN

			return (fX * fX + m * m - F * F) / (2 * (m-F));
		}

		// Point where a grinding wheel transitions from the nose to the flank arc.
		// At this point a flank radius will pass through the nose centre and the wheel centre
		private Polar compTopGrinderTransition()
		{
			double cosBeta = ((F - N) * (F - N) + (F - B) * (F - B) - (B + L - N) * (B + L - N)) / (2 * (F - N) * (F - B));
			double beta = Math.Acos(cosBeta);

			double rSquared = ((F + W) * (F + W) + (F - B) * (F - B)) - (2 * (F + W) * (F - B) * cosBeta);
			double r = Math.Sqrt(rSquared);

			double gamma = Math.Asin((F - B) * Math.Sin(beta) / r);

			double delta = Constants.R180 - beta - gamma; ;
			double alpha = delta + a - Constants.R180;

			// For testing
			//double a0 = Change.toDegrees(beta);
			//double a1 = Change.toDegrees(gamma);
			//double a2 = Change.toDegrees(delta);
			//double a3 = Change.toDegrees(alpha);

			return new Polar(r, alpha);
		}

		// Point where a flat lifter transitions from the nose to flank arc
		// The lifter is horizontal so the flank radius through nose centre will be verticle
		// Lift is measured from the base circle perimeter
		private Polar compLifterTransitionTop()
		{
			double alpha = Math.Asin((F - B) * Math.Sin(Data.dFlankAngle) / (B + L - N));	// Complementary angle 	

			double y = (B + L - N) * Math.Cos(alpha) + N;
			double x = (B + L - N) * Math.Sin(alpha);
				
			// For testing
			double a1 = Change.toDegrees(alpha);
			double a2 = Change.toDegrees(Data.dFlankAngle);

			return new Polar(y, alpha);
		}


		// Offset to centre of a grinding wheel may be on nose or flank or base
		public double compGrinderOffset(double alpha)
		{
			double r = 0;
			Boolean compensate = false;

			// Only compute one half.  Other is identicle
			if (alpha > Constants.R180)
			{
				alpha = Constants.R360 - alpha;
				compensate = true;
			}
				
			if (Math.Abs(alpha - Data.pTransitionTopGrinder.a) < 0.00001)
			{
				double a11 = grinderOffsetNose(alpha);
				r = Data.pTransitionTopGrinder.r;
			}

			else if (Math.Abs(alpha - Data.pTransitionBot.a) < 0.00001)
			{
				double a12 = grinderOffsetFlank(alpha);
				r = Data.pTransitionBot.r + Data.dWheelDiameter / 2;
			}

			else if (alpha < Data.pTransitionTopGrinder.a)
			{
				r = grinderOffsetNose(alpha);
			}
			else if (alpha < a)
			{
				r = grinderOffsetFlank(alpha);
			}

			else
			{
				r = B + W;					// Dwelling on base
			}

			if (compensate)
			{
				alpha = Constants.R360 - alpha;
			}


			//For testing
			double dAlpha = Change.toDegrees(alpha);

			return r;
		}

		// Distance to centre of a grinding wheel touching the nose when the cam 
		// is rotated an angle alpha from TDC
		private double grinderOffsetNose(double alpha)
		{
			double sinBeta = (B+L-N) * Math.Sin(alpha) / (N+W);
			double beta = Math.Asin(sinBeta);
			
			double r = (B + L - N) * Math.Cos(alpha) + (N + W) * Math.Cos(beta);

			// For testing
			double betaD = Change.toDegrees(beta);

			return r;
		}

		// Distance to centre of a grinding wheel touching the flank when the cam 
		// is rotated an angle alpha from TDC
		private double grinderOffsetFlank(double alpha)
		{
			double alphaPrime = Constants.R180 - a + alpha;
			double k = (F + W) / Math.Sin(alphaPrime);
			double gamma = Math.Asin((F - B) / k);
			double beta = Constants.R180 - gamma - alphaPrime;
			double r = k * Math.Sin(beta);

			// For testing
			double z0 = Change.toDegrees(alpha);
			double z1 = Change.toDegrees(alphaPrime);
			double z2 = Change.toDegrees(gamma);
			double z3 = Change.toDegrees(beta);

			return r;
		}

		// Computes the amount a flat lifter will be raised when the cam is rotated from TDC
		// Computed as a contact point so max lifter diameter can be determined 
		public Coord compLifterLift(double alpha)
		{
			if (alpha < Data.pLifterTransitionTop.a)
			{
				return lifterLiftNose(alpha);
			}
			else if (alpha < Data.pTransitionBot.a)
			{
				return lifterLiftFlank(alpha);
			}
			return new Coord(0, 0);
		}

		// This is when we are above the top transition resting on the nose
		private Coord lifterLiftNose(double alpha)
		{
			double y = (B + L - N) * Math.Cos(alpha) + N - B;
			double x = (B + L - N) * Math.Sin(alpha);

			return new Coord(x, y);
		}


		// Now we are resting on the flank.  
		private Coord lifterLiftFlank(double alpha)
		{
			double beta = a - alpha;

			double y = F - (F - B) * Math.Cos(beta) - B;

			double x = (F - B) * Math.Sin(beta);

			return new Coord(x, y);
		}

	}
}