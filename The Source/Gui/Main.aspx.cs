using G_Cam.Classes;
using G_Cam.Controls;
using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace G_Cam.Gui
{
	public partial class Main : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//loadTestData();

				//Server.Transfer("~/Gui/PreviewCam.aspx");


				ucIntroductionTab.setText("Introduction");
				ucIntroductionTab.showCheck(true);

				ucGeometryTab.setText("Geometry");
				ucGeometryTab.setChecked(true);
				ucGeometryTab.showCheck(true);

				ucMillTab.setText("Mill");
				ucMillTab.setChecked(true);
				ucMillTab.showCheck(true);

				ucGrindTab.setText("Grind");
				ucGrindTab.setChecked(true);
				ucGrindTab.showCheck(true);

				ucGcodeTab.setText("Code");
				ucGcodeTab.setChecked(true);
				ucGcodeTab.showCheck(true);

				ucBuildTab.setText("Build");
				ucBuildTab.showCheck(true);

				ViewState["PrevIndex"] = 0;

				if (Data.iPendingPanel > 0)			// We have just done a data restore
				{
					ucGeometry.restoreData();
					ucMill.restoreData();
					ucGrind.restoreData();
					ucGCode.restoreData();
					ucBuild.restoreData();

					if (!ucGeometry.isValid()) { ucGeometryTab.setChecked(false); }
					if (!ucMill.isValid()) { ucMillTab.setChecked(false); }
					if (!ucGrind.isValid()) { ucGrindTab.setChecked(false); }
					if (!ucGCode.isValid()) { ucGcodeTab.setChecked(false); }
					if (!ucBuild.isValid()) { ucBuildTab.setChecked(false); }

					lblHead.Text = Data.sName;
					navigateToPanel(Data.iPendingPanel, Data.iPendingPanel);
				}
			}
		}

		protected void GCamTabs_ActiveTabChanged(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			int prevIndex = Convert.ToInt16(ViewState["PrevIndex"]);
			navigateToPanel(prevIndex, currentIndex);
		}

		protected void cmdNext_Click(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			navigateToPanel(currentIndex, currentIndex + 1);
		}

		protected void cmdPrev_Click(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			navigateToPanel(currentIndex, currentIndex - 1);
		}

		public void navigateToPanel(int currentPanelId, int newPanelId)
		{
			Data.setOutstandingError(currentPanelId, !editPanel(currentPanelId));

			cmdPrev.Enabled = (newPanelId != Constants.INTRODUCTION);
			cmdNext.Enabled = (newPanelId != Constants.BUILD);
			lblHead.Text = Data.sName;

			GCamTabs.ActiveTabIndex = newPanelId;
			ViewState["PrevIndex"] = newPanelId;
		}

		private bool editPanel(int currentPanelId)
		{
			bool panelValid = false;

			switch (currentPanelId)
			{
				case Constants.INTRODUCTION:
					panelValid = true;
					break;
				case Constants.GEOMETRY:
					panelValid = ucGeometry.isValid();
					ucGeometryTab.setChecked(panelValid);
					break;
				case Constants.MILL:
					panelValid = ucMill.isValid();
					ucMillTab.setChecked(panelValid);
					break;
				case Constants.GRIND:
					panelValid = ucGrind.isValid();
					ucGrindTab.setChecked(panelValid);
					break;
				case Constants.GCODE:
					panelValid = ucGCode.isValid();
					ucGcodeTab.setChecked(panelValid);
					break;
				case Constants.BUILD:
					panelValid = ucBuild.isValid();
					ucBuildTab.setChecked(panelValid);
					break;
			}

			return panelValid;
		}

		protected void cmdSave_Click(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			editPanel(currentIndex);
			Data.iPendingPanel = currentIndex;
			Server.Transfer("~/Gui/SaveData.aspx");
		}

		protected void cmdRestore_Click(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			Data.iPendingPanel = currentIndex;
			Server.Transfer("~/Gui/RestoreData.aspx");
		}


		protected void btnEnter_Click(object sender, EventArgs e)
		{
			int currentIndex = GCamTabs.ActiveTabIndex;
			editPanel(currentIndex);
		}

		private void loadTestData()
		{
			Data.sName = "My only CAM for Testing";
			Data.sDescription = "This is  asample of a rather elongated CAM I am using to test" + Environment.NewLine + "This is to show how a multi-line description will print so I will keep typing for a while until enough is entered";

			Data.sBaseRadius = "1.5";
			Data.sLift = "0.5";
			Data.sFlankRadius = "10";
			Data.sAction = "120";
			Data.sRpm = "2000";
			Data.sUnits = Constants.INCHES;
			Data.sDecimals = "4";
			Data.sStep = "10";

			Data.dBaseRadius = 1.5;
			Data.dLift = 0.5;
			Data.dFlankRadius = 10;
			Data.dAction = Change.toRadians(120);
			Data.iRpm = 2000;
			Data.iDecimals = 4;
			Data.dStep = 10;

			Data.sWheelDiameter = "10";
			Data.sBlankDiameter = "4.2";
			Data.sMaxPass = "0";
			Data.sFinishPass = "0";
			Data.sSafe = "0.1";
			Data.sPreCode = "M3";
			Data.sPostCode = "M30";
			Data.sBacklash = "0.1";

			Data.sPrecision = "0.002";

			Data.dWheelDiameter = 10;
			Data.dBlankDiameter = 4.2;
			Data.dMaxPass = 0;
			Data.dFinishPass = 0;
			Data.dPrecision = 0.002;
			Data.dSafe = 0.1;

			Data.sRotaryAxis = "A";
			Data.sOffsetAxis = "X";
			Data.sCrossAxis = " ";
			Data.sRotaryFeed = "10";
			Data.sPositionalFeed = "12";
			Data.sRotaryDirection = "I";    // I R
			Data.sOffsetDirection = "I";	// I R
			Data.sCrossAxisEnd = "2";
			Data.sCrossAxisStep = "1";

			Data.dRotaryFeed = 10;
			Data.dPositionalFeed = 12;
			Data.dCrossFeedEnd = 2;
			Data.dCrossFeedStep = 1;

			Data.dBacklash = 0.1;

			Data.iPendingPanel = Constants.GEOMETRY;
		}
	}
}


