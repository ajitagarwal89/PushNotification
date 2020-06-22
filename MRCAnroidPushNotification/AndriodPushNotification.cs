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

			
			parameters.DeviceId = "c8e3X9H3SZ6ZkVfC03ydvm:APA91bG7Dwh0D0V5emRhGVWpcrWU71uw9m2Z3I7uzHSM5dDvgzNckai1F42PIfhv_0Lh6gpcmNU0OsEfoMqdfWHceleY5yXqRPlDPhY5IcUhuLRKYzyuiIHIos3ZyXVJgAN3JjmgWJmi";
			parameters.ServerKey = "AAAAW6UTX4M:APA91bFTPPT7qvSC5VyR854TRyTtzXVuSnG8V8zTu6t3mJnOhhApExR2Qphfgnue0dka3eDWh3RPPkHu6elE9GCUox-ffclJbGGS1EoedUtuetyP4Y0vRuMjlcVSOWo2K5vTrHDsrwZU";
			parameters.SenderId = "393611534211";
			//parameters.ApplicationId = "1:393611534211:android:b1773d098572b7b910e0b6";
			parameters.RequestTimeOut = 20000;
			parameters.Title = "TestTitle";
			parameters.SoundEnable = "Enabled";
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
					//ApplicationId = parameters.ApplicationId,
					to = parameters.DeviceId,
					priority = "high",					
					content_available = true,
			
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
		public string SendPushNotificationForAndroidWithImage(PushNotificationParameters parameters)
		{
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
					data = new
					{
						title = parameters.Title,
						sound = parameters.SoundEnable,
						messageAR = parameters.NotificationAR,
						messageEN = parameters.NotificationEN,
						image = parameters.ImageURL

					}
				};
				var json = SerializeAndroidWithImage(parameters);
				//tracingService.Trace("SendPushNotificationForAndroidWithImage : json" + json);

				Byte[] byteArray = Encoding.UTF8.GetBytes(json);
				request.Headers.Add(string.Format("Authorization: key={0}", parameters.ServerKey));
				request.Headers.Add(string.Format("Sender: id={0}", parameters.SenderId));
				request.ContentLength = byteArray.Length;
				using (Stream dataStream = request.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);


					using (WebResponse tResponse = request.GetResponse())
					{
						using (Stream dataStreamResponse = tResponse.GetResponseStream())
						{
							using (StreamReader tReader = new StreamReader(dataStreamResponse))
							{

								String sResponseFromServer = tReader.ReadToEnd();
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

		public string SerializeAndroidWithImage(PushNotificationParameters parameters)
		{
			string result = string.Empty;

			result = "{\"to\":\"" + parameters.DeviceId
				+ "\",\"data\":{\"title\":\"" + parameters.Title
				+ "\",\"body\":\"" + parameters.Message
				+ "\",\"sound\":\"" + parameters.SoundEnable
				+ "\",\"messageAR\":\"" + parameters.NotificationAR
				+ "\",\"messageEN\":\"" + parameters.NotificationEN
				+ "\",\"image\":\"" + parameters.ImageURL + "\"}}";

			return result;


		}
	}
}
