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
	public partial class RestoreData : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
            }
		}

		protected void cmdUploadNow_Click(object sender, EventArgs e)
		{
			try
			{
				String f = FileUpload.FileName;
				byte[] bytes = FileUpload.FileBytes;
				String txt = System.Text.Encoding.Default.GetString(bytes);

				SessionSaver ss = new SessionSaver();
				ss.deSerialise(txt);

				Data.bRestore = true;

				Server.Transfer("~/Gui/Main.aspx");
			}
			catch (Exception ee)
			{
				lblError.Text = ee.Message;
			}
		}

		protected void cmdCancel_Click(object sender, EventArgs e)
		{
			Data.iPendingPanel = Constants.INTRODUCTION;
			Server.Transfer("~/Gui/BaseForm.aspx");
		}

	}
}