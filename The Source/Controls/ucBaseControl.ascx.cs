using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucBaseControl : System.Web.UI.UserControl
	{

		public virtual bool isValid()
		{
			return false;
		}

		public virtual void restoreData()
		{
		}
	}
}