using G_Cam.Classes;
using G_Cam.Utility;
using GCam.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace G_Cam.Controls
{
	public partial class ucGeometry : ucBaseControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lblUnits.Text = Constants.UNITS;
				lblDecimals.Text = Constants.DECIMALS;
				lblBaseRadius.Text = Constants.BASERADIUS;
				lblFlankRadius.Text = Constants.FLANKRADIUS;
				lblLift.Text = Constants.LIFT;
				lblAction.Text = Constants.ACTION;
				lblRPM.Text = Constants.RPM;

				lblErrHead.Text = Constants.HEADERROR;
				lblErrHead.Visible = false;

				radioUnits.Items.Clear();
				radioUnits.Items.Add(Constants.INCHES);
				radioUnits.Items.Add(Constants.MM);
				radioUnits.SelectedValue = Data.sUnits;
			}
		}

		public int type()
		{
			return Constants.GEOMETRY;
		}

		public override void restoreData()
		{
			txtName.Text = Data.sName;
			txtDescription.Text = Data.sDescription;
			txtBaseRadius.Text = Data.sBaseRadius;
			txtValveLift.Text = Data.sLift;
			txtFlankRadius.Text = Data.sFlankRadius;
			txtAction.Text = Data.sAction; ;
			txtRpm.Text = Data.sRpm;
			radioUnits.SelectedValue = Data.sUnits;
			txtDecimals.Text = Data.sDecimals;
			radioType.SelectedValue = Data.sGraphType;
		}

		private void saveData()
		{
			Data.sName = txtName.Text;
			Data.sDescription = txtDescription.Text;
			Data.sBaseRadius = txtBaseRadius.Text;
			Data.sLift = txtValveLift.Text;
			Data.sFlankRadius = txtFlankRadius.Text;
			Data.sAction = txtAction.Text;
			Data.sRpm = txtRpm.Text;
			Data.sUnits = radioUnits.SelectedValue;
			Data.sDecimals = txtDecimals.Text;
			Data.sGraphType = radioType.SelectedValue;
			SetupG20G21.set();
		}


		protected void cmdValidate_Click(object sender, EventArgs e)
		{
			lblErrHead.Visible = !isValid();
		}

		protected void cmdView_Click(object sender, EventArgs e)
		{
			if (isValid())
			{
				lblErrHead.Visible = false;
				string guid = Guid.NewGuid().ToString();

				if(buildGraphics(guid))
				{
					Server.Transfer("~/Gui/PreviewCam.aspx?type=" + radioType.SelectedValue + 
									"&label=" + radioType.SelectedItem + 
									"&id=" + guid); 
				}
			}
			else
			{
				lblErrHead.Visible = true;
			}
		}

		public override Boolean isValid()
		{
			saveData();

			lblError.Text = "";
			String err = "";

			Data.sName = txtName.Text;
			Data.sDescription = txtDescription.Text;
			Data.sUnits = radioUnits.SelectedValue;

			if (!Data.setBaseRadiusIfDouble(txtBaseRadius.Text))
			{
				err += "Base radius must be a number.<br />";
			}

			if (!Data.setLiftIfDouble(txtValveLift.Text))
			{
				err += "Lobe lift must be a number.<br />";
			}

			if (!Data.setFlankRadiusIfDouble(txtFlankRadius.Text))
			{
				err += "Flank radius must be a number.<br />";
			}

			if (!Data.setActionIfDouble(txtAction.Text))
			{
				err += "Action angle must be a number.<br />";
			}
			else
			{
				if (Data.dAction <= 10 || Data.dAction >= 180)
				{
					err += "Duration angle must be between 10 and 180.<br />";
				}
				else
				{
					Data.dAction = Change.toRadians(Data.dAction);
				}
			}

			if (!Data.setRpmIfInteger(txtRpm.Text))
			{
				err += "RPM must be a number.<br />";

			}
			else
			{
				if (Data.iRpm < 0 || Data.iRpm >= 50000)
				{
					err += "RPM must be 0 - 50,000.<br />";
				}
			}


			if (!Data.setDecimalsIfInteger(txtDecimals.Text))
			{
				err += "Decimals must be a number." + Environment.NewLine;
			}
			else
			{
				if (Data.iDecimals < 0 || Data.iDecimals >= 8)
				{
					err += "Decimals must be 0 - 8.<br />";
				}
			}


			if (err.Equals(""))
			{
				if ((Data.dBaseRadius + Data.dLift) > 1000)
				{
					err += "Cam height greater than 1,000 Cannot be calculated by GCam.<br />";
				}
			}

			try
			{
				CompGeometry cg = new CompGeometry();
			}
			catch (Exception e)
			{
				err += e.Message + "<br />";
			}


			if (!err.Equals(""))
			{
				Data.setOutstandingError(Constants.GEOMETRY, true);
				lblError.Text = err;
				lblErrHead.Visible = true;
				return false;
			}

			lblErrHead.Visible = false;
			Data.setOutstandingError(Constants.GEOMETRY, false);
			return true;
		}

		private bool buildGraphics(String guid)
		{
			lblErrHead.Visible = false;

			try
			{
				// Cleanup all the old graphics files
				try
				{
					DirectoryInfo downloadedMessageInfo = new DirectoryInfo(Server.MapPath("~") + "/Temporary/");
					foreach (FileInfo file in downloadedMessageInfo.GetFiles())
					{
						file.Delete();
					}
				}
				catch (Exception ee)
				{
				}

				DrawCam dc = new DrawCam();
				dc.drawCam();
				System.Drawing.Image image = dc.getImage();

				String name = "/Temporary/A" + guid + ".png";
				image.Save(Server.MapPath("~") + name, ImageFormat.Png);

				DrawAcceleration da = new DrawAcceleration();
				System.Drawing.Image image1 = null;

				if (radioType.SelectedValue.Equals("L")) { image1 = da.drawLift(); }
				if (radioType.SelectedValue.Equals("V")) { image1 = da.drawVelocity(); }
				if (radioType.SelectedValue.Equals("A")) { image1 = da.drawAcceleration(); }
				if (radioType.SelectedValue.Equals("G")) { image1 = da.drawGrinder(); }

				name = "/Temporary/B" + radioType.SelectedValue + guid + ".png";
				image1.Save(Server.MapPath("~") + name, ImageFormat.Png);

				HttpContext.Current.Session["da"] = da;

				return true;
			}
			catch (Exception ee)
			{
				lblError.Text = "Impossible geometry, cannot be modelled!";
				lblErrHead.Visible = true;
				return false;
			}
		}


	}

}