using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using G_Cam.Utility;


namespace G_Cam.Classes
{
	public class DrawAcceleration
	{
		private const int UNITSPERINCH = 72;
		private const int DIAGRAMWIDTH = 5 * UNITSPERINCH;
		private const int DIAGRAMHEIGHT = 3 * UNITSPERINCH;
		private const int XBORDER = 20;
		private const int YTOPBORDER = 15;
		private const int YBOTBORDER = 15;

		private const int XOFFSET = 15;
		private const int YOFFSET = 15;
		private const double STEPSIZE = 0.1;						// Degrees

		private const int LIFT = 1;
		private const int VELOCITY = 2;
		private const int ACCELERATION = 3;
		private const int GRINDER = 4;


		private Pen outlinePen = new Pen(Color.Black, 2);
		private Pen gridPen = new Pen(Color.Silver, 1);
		private Pen scalePen = new Pen(Color.Black, 6);
		private Pen axisPen = new Pen(Color.Black, 2);
		private SolidBrush textPen = new SolidBrush(Color.Black);
		private SolidBrush pointBrush = new SolidBrush(Color.DarkBlue);
		private Font font10 = new Font("Arial", 10);
		private Font font8 = new Font("Arial", 8);

		private float top;
		private float bot;

		private float xScale;
		private float yScale;

		private double maxLifter = 0;
		private Polar maxLift = new Polar(0, 0);
		private Polar minLift = new Polar(0, 0);
		private Polar maxVelocity = new Polar(0, 0);
		private Polar minVelocity = new Polar(0, 0);
		private Polar maxAcceleration = new Polar(0, 0);
		private Polar minAcceleration = new Polar(0, 0);
		private Polar maxGrind = new Polar(0, 0);
		private Polar minGrind = new Polar(0, 0);

		private List<Polar> pLift = new List<Polar>();
		private List<Polar> pVelocity = new List<Polar>();
		private List<Polar> pAcceleration = new List<Polar>();
		private List<Polar> pGrinder = new List<Polar>();

		private GGraphics g;

		public Image drawLift()
		{
			compute();
			return drawChart(pLift, maxLift, minLift, LIFT);
		}

		public Image drawVelocity()
		{
			compute();
			return drawChart(pVelocity, maxVelocity, minVelocity, VELOCITY);
		}

		public Image drawAcceleration()
		{
			compute();
			return drawChart(pAcceleration, maxAcceleration, minAcceleration, ACCELERATION);
		}

		public Image drawGrinder()
		{
			computeGrinder();
			return drawChart(pGrinder, maxGrind, minGrind, GRINDER);
		}


		public Image drawChart(List<Polar> pValues, Polar max, Polar min, int type)
		{
			// Setup Graphics
			Image image = new Bitmap((int)(DIAGRAMWIDTH * 1.4), (int)(DIAGRAMHEIGHT * 1.4));
	
			// compute scale
			xScale = (float)((DIAGRAMWIDTH  - XBORDER) / 90.0);

			top = NextHigher.get(max.r);
			bot = 0;
			if (min.r < 0) { bot = - NextHigher.get(-min.r); }

			yScale = (DIAGRAMHEIGHT - YTOPBORDER - YBOTBORDER) / (top + Math.Abs(bot));

			Graphics graphics = Graphics.FromImage(image);
			graphics.PageUnit = GraphicsUnit.Point;
			g = new GGraphics(graphics, 1, 0, 0);

			drawBakground(type);
			
			foreach (Polar p in pValues)
			{
				float x = transposeX(p.aDeg);
				float y = transposeY(p.r);
				g.drawPointAbsolute(pointBrush, x, y);
			}

			return image;
		}


		public void compute()
		{
			double prevLift = 0;
			double prevVelocity = 0;
			double timePerStep = 60.0 / Data.iRpm / 360.0 * STEPSIZE;

			CompGeometry cg = new CompGeometry();

			for (double alpha = Constants.R90; alpha >= 0; alpha -= Change.toRadians(STEPSIZE) )
			{
				Coord contact = cg.compLifterLift(alpha);

				// Half width of lifter
				if(contact.x > maxLifter) { maxLifter = contact.x; }

				// Lift
				double lift = contact.y; // -Data.dBaseRadius;
				pLift.Add(new Polar(lift, alpha));
				if(lift > maxLift.r) { maxLift = new Polar(lift, alpha); }
				if(lift < minLift.r) { minLift = new Polar(lift, alpha); }


				// Vertical velocity
				double velocity = (lift - prevLift) / timePerStep;
				pVelocity.Add(new Polar(velocity, alpha));
				if(velocity > maxVelocity.r) { maxVelocity = new Polar(velocity, alpha); }
				if(velocity < minVelocity.r) { minVelocity = new Polar(velocity, alpha); } 

				// Vertical acceleration
				double acceleration = velocity - prevVelocity;
				pAcceleration.Add(new Polar(acceleration, alpha));
				if(acceleration > maxAcceleration.r) { maxAcceleration = new Polar(acceleration, alpha); }
				if(acceleration < minAcceleration.r) { minAcceleration = new Polar(acceleration, alpha); } 

				// Save for previuos compares
				prevLift = lift;
				prevVelocity = velocity;
			
				// For testing
				double a = Change.toDegrees(alpha);
				double xx = contact.x;
				double yy = contact.y;
			}

			Data.dLifterDiameter = maxLifter * 2;

			// For testing
			//double l1 = maxLift.aDeg;
			//double l2 = maxLift.r;
			//double v1 = maxVelocity.aDeg;
			//double v2 = maxVelocity.r;
			//double v3 = minVelocity.aDeg;
			//double v4 = minVelocity.r;
			//double a1 = maxAcceleration.aDe
			//double a2 = maxAcceleration.r;
			//double a3 = minAcceleration.aDeg;
			//double a4 = minAcceleration.r;
		}

		private void computeGrinder()
		{
			double prevOffset = 0;
			CompGeometry cg = new CompGeometry();

			for (double alpha = Constants.R90; alpha >= 0; alpha -= Change.toRadians(STEPSIZE) )
			{
				Polar offset = new Polar(cg.compGrinderOffset(alpha) - Data.dBaseRadius - Data.dWheelDiameter/2, alpha);

				if (prevOffset != 0 && Math.Abs((offset.r - prevOffset)) > 0.001)
				{
					double x = Change.toDegrees(alpha);
				}
				prevOffset = offset.r;

				pGrinder.Add(offset);
				double lift = offset.r; 
				pLift.Add(new Polar(lift, alpha));
				if (lift > maxGrind.r) { maxGrind = new Polar(lift, alpha); }
				if (lift < minGrind.r) { minGrind = new Polar(lift, alpha); }
			}
		}


		private void drawBakground(int type)
		{	
			// Draw outline 
			g.drawRectangleAbsolute(outlinePen, XBORDER, YTOPBORDER, DIAGRAMWIDTH - XBORDER, DIAGRAMHEIGHT - YTOPBORDER - YBOTBORDER);

			// Y axis grid
			g.drawStringAbsolute(top.ToString(), font10, textPen, 0, transposeY(top));
			g.drawStringAbsolute("0", font10, textPen, 0, transposeY(0));
			if (bot < 0)
			{
				g.drawLineAbsolute(gridPen, 0, transposeY(0), DIAGRAMWIDTH, transposeY(0));
				g.drawStringAbsolute(bot.ToString(), font10, textPen, 0, transposeY(bot));
			}

			// Transitions
			g.drawLineAbsolute(gridPen, transposeX(Data.pTransitionBot.aDeg), transposeY(bot), transposeX(Data.pTransitionBot.aDeg), transposeY(top));

			if (type == GRINDER)
			{
				g.drawLineAbsolute(gridPen, transposeX(Data.pTransitionTopGrinder.aDeg), transposeY(bot), transposeX(Data.pTransitionTopGrinder.aDeg), transposeY(top));
			}
			else
			{
				g.drawLineAbsolute(gridPen, transposeX(Data.pLifterTransitionTop.aDeg), transposeY(bot), transposeX(Data.pLifterTransitionTop.aDeg), transposeY(top));
			}


			// X labels
			g.drawStringAbsolute("90", font10, textPen, XBORDER, DIAGRAMHEIGHT - YTOPBORDER + 4);
			g.drawStringAbsolute("60", font10, textPen, XBORDER + DIAGRAMWIDTH / 3 - 10, DIAGRAMHEIGHT - YTOPBORDER + 4);
			g.drawStringAbsolute("30", font10, textPen, XBORDER + 2 * DIAGRAMWIDTH / 3 - 10, DIAGRAMHEIGHT - YTOPBORDER + 4);
			g.drawStringAbsolute("0", font10, textPen, DIAGRAMWIDTH - 10, DIAGRAMHEIGHT - YTOPBORDER + 4);

			g.drawStringAbsolute("Base", font10, textPen, 20, 0);
			g.drawStringAbsolute("Flank", font10, textPen, 140, 0);
			g.drawStringAbsolute("Nose", font10, textPen, 320, 0);
		}


		private float transposeX(double x)
		{
			return (float)(((90 - x) * xScale) + XBORDER);;
		}

		private float transposeY(double y)
		{
				return (float)(DIAGRAMHEIGHT - YBOTBORDER - (y - bot) * yScale);
		}

		public Polar getMaxLift() { return maxLift; }
		public Polar getMinLift() { return minLift; }
		public Polar getMaxVelocity() { return maxVelocity; }
		public Polar getMinVelocity() { return minVelocity; }
		public Polar getMaxAcceleration() { return maxAcceleration; }
		public Polar getMinAcceleration() { return minAcceleration; }
	}
}