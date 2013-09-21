using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Classes
{
	public class PathMetrics
	{
		private int numberRoughPasses = 0;
		private double depthRoughPasses = 0;

		public void compute()
		{
			double roughDepth = Data.dBlankDiameter / 2 - Data.dBaseRadius - Data.dFinishPass;
			
			if (Data.dMaxPass == 0)
			{
				numberRoughPasses = 1;
				depthRoughPasses = roughDepth;
			}
			else
			{
				double passes = roughDepth / Data.dMaxPass;
				this.numberRoughPasses = (int)Math.Ceiling(passes);
				depthRoughPasses = roughDepth / numberRoughPasses;
			}
		}

		public int getNumberRoughPasses()
		{
			return numberRoughPasses;
		}

		public double getDepthRoughPasses()
		{
			return depthRoughPasses;
		}
	}
}