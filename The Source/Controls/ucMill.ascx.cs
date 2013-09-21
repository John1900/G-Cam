using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucMill : ucBaseControl
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
			return Constants.MILL;
		}

		public override void restoreData()
		{
			// Compatability with old layout
			if (Data.sRotaryDirection != "I" && Data.sRotaryDirection != "R") { Data.sRotaryDirection = "I"; }

			txtRotaryAxis.Text = Data.sRotaryAxis;
			txtPositionalAxis.Text = Data.sOffsetAxis;
			txtCrossAxis.Text = Data.sCrossAxis;
			txtPositionalFeed.Text = Data.sPositionalFeed;
			txtRotaryFeed.Text = Data.sRotaryFeed;
			radioRotary.SelectedValue = Data.sRotaryDirection;
			radioPositional.SelectedValue = Data.sOffsetDirection;
			txtCrossEnd.Text = Data.sCrossAxisEnd;
			txtCrossStep.Text = Data.sCrossAxisStep;
		}

		public override bool isValid()
		{
			saveData();

			lblError.Text = "";
			String err = "";

			String txt = txtRotaryAxis.Text.Trim().ToUpper();
			Data.sRotaryAxis = txt;
			if (txt.Equals("") || "ABCXYZUVW".IndexOf(txt) < 0)
			{
				err += "Axis for rotary table A, B, C etc. is required.<br />";
			}

			txt = txtPositionalAxis.Text.ToUpper();
			Data.sOffsetAxis = txt;
			if (txt.Equals("") || "ABCXYZUVW".IndexOf(txt) < 0)
			{
				err += "Axis for positioning cam is required, X, Y Z etc. is required.<br />";
			}
			if (txt.Equals(Data.sRotaryAxis))
			{
				err += "Axis for positioning cam cannot be same as rotary axis<br />";
			}
			
			if (!Data.setPositionalFeedIfDouble(txtPositionalFeed.Text))
			{
				err += "Positional feed rate must be a number." + Environment.NewLine;
			}

			if (!Data.setRotaryFeedIfDouble(txtRotaryFeed.Text))
			{
				err += "Rotary feed rate must be a number." + Environment.NewLine;
			}

			txt = txtCrossAxis.Text.Trim().ToUpper();
			Data.sCrossAxis = txt;
			if (!txt.Equals(""))
			{
				if ("ABCXYZUVW".IndexOf(txt) < 0)
				{
					err += "Cross axis not valid.<br />";
				}
			}

			if (!Data.sCrossAxis.Equals(""))
			{
				if (!Data.setCrossAxisEndIfDouble(txtCrossEnd.Text))
				{
					err += "Cross axis end must be a number." + Environment.NewLine;
				}

				if (!Data.setCrossAxisStepIfDouble(txtCrossStep.Text))
				{
					err += "Cross axis step must be a number." + Environment.NewLine;
				}

				if (Data.dCrossFeedStep >= Data.dCrossFeedEnd)
				{
					err += "Cross axis step must be less than end." + Environment.NewLine;
				}

			}
			else
			{
				txtCrossEnd.Text = "";
				txtCrossStep.Text = "";
				Data.setCrossAxisStepIfDouble("0.0");
				Data.setCrossAxisEndIfDouble("0.0");
			}
			if (txt.Equals(Data.sRotaryAxis))
			{
				err += "Crossfeed axis cannot be same as rotary axis<br />";
			}
			if (txt.Equals(Data.sOffsetAxis))
			{
				err += "Crossfeed axis cannot be same as offset axis<br />";
			}

			if (!err.Equals(""))
			{
				Data.setOutstandingError(Constants.MILL, true);
				lblError.Text = err;
				lblErrHead.Visible = true;
				return false;
			}

			Data.setOutstandingError(Constants.MILL, false);
			lblErrHead.Visible = false;
			return true;
		}

		public void saveData()
		{
			Data.sRotaryAxis = txtRotaryAxis.Text.ToUpper();
			Data.sOffsetAxis = txtPositionalAxis.Text.ToUpper();
			Data.sCrossAxis = txtCrossAxis.Text.ToUpper();
			Data.sRotaryFeed = txtRotaryFeed.Text;
			Data.sPositionalFeed = txtPositionalFeed.Text;
			Data.sRotaryDirection = radioRotary.SelectedValue;
			Data.sOffsetDirection = radioPositional.SelectedValue;
			
			Data.sCrossAxis = txtCrossAxis.Text.Trim().ToUpper();
			Data.sCrossAxisEnd = txtCrossEnd.Text;
			Data.sCrossAxisStep = txtCrossStep.Text;
		}
	}
}