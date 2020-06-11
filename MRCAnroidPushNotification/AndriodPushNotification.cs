using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MRCAnroidPushNotification
{
	public class AndriodPushNotification
	{

		public string SendPushNotificationForAndroidSWithoutImage()
		{
			PushNotificationParameters parameters = new PushNotificationParameters();

			//parameters.DeviceId =System.Configuration.ConfigurationManager.AppSettings.Get("DeviceId");
			//parameters.ServerKey = System.Configuration.ConfigurationManager.AppSettings.Get("ServerKey");
			//parameters.SenderId = System.Configuration.ConfigurationManager.AppSettings.Get("SenderId");
			//parameters.DeviceId = "AIzaSyCr3PU2QDktxPVxTszd-62H0B73HMbcruE";
			parameters.ServerKey = "AAAA-03M4mA:APA91bEnieHV6VhnOAHNFEPTR-M95dl0iQMag5nxhOKA_P6dyzRZszIJBMzBp98Q1FbyYG0VTGTsFx0eAIkbkYWvTTUmhVgzskGH0i3U-TVX_BgNE0QjBudL7HnXgu6RfIxNYolBgO7M";
			parameters.SenderId = "1079342064224";
			parameters.RequestTimeOut = 20000;
			parameters.Title = "TestTitle";
			parameters.SoundEnable = "Yes";
			parameters.NotificationEN = "TestEn";
			parameters.NotificationAR = "TestAR";
			parameters.Message ="testMessage";
			string response;
			try
			{
				
				WebRequest request = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
				request.Timeout = parameters.RequestTimeOut;
				request.Method = "Post";
				request.ContentType = "application/json";
				var data = new
				{
					to = parameters.DeviceId,
					notification = new
					{
						title = parameters.Title,
						sound = parameters.SoundEnable,
						messageAR = parameters.NotificationAR,
						messageEN = parameters.NotificationEN						
					}
				};
				var json = SerializeAndroidWithoutImage(parameters);
				//tracingService.Trace("SendPushNotificationForAndroidWithoutImage: json" + json);
				Byte[] byteArray = Encoding.UTF8.GetBytes(json);
				request.Headers.Add(string.Format("Authorization:key={0}", parameters.ServerKey));
				request.Headers.Add(string.Format("Sender: id={0}", parameters.SenderId));
				request.ContentLength = byteArray.Length;
				//	tracingService.Trace("SendPushNotificationForAndroidWithoutImage : ContentLength" + byteArray.Length);

				using (Stream dataStream = request.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
					//	tracingService.Trace("SendPushNotificationForAndroidWithoutImage:dataStream " + dataStream.Length);

					using (WebResponse webResponse = request.GetResponse())
					{
						using (Stream dataStreamResponse = webResponse.GetResponseStream())
						{
							using (StreamReader streamReader = new StreamReader(dataStreamResponse))
							{
								string sResponseFromServer = streamReader.ReadToEnd();
								response = sResponseFromServer;
							}
						}
					}


				}


			}
			catch (Exception ex)
			{
				response = ex.Message;
			}
			return response;
		}
		public string SerializeAndroidWithoutImage(PushNotificationParameters parameters)
		{
			string result = string.Empty;
			result = "{\"to\":\"" + parameters.DeviceId
			+ "\",\"data\":{\"title\":\"" + parameters.Title
			+ "\",\"body\":\"" + parameters.Message
			+ "\",\"sound\":\"" + parameters.SoundEnable
			+ "\",\"messageAR\":\"" + parameters.NotificationAR
			+ "\",\"messageEN\":\"" + parameters.NotificationEN
			+ "\"}}";


			return result;

		}
		//public string SendPushNotificationForAndroidWithImage( PushNotificationParameters parameters)
		//{
		//	string response;
		//	try
		//	{
		//		WebRequest request = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
		//		request.Timeout = parameters.RequestTimeOut;
		//		request.Method = "Post";
		//		request.ContentType = "application/json";
		//		var data = new
		//		{
		//			to = parameters.DeviceId,
		//			data = new
		//			{
		//				title = parameters.Title,
		//				sound = parameters.SoundEnable,
		//				messageAR = parameters.NotificationAR,
		//				messageEN = parameters.NotificationEN,
		//				image = parameters.ImageURL

		//			}
		//		};
		//		var json = SerializeAndroidWithImage(parameters);
		//		//tracingService.Trace("SendPushNotificationForAndroidWithImage : json" + json);

		//		Byte[] byteArray = Encoding.UTF8.GetBytes(json);
		//		request.Headers.Add(string.Format("Authorization: key={0}", parameters.ServerKey));
		//		request.Headers.Add(string.Format("Sender: id={0}", parameters.SenderId));
		//		request.ContentLength = byteArray.Length;
		//		using (Stream dataStream = request.GetRequestStream())
		//		{
		//			dataStream.Write(byteArray, 0, byteArray.Length);


		//			using (WebResponse tResponse = request.GetResponse())
		//			{
		//				using (Stream dataStreamResponse = tResponse.GetResponseStream())
		//				{
		//					using (StreamReader tReader = new StreamReader(dataStreamResponse))
		//					{

		//						String sResponseFromServer = tReader.ReadToEnd();
		//						response = sResponseFromServer;
		//					}
		//				}
		//			}
		//		}


		//	}
		//	catch (Exception ex)
		//	{
		//		response = ex.Message;
		//	}
		//	return response;


		//}

		//public string SerializeAndroidWithImage(PushNotificationParameters parameters)
		//{
		//	string result = string.Empty;

		//	result = "{\"to\":\"" + parameters.DeviceId
		//		+ "\",\"data\":{\"title\":\"" + parameters.Title
		//		+ "\",\"body\":\"" + parameters.Message
		//		+ "\",\"sound\":\"" + parameters.SoundEnable
		//		+ "\",\"messageAR\":\"" + parameters.NotificationAR
		//		+ "\",\"messageEN\":\"" + parameters.NotificationEN
		//		+ "\",\"image\":\"" + parameters.ImageURL + "\"}}";

		//	return result;


		//}
	}
}
