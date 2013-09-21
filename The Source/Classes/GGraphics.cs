using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;

namespace G_Cam.Classes
{
	public class GGraphics
	{

		private Graphics g;

		private float scale = 0;
		private float originX;
		private float originY;

		public GGraphics(Graphics g, float scale, float originX, float originY)
		{
			this.g = g;
			this.scale = scale;
			this.originX = originX;
			this.originY = originY;
		}

		public void drawString(String txt, Font font, Brush brush, float x, float y)
		{
			g.DrawString(txt, font, brush, (float)(originX + x) * scale, (float)(originY - y) * scale);
		}

		//public void drawLine(Pen pen, float x1, float y1, float x2, float y2)
		//{
		//	g.DrawLine(pen, (originX + x1) * scale, (originY - y1) * scale, (originX + x2) * scale, (originY - y2) * scale);
		//}

		public void drawLine(Pen pen, float x1, float y1, float x2, float y2)
		{
			drawLine(pen, x1, y1, x2, y2, 0);
		}

		public void drawLine(Pen pen, float x1, float y1, float x2, float y2, float alpha)
		{
			//float rAlpha = (float)Change.toRadians(90 - alpha);
			//x1 = (float)(x1 * Math.Cos(rAlpha));
			//y1 = (float)(y1 * Math.Sin(rAlpha));
			//x2 = (float)(x2 * Math.Cos(rAlpha));
			//y2 = (float)(y2 * Math.Sin(rAlpha));

			g.DrawLine(pen, (originX + x1) * scale,
							(originY - y1) * scale,
							(originX + x2) * scale,
							(originY - y2) * scale);

		}

		public void drawArc(Pen pen, double centreX, double centreY, double radius, double startAngle, double endAngle)
		{
			drawArc(pen, centreX, centreY, radius, startAngle, endAngle, 0);
		}

		public void drawArc(Pen pen, double centreX, double centreY, double radius, double startAngle, double endAngle, double alpha)
		{			
			//float rAlpha = (float)Change.toRadians(90 - alpha);
			//centreX = (float)(centreX * Math.Cos(rAlpha));
			//centreY = (float)(centreY * Math.Sin(rAlpha));
			//startAngle += alpha;
			//endAngle += alpha;

			// Create bounding rectangle
            try
            {
                int left = (int)(Math.Round((originX + centreX - radius) * scale));
                int top = (int)(Math.Round((originY - centreY - radius) * scale));
                int width = (int)(2 * radius * scale);
                int height = (int)(2 * radius * scale);
                RectangleF rect = new RectangleF(left, top, width, height);
                float sweep = (float)(endAngle - startAngle);
                startAngle -= 90;		// Adjust for Graphics coordinate system
                g.DrawArc(pen, rect, (float)startAngle, sweep);
            }
            catch (Exception e)
            {
                throw e;
            }
		}

		public void drawPoint(Brush b, Polar p)
		{
			float x = (float)(p.r * Math.Cos(p.a - Constants.R90));
			float y = (float)(p.r * Math.Sin(p.a - Constants.R90));
			g.FillRectangle(b, (float)((originX + x) * scale), (float)((originY - y) * scale), 1, 1);
		}

		public void drawRectangleAbsolute(Pen p, float top, float left, float width, float height)
		{
			g.DrawRectangle(p, top, left, width, height);
		}

		public void drawLineAbsolute(Pen pen, float x1, float y1, float x2, float y2)
		{
			g.DrawLine(pen, x1, y1, x2, y2);
		}

		public void drawStringAbsolute(String txt, Font font, Brush brush, float x, float y)
		{
			g.DrawString(txt, font, brush, x, y);
		}


		public void drawPointAbsolute(Brush b, double x, double y)
		{
			g.FillRectangle(b, (float)x, (float)y, 1, 1);
		}



	}
}