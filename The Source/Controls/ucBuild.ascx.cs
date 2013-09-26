using G_Cam.Utility;
using G_Cam.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Controls
{
	public partial class ucBuild : ucBaseControl
	{
		private PathMetrics pm;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lblErrHead.Text = Constants.HEADERROR;
				lblErrHead.Visible = false;
			}

			lblErrHead.Text = "";
			lblErrHead.Visible = false;
		}

		public int type()
		{
			return Constants.BUILD;
		}

		public override Boolean isValid()
		{
			return true;
		}

		public void saveData()
		{
		}

		public override void restoreData()
		{
			pm = new PathMetrics();
			pm.compute();

			lblSetup.Text = "Move the grinding wheel to just touch the blank and zero the " + Data.sRotaryAxis + " and " + Data.sOffsetAxis + " axis.<br /><br />" +
							"If cutting several cams on the same blank the part of the bank that will become the nose should be pointing directly at the centre of the grinding wheel.";

			if (pm.getNumberRoughPasses() == 1)
			{
				lblBuildRough.Text = "Build code for one pass of " + Change.toString(pm.getDepthRoughPasses()) + " " +
									  Data.sUnits;
			}
			else
			{
				lblBuildRough.Text = "Build code for " + pm.getNumberRoughPasses().ToString() + " passes of " + Change.toString(pm.getDepthRoughPasses()) + " " +
									  Data.sUnits + " each leaving " + Change.toString(Data.dFinishPass) + " to finish.";
			}

			double actualBase = (Data.dBaseRadius + Data.dFinishPass) * 2;

			lblFinishNote.Text = "<p>Your cam should now have a base diameter of " + Change.toString(actualBase) +
									 " (twice base radius + finish allowance).  In practice it will likely be more than that due to wear on the grinding wheel. </p>" +
									 "<p>Measure the current base diameter and enter it below.  The finish pass will be calculated to compensate for this wear.<p>" +
									 "<p>If you have to change the setup go back to the mill screen and enter the new grinding wheel diameter and set both rough pass and finish pass to zero.  This will finish the job in a single pass.</p>";

			txtNewBaseRadius.Text = Change.toString(actualBase);
		}

		protected void cmdBuildRough_Click(object sender, EventArgs e)
		{
			if (!isValid()) { return; }
			if (!editAll()) { return; }

			BuildGCode bc = new BuildGCode();
			bc.buildRoughingPasses();
			Server.Transfer("~/Gui/ViewGCode.aspx");
		}

		protected void cmdBuildFinish_Click(object sender, EventArgs e)
		{
			if (!isValid()) { return; }
			if (!editAll()) { return; }

			String err = "";

			if (!Data.setActualBaseDiameterIfDouble(txtNewBaseRadius.Text))
			{
				err += "The revised base diameter must be numeric<br />";
				lblErrHead.Visible = true;
				return;
			}

			lblErrHead.Visible = false;
			BuildGCode bc = new BuildGCode();
			bc.buildFinalPass();
			Server.Transfer("~/Gui/ViewGCode.aspx");
		}

		protected void cmdViewGrind_Click(object sender, EventArgs e)
		{
			if (!editAll()) { return; }

			if (isValid())
			{
				Server.Transfer("~/Gui/PreviewGrind.aspx");
			}
		}

		public bool editAll()
		{
			String err = "";
			bool state = false;

			if(Data.getOutstandingError(Constants.GEOMETRY)) { err += " Geometry,"; }
			if(Data.getOutstandingError(Constants.MILL)) { err += " Mill,"; }
			if(Data.getOutstandingError(Constants.GRIND)) { err += " Grind,"; }
			if(Data.getOutstandingError(Constants.GCODE)) { err += " GCode,"; }

			if (err.Equals(""))
			{
				lblErrHead.Text = "";
				lblErrHead.Visible = false;
				state = true;
			}
			else
			{
				int count = err.Count(x => x == ',');
				err = "Fix errors on" + err.Substring(0, err.Length - 1) + " panel";
				if (count > 1) { err += "s"; }
				lblErrHead.Text = err;
				lblErrHead.Visible = true;
				state = false;
			}
		
			return state;
		}

	}
}