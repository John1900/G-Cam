using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using G_Cam.Utility;
using GCam.Classes;
using G_Cam.Classes;


namespace G_Cam.Gui
{
	public partial class previewCam : System.Web.UI.Page
	{
		private String type;
		private String label;

		protected void Page_Load(object sender, EventArgs e)
		{
			DrawAcceleration da = (DrawAcceleration)HttpContext.Current.Session["da"];

			type = Request.QueryString["type"];
			lblType.Text = Request.QueryString["label"];
			String id = Request.QueryString["id"];

			ucHeader.setName(Data.sName);

			imgGraph.ImageUrl = "/Temporary/A" + id + ".png";

			imgChart.ImageUrl = "/Temporary/B" + type + id + ".png";

            lblName.Text = Data.sName;
			lblDescription.Text = Data.sDescription.Replace(Environment.NewLine, "<br/>");

			lblUnits.Text = Constants.UNITS;
			lblDecimals.Text = Constants.DECIMALS;
			lblBaseRadius.Text = Constants.BASERADIUS;
			lblFlankRadius.Text = Constants.FLANKRADIUS;
			lblLift.Text = Constants.LIFT;
			lblAction.Text = Constants.ACTION;
			lblRPM.Text = Constants.RPM;

			lblUnitsValue.Text = Data.sUnits;
			lblDecimalsValue.Text = Data.iDecimals.ToString();
			lblBaseRadiusValue.Text = Change.toString(Data.dBaseRadius);
			lblFlankRadiusValue.Text = Change.toString(Data.dFlankRadius);
			lblActionValue.Text = Change.toString(Change.toDegrees(Data.dAction));
			lblLiftValue.Text = Change.toString(Data.dLift);
			lblRPMValue.Text = Data.iRpm.ToString();

			lblNoseRadius.Text = Change.toString(Data.dNoseRadius);
			lblNoseCentreX.Text = "0";
			lblNoseCentreY.Text = Change.toString(Data.dBaseRadius + Data.dLift - Data.dNoseRadius);
			lblFlankCentreX.Text = "+/" + Change.toString(Data.cFlankOrigin.x);
			lblFlankCentreY.Text = Change.toString(Data.cFlankOrigin.y);
			lblLowerTransitionX.Text = "+/- " + Change.toString(Data.cTransitionBot.x);
			lblLowerTransitionY.Text = Change.toString(Data.cTransitionBot.y);
			lblUpperTransitionX.Text = "+/- " + Change.toString(Data.cTransitionTopLifter.x);
			lblUpperTransitionY.Text = Change.toString(Data.cTransitionTopLifter.y);
			lblLifterWidth.Text = Change.toString(Data.dLifterDiameter);

			if (type.Equals("L")) 
			{
				lblAcceleration.Text = "Maximum lift of " + Math.Round(da.getMaxLift().r, 2) + " " + Data.sUnits +
										" occurs at " + Math.Round(da.getMaxLift().aDeg, 2) + " degrees";
			}

			if (type.Equals("V")) 
			{
				lblAcceleration.Text = "Maximum velocity of " + Math.Round(da.getMaxVelocity().r, 2) + " " + Data.sUnits + "/sec" +
										" occurs at " + Math.Round(da.getMaxVelocity().aDeg, 2) +
										" degrees when CAM is rotating at " + Data.iRpm.ToString() + " rpm";
			}

			if (type.Equals("A")) 
			{
				lblAcceleration.Text = "Maximum acceleration of " + Math.Round(da.getMaxAcceleration().r, 2) + " " + Data.sUnits + "/sec/sec" +
										" occurs at " + Math.Round(da.getMaxAcceleration().aDeg, 2) +
										" degrees when CAM is rotating at " + Data.iRpm.ToString() + " rpm";
			}

			if (type.Equals("G")) 
			{
				lblAcceleration.Text = "Shows displacement of a " + Change.toString(Data.dWheelDiameter) + " " + Data.sUnits + 
										" diameter grinding wheel from edge of the base circle";
			}

		}

		protected void cmdExit_Click(object sender, EventArgs e)
		{
			Data.iPendingPanel = Constants.GEOMETRY;
			Server.Transfer("~/Gui/Main.aspx");
		}

	}
}
