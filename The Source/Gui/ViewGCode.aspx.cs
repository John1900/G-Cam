using G_Cam.Controls;
using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Gui
{
	public partial class ViewGCode : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				txtCode.Text = Data.sGCode;
				ucHeader.setName(Data.sName);

				if (Data.sWarning.Equals(""))
				{
					lblWarn.Visible = false;
				}
				else
				{
					lblWarn.Text = Data.sWarning;
				}

			}

		}

 
		protected void cmdDownload_Click(object sender, EventArgs e)
		{
			String txt = Data.sGCode;

			Response.ClearContent();
			Response.ClearHeaders();
			Response.ContentType = "text/plain";
			Response.AddHeader("Content-Disposition", "attachment;filename=GCAM.ncc");

			Response.Write(txt);

			Response.End();
			Response.Flush();
			Response.Close();
		}

		protected void cmdExit_Click(object sender, EventArgs e)
		{
			Server.Transfer("~/Gui/Main.aspx");
		}
	}
}