using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucGrind : ucBaseControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lblErrHead.Text = Constants.HEADERROR;
				lblErrHead.Visible = false;
			}
		}

		public int type()
		{
			return Constants.GRIND;
		}

		protected void cmdValidate_Click(object sender, EventArgs e)
		{
			lblErrHead.Visible = !isValid();
		}

		private void saveData()
		{
			Data.sWheelDiameter = txtWheelDiameter.Text;
			Data.sBlankDiameter = txtBlankDiameter.Text;
			Data.sMaxPass = txtMaxPass.Text;
			Data.sFinishPass = txtFinishPass.Text;
			Data.sBacklash = txtBacklash.Text;
			Data.sSafe = txtSafe.Text;
		}

		public override void restoreData()
		{
			txtWheelDiameter.Text = Data.sWheelDiameter;
			txtBlankDiameter.Text = Data.sBlankDiameter;
			txtMaxPass.Text = Data.sMaxPass;
			txtFinishPass.Text = Data.sFinishPass;
			txtBacklash.Text = Data.sBacklash;
			txtSafe.Text = Data.sSafe;
		}

		public override Boolean isValid()
		{
			saveData();

			lblError.Text = "";
			String err = "";

			if (!Data.setWheelDiameterIfDouble(txtWheelDiameter.Text))
			{
				err += "Grinding wheel diameter must be a number.<br />";
			}

			if (!Data.setBlankDiameterIfDouble(txtBlankDiameter.Text))
			{
				err += "Blank diameter must be a number.<br />";
			}

			if (!Data.setMaxPassIfDouble(txtMaxPass.Text))
			{
				err += "Maximun pass must be a number.<br />";
			}

			if (!Data.setFinishPassIfDouble(txtFinishPass.Text))
			{
				err += "Finish pass must be a number.<br />";
			}

			if (!Data.setBacklashIfDouble(txtBacklash.Text))
			{
				err += "Backlash compensation must be a number.<br />";
			}

			if (!Data.setSafeIfDouble(txtSafe.Text))
			{
				err += "Safe clearance must be a number.<br />";
			}
			else
			{
				if(Data.dSafe <= 0) { err += "Safe clearance must be greater than 0.<br />"; }
			}

			if (!Data.setWheelDiameterIfDouble(txtWheelDiameter.Text))
			{
				err += "Wheel diameter must be a number.<br />";
			}

			if (err.Length == 0)
			{
				if (Data.dBlankDiameter < ((Data.dBaseRadius + Data.dLift + Data.dFinishPass) * 2))
				{
					err += "Blank is not large enough for this cam!<br />";
				}
			}

			if (err.Length != 0)
			{
				Data.setOutstandingError(Constants.GRIND, true);
				lblError.Text = err;
				lblErrHead.Visible = true;
				return false;
			}

			Data.setOutstandingError(Constants.GRIND, false);
			lblErrHead.Visible = false;
			return true;
		}
	}
}