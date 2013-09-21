using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using G_Cam.Utility;
using G_Cam.Classes;


namespace GCam.Classes
{
	public class DrawCam
	{
		private float unitsPerInch;
		private float diagramSize;

		//private const float diagramSize = 10f * UNITSPERINCH;

		private double F;                       // flank radius
		private double B;                       // base radius
		private double L;						// lift
		private double N;				        // nose radius

		private float gridSize = 0;

		private Pen outlinePen = new Pen(Color.Black, 2);
		private Pen gridPen = new Pen(Color.Silver, 1);
		private Pen scalePen = new Pen(Color.Black, 6);
		private Pen axisPen = new Pen(Color.Black, 2);
        private Pen grinderPen = new Pen(Color.RoyalBlue, 2);
        private SolidBrush textPen = new SolidBrush(Color.Black);
		private SolidBrush pointBrush = new SolidBrush(Color.DarkBlue);

		private Image image;

		private GGraphics g;

		private CompGeometry cg = new CompGeometry();


		public void drawCam()
		{
			setup(false);
			drawBakground();
			drawCamOutline(0);
		}

		public void drawGrinder(double alpha, bool zoomed)
		{
			setup(zoomed);
			drawBakground();
			drawGrinder(alpha);

			drawCamOutline(alpha);
		}


		private void drawCamOutline(double alpha)
		{
			double flankAngle = Change.toDegrees(Data.dFlankAngle);
			double startAngle;
			double endAngle;

			// Base circle

			startAngle = Data.pTransitionBot.aDeg;
			endAngle = 360 - startAngle;
			g.drawArc(outlinePen, 0, 0, B, startAngle, endAngle, alpha);

			// Nose circle

			startAngle = 90 - ((90 - Change.toDegrees(Data.dAction / 2)) + flankAngle);
			endAngle = 360 - startAngle;
			g.drawArc(outlinePen, 0, B + L - N, N, 0, startAngle, alpha);	// Can't draw through 360.  Don't ask!
			g.drawArc(outlinePen, 0, B + L - N, N, endAngle, 360, alpha);
			//g.drawArc(outlinePen, 0, B + L - N, N, 0, 360);

			// Flank circle

			double centreX = Data.cFlankOrigin.x;
			double centreY = Data.cFlankOrigin.y;

			startAngle = Change.toDegrees(Data.dAction / 2);
			endAngle = startAngle - flankAngle;
			g.drawArc(outlinePen, - centreX, - centreY, F, startAngle, endAngle, alpha);

			startAngle = 360 - Change.toDegrees(Data.dAction / 2);
			endAngle = startAngle + flankAngle;
			g.drawArc(outlinePen, centreX, - centreY, F, startAngle, endAngle, alpha);
		}


		public void drawGrinder(double alpha)
		{
			double offset;
			float wheelCentreX;
			float wheelCentreY;

			CompGeometry cg = new CompGeometry();
			offset = cg.compGrinderOffset(Change.toRadians(alpha));
			wheelCentreX = (float)(offset * Math.Sin(Change.toRadians(alpha)));
			wheelCentreY = (float)(offset * Math.Cos(Change.toRadians(alpha)));

			//wheelCentreX = 0;
			//wheelCentreY = (float)offset;

			g.drawLine(grinderPen, 0, 0, wheelCentreX, wheelCentreY);
			g.drawArc(grinderPen, wheelCentreX, wheelCentreY, Data.dWheelDiameter / 2, 0, 360);

			//g.drawLine(grinderPen, 0, (float)(B + L - N), wheelCentreX, wheelCentreY)
		}
		
		
		
		
		private void setup(bool zoomed)
		{
			CompGeometry cg = new CompGeometry();
			F = Data.dFlankRadius;                // flank radius
		    B = Data.dBaseRadius;                 // base radius
		    L = Data.dLift;						  // lift
		    N = Data.dNoseRadius;				  // nose radius
			
			if (zoomed)
			{
				unitsPerInch = 72;
				diagramSize = 10f * unitsPerInch;
				image = new Bitmap(962, 962);
			}
			else
			{
				unitsPerInch = 72;
				diagramSize = 4f * unitsPerInch;
				//image = new Bitmap(480, 480);
				image = new Bitmap(385, 385);
			}

			// Compute diagram height
			float camHeight = (float)(2 * (B + L));
			float camRoundedHeight = NextHigher.get(camHeight * 1.1);
			float scale = diagramSize / camRoundedHeight;

			gridSize = diagramSize / 10 / scale;

			// OriginX/Y is centre of base circle
			float originX = gridSize * 5;
			// Number grid squares to accomodate base radius
			float baseSquares = (float)(Math.Ceiling(B / gridSize));
			float originY = gridSize * 5;			// (float)((10 - baseSquares) * gridSize);

			Graphics graphics = Graphics.FromImage(image);
			graphics.PageUnit = GraphicsUnit.Point;

			g = new GGraphics(graphics, scale, originX, originY);
		}


		public Image getImage()
		{
			return image;
		}


		private void drawBakground()
		{
			// Draw 4 X 4 outline 
			g.drawRectangleAbsolute(outlinePen, 0, 0, diagramSize, diagramSize);

			// Grid 10 X 10
			for (float x = 1; x < 10; x += 1)
			{
				g.drawLineAbsolute(gridPen, x * diagramSize / 10, 0, x * diagramSize / 10, diagramSize);
			}
			for (float y = 0; y < 10; y += 1)
			{
				g.drawLineAbsolute(gridPen, 0, y * diagramSize / 10, diagramSize, y * diagramSize / 10);
			}

			// Scale
			g.drawLineAbsolute(scalePen, diagramSize / 10, diagramSize - diagramSize / 30, diagramSize / 5, diagramSize - diagramSize / 30);
			
			String txt = gridSize.ToString() + " " + Data.sUnits;
			Font font = new Font("Arial", 10);

			// Create point for upper-left corner of text.
			float x1 = diagramSize / 10;
			float y1 = diagramSize - diagramSize / 11;
			StringFormat drawFormat = new StringFormat();
			g.drawStringAbsolute(txt, font, textPen, x1, y1);

			// Axis
			g.drawLine(axisPen, 0, 0, gridSize * 1.1f, 0);
			g.drawLine(axisPen, 0, 0, 0, gridSize * 1.1f);

			g.drawString("Y", font, textPen, - gridSize / 6f, gridSize / .65f);
			g.drawString("X", font, textPen, gridSize * 1.15f, gridSize * .2f);

		}

	}
}