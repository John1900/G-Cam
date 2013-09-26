using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucGCode : ucBaseControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lblErrHead.Text = Constants.HEADERROR;
				lblErrHead.Visible = false;

				SetupG20G21.set();
				if(Data.sPostCode.Equals("")) { Data.sPostCode = "M30"; }
				txtPreCode.Text = Data.sPreCode;
				txtPostCode.Text = Data.sPostCode;

			}
		}

		public bool close()
		{
			bool state = isValid();
			lblErrHead.Visible = !state;
			return state;
		}

		public void open()
		{
			restoreData();
		}

		public int type()
		{
			return Constants.GCODE;
		}

		private void saveData()
		{
			Data.sStep = txtStep.Text;
			Data.sPrecision = txtAccuracy.Text;
			Data.sPreCode = txtPreCode.Text;
			Data.sPostCode = txtPostCode.Text;
		}

		public override void restoreData()
		{
			SetupG20G21.set();
			txtStep.Text = Data.sStep;
			txtAccuracy.Text = Data.sPrecision;
			txtPreCode.Text = Data.sPreCode;
			txtPostCode.Text = Data.sPostCode;
		}

		public Boolean isValid()
		{
			saveData();

			lblError.Text = "";
			String err = "";


			if (!Data.setStepIfDouble(txtStep.Text))
			{
				err += "The step size must be numeric<br />";
			}

			if (Data.dStep == 0)
			{
				err += "The step size is required<br />";
			}


			if (!Data.setPrecisionIfDouble(txtAccuracy.Text))
			{
				err += "The tracking accuracy must be numeric<br />";
			}

			if (err.Length == 0)
			{
				if (Data.dBlankDiameter < Data.dBaseRadius * 2 + Data.dLift + Data.dFinishPass * 2)
				{
					err += "Blank is not large enough for this cam!<br />";
				}
			}

			if (err.Length != 0)
			{
				Data.setOutstandingError(Constants.GCODE, true);
				lblError.Text = err;
				lblErrHead.Visible = true;
				return false;
			}

			Data.setOutstandingError(Constants.GCODE, false);
			lblErrHead.Visible = false;
			return true;
		}

	}
}