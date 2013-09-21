using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.SessionState;

namespace G_Cam.Utility
{
	public class PersistData
	{
		public void save()
		{
			Data.sName = "aa";
			Data.dBaseRadius = 2;
			Data.dNoseRadius = .5;

			String x = "";

			foreach (string key in HttpContext.Current.Session.Keys)
			{
				x += key + " - " + HttpContext.Current.Session[key] + ";";
			}
 


			//SessionStateItemCollection items = HttpContext.Current.Session.


			SessionStateItemCollection items = new SessionStateItemCollection();

			items["Name"] = "NN";
			items["Desc"] = "DD";
			
			try
			{
				System.IO.BinaryWriter writer = new System.IO.BinaryWriter(
				  System.IO.File.Open(HttpContext.Current.Server.MapPath("./session_collection.bin"), System.IO.FileMode.Create));

				items.Serialize(writer);
				writer.Close();

				items["Name"] = "";
				items["Desc"] = "";

				System.IO.BinaryReader reader = new System.IO.BinaryReader(
					System.IO.File.Open(HttpContext.Current.Server.MapPath("./session_collection.bin"), System.IO.FileMode.Open));

				items = SessionStateItemCollection.Deserialize(reader);
				
				String x2 = items["Name"].ToString();
				String y2 = items["Desc"].ToString();
			}
			catch (Exception e)
			{
				String err = e.StackTrace;
			}
		}
	}



	//public class Handler :  IReadOnlySessionState

	public class Handler :  IReadOnlySessionState 
	{
		public void ProcessRequest(HttpContext context)
		{
//			SessionStateItemCollection items = (SessionStateItemCollection)context.Session;
		}



		//public void ProcessRequest(HttpContext context, System.IO.BinaryWriter writer)
		//{
		//	SessionStateItemCollection items = context.Session.????
		//	context.Session.Serialize(writer);
		//}
	}


}