using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucBaseTab : System.Web.UI.UserControl
	{

		public virtual void setText(String text) {}
		public virtual void setChecked(bool isChecked) {}
		public virtual void showCheck(bool show) {}

	}
}