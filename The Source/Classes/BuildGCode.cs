using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Collections;
using G_Cam.Classes;
using G_Cam.Utility;

namespace G_Cam.Classes
{
    public class BuildGCode
    {
//		private int positionalDirection = 1;
		private String newLine = Environment.NewLine;

		public void buildRoughingPasses()
		{
			if (Data.dMaxPass == 0 && Data.dFinishPass == 0)
			{
				buildOnePass();
			}
			else
			{
				buildManyPasses(); ;
			}
		}

		private void buildOnePass()
		{
			Data.sWarning = "";
			CodeBlock code = new CodeBlock();
			GeneratePass gen = new GeneratePass(code, BuildPasses.buildRawOffsets());

			code.add(doPreCode());
			code.add("(============= Single pass =============)");

			gen.generateNextPass(0, 0);

			code.retract();
			code.rotate(0);
			code.add(doPostCode());

			Data.sGCode = code.getCode();
		}


		// These are the roughing passes where we work down to the base circle

		private void buildManyPasses()
		{
			Data.sWarning = "";
			CodeBlock code = new CodeBlock();
			GeneratePass gen = new GeneratePass(code, BuildPasses.buildRawOffsets());

			PathMetrics pm = new PathMetrics();
			pm.compute();
			int passes = pm.getNumberRoughPasses();
			double depthPerPass = pm.getDepthRoughPasses();
			double currentDepth = 0;
			double maxOffset = 0;
			double maxOffsetAngle = 0;
			int maxOffsetPass = 0;

			code.add(doPreCode());

			for (int pass = 1; pass <= passes; pass++)
			{
				code.add("(============= Pass " + pass.ToString() + " of " + passes.ToString() + " =============)");
				currentDepth -= depthPerPass;

				gen.generateNextPass(currentDepth, 0);

				Polar max = gen.getMaxOffset();
				if(max.r > maxOffset)
				{
					maxOffset = max.r;
					maxOffsetAngle = max.a;
					maxOffsetPass = pass;
				}
			}

			code.retract();
			code.rotate(0);

			code.add(doPostCode());
			Data.sGCode = code.getCode();

			if(maxOffset > 0) { doOffsetWarning(maxOffset, maxOffsetAngle, maxOffsetPass); }

		}


		// This is the final pass with compensation for grinder wear

		public void buildFinalPass()
		{
			Data.sWarning = "";
			CodeBlock code = new CodeBlock();
			GeneratePass gen = new GeneratePass(code, BuildPasses.buildRawOffsets());

			code.add(doPreCode());
			code.add("(============= Single finish pass =============)");

			// Adjust for grinder wear
			double grinderAdjust = Data.dActualBaseDiameter / 2 - Data.dBaseRadius;

			gen.generateNextPass(0, grinderAdjust);

			code.retract();
			code.rotate(0);

			code.add(doPostCode());

			Data.sGCode = code.getCode();
		}

		
        private String doPreCode()
        {
			SetupG20G21.set();

            String code = "";
            code += header();
            code += newLine;
			code += Data.sPreCode;
            code += newLine;
            return code;
        }

        private String doPostCode()
        {
            String code = "";
            code += newLine;			
            code += Data.sPostCode;
            code += newLine;
            return code;
        }

        private String header()
        {
            String hdr = "";

			DrawAcceleration da = new DrawAcceleration();
			da.compute();					// Lifter diameter

			hdr += headLine("Built by G-CAM " + DateTime.UtcNow + "  UTC");
			hdr += headLine("Name: ", Data.sName);
			hdr += headLine("Base radius: ", Data.dBaseRadius);
            hdr += headLine("Lift: ", Data.dLift);
            hdr += headLine("Flank radius: ", Data.dFlankRadius);
            hdr += headLine("CAM Duration angle: ", Change.toDegrees(Data.dAction));
			hdr += headLine("Nose radius: ", Data.dNoseRadius);
			hdr += headLine("Flat lifter min diameter: ", Data.dLifterDiameter);
			hdr += headLine("Blank diameter: ", Data.dBlankDiameter);
            hdr += headLine("Tracking leeway: ", Data.dPrecision);
            hdr += headLine( Data.sRotaryAxis + " values referenced from top of nose - TDC");
            hdr += headLine( Data.sOffsetAxis + " values referenced from edge of blank");

			if (!Data.sCrossAxis.Equals(""))
			{
				hdr += headLine("Cross axis: " + Data.sCrossAxis + " from 0 to " + Data.sCrossAxisEnd + " step " + Data.sCrossAxisStep);
			}

            return hdr;
        }

        private String headLine(String txt)
        {
            return "(" + txt + ")" + newLine;
        }

        private String headLine(String txt, String value)
        {
            return "(" + txt + value + ")" + newLine;
        }

        private String headLine(String txt, double num)
        {
            return "(" + txt + Change.toString(num) + ")" + newLine;
        }

		private void doOffsetWarning(double maxOffset, double maxOffsetAngle, int maxOffsetPass)
		{
			Data.sWarning = "WARNING!<br />At " + Change.toString(maxOffsetAngle) + " degrees in pass " + maxOffsetPass +
							" the " + Data.sOffsetAxis + " axis changes by " + Change.toString(maxOffset) + ".<br />" +
							"This is more than twice the required precision of " + Change.toString(Data.dPrecision) + "<br />" +
							"consider reducing the step size from " + Change.toString(Data.dStep) + " degrees";
		}
    }
}