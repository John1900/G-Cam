using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Classes
{
	public class BuildPasses
	{
		public static List<Polar> buildRawOffsets()
		{
			return buildRawOffsets(Data.dStep, Data.dWheelDiameter);
		}


		// This just builds the raw offsets for a particular resolution in degrees

		public static List<Polar> buildRawOffsets(double resolution, double wheelDiameter)
		{
			List<Polar> offsets = new List<Polar>();

			CompGeometry cg = new CompGeometry();
			for (double alpha = 0; alpha < Constants.R360; alpha += Change.toRadians(resolution))
			{
				double offset = cg.compGrinderOffset(alpha);
				offsets.Add(new Polar(offset, alpha));
			}

			return offsets;
		}
	}
}