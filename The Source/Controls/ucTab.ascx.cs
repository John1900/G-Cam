using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucTab : ucBaseTab
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public override void setText(String txt)
		{
			lblTab.Text = txt;
		}

		public override void setChecked(bool isChecked)
		{
			if (isChecked)
			{
				lblTab.BackColor = Color.White;
				lblTab.ForeColor = Color.RoyalBlue;
			}
			else
			{
				lblTab.BackColor = Color.White;
				lblTab.ForeColor = Color.Red;
			}

			chkTab.Checked = isChecked;
		}

		public override void showCheck(bool show)
		{
			chkTab.Visible = false;  // show;
		}

	}
}