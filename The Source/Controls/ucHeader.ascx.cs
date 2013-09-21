using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucHeader : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
				
		public void setName(String name)
		{
			lblName.Text = name;
		}
	}
}