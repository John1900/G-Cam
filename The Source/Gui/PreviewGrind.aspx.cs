using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using GCam.Classes;
using G_Cam.Utility;


namespace G_Cam.Gui
{
	public partial class PreviewGrind : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
				ucHeader.setName(Data.sName);

                display(0);
            }
		}

		protected void cmdCompute_Click(object sender, EventArgs e)
		{
          
            double alpha = 0;
            lblErr.Text = "";

            if (!double.TryParse(txtAlpha.Text.Trim(), out alpha))
            {
                lblErr.Text = "Must be numeric";
                return;
            }

            if (alpha < 0 || alpha > 180)
            {
                lblErr.Text = "Use angles between 0 and 180";
                return;
            }

            display(alpha);
       }

        private void display(double alpha)
        {
            DrawCam dc = new DrawCam();
			dc.drawGrinder(alpha, chkZoom.Checked);
            System.Drawing.Image image = dc.getImage();

            Guid guid = Guid.NewGuid();
            string id = guid.ToString();
            String name = "/Temporary/" + guid.ToString() + ".png";
            image.Save(Server.MapPath("~") + name, ImageFormat.Png);

            imgMain.ImageUrl = ".." + name;
        }


		protected void cmdExit_Click(object sender, EventArgs e)
		{
            Server.Transfer("~/Gui/Main.aspx");
		}

	}
}