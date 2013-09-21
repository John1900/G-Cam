using G_Cam.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G_Cam.Classes
{
	public class SessionSaver
	{
		private const String HEADER = "<G-CAM Properties>";

		//private const char blockDelimeter = (char)132;
		//private const char keyDelimeter = (char)133;

		private const char blockDelimeter = (char)174; //';';
		private const char keyDelimeter = (char)175; //':';


		public String serialise()
		{
			String stuff = HEADER;
			foreach (string key in HttpContext.Current.Session.Keys)
			{
				if (key.Length < 5)
				{
					stuff += key + keyDelimeter + HttpContext.Current.Session[key].ToString() + blockDelimeter;
				}
			}
			return stuff;
		}

		public void deSerialise(String stuff)
		{
			int start = HEADER.Length;
			int end = 0;

			try
			{
				if (!stuff.StartsWith(HEADER))
				{
					throw new Exception("This is not a G-Cam properties file (or it is corrupted).  Please try again.");
				}
				do
				{
					end = stuff.IndexOf(blockDelimeter, start);
					if (end > -1)
					{
						restoreBlock(stuff.Substring(start, end - start - 1));
						start = end + 1;
					}
				} while (end > 0);

				Data.iPendingPanel = Constants.GEOMETRY;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		private static void restoreBlock(String block)
		{
			int i = block.IndexOf(keyDelimeter);
			String key = block.Substring(0, i - 1);
			if (key.Length == 2)
			{
				String value = block.Substring(i + 1);
				HttpContext.Current.Session[key] = value;
			}
			else
			{
				String x = "";
			}
		}
	}
}