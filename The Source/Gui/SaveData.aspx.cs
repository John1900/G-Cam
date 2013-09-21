using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using G_Cam.Classes;
using G_Cam.Utility;



namespace G_Cam.Gui
{
	public partial class SaveData : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
				if (Data.sSaveFilename.Equals(""))
				{
					txtFile.Text = "GCamProfile.gcm";
				}
				else
				{
					txtFile.Text = Data.sSaveFilename;
				}
            }
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			Server.Transfer("~/Gui/Main.aspx");
		}

		protected void cmdSaveNow_Click(object sender, EventArgs e)
		{
			Data.sSaveFilename = txtFile.Text;

			try
			{
				SessionSaver ss = new SessionSaver();
				String txt = ss.serialise();

				Response.ClearContent();
				Response.ClearHeaders();
				Response.ContentType = "text/plain";
				Response.AddHeader("Content-Disposition", "attachment;filename=" + Data.sSaveFilename);   // + Data.sSaveFilename);

				Response.Write(txt);

				Response.End();
				Response.Flush();
				Response.Close();

				Server.Transfer("~/Gui/Main.aspx");
			}
			catch (Exception ee)
			{
				lblError.Text = ee.Message;
			}

		}
	}
}