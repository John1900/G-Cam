using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucIntroduction : ucBaseControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public int type()
		{
			return Constants.GEOMETRY;
		}

		public override bool isValid()
		{
			return true;
		}
	}
}