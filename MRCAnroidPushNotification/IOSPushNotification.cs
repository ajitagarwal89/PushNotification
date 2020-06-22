using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MRCAnroidPushNotification
{
	public class IOSPushNotification
	{
		public string SendPushNotificationForiOSWithoutImage()
		{
			PushNotificationParameters parameters = new PushNotificationParameters();
			parameters.DeviceId = "26b3303e7b24aea67acf871be3f603443fa07e03";
			parameters.ServerKey = "AAAA-03M4mA:APA91bEnieHV6VhnOAHNFEPTR-M95dl0iQMag5nxhOKA_P6dyzRZszIJBMzBp98Q1FbyYG0VTGTsFx0eAIkbkYWvTTUmhVgzskGH0i3U-TVX_BgNE0QjBudL7HnXgu6RfIxNYolBgO7M";
			parameters.SenderId = "1079342064224";
			parameters.RequestTimeOut = 20000;
			parameters.Title = "TestTitle";
			parameters.SoundEnable = "default";
			parameters.NotificationEN = "TestEn";
			parameters.NotificationAR = "TestAR";
			parameters.Message = "testMessage";
			string response;

			try
			{
				WebRequest webRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
				webRequest.Timeout = parameters.RequestTimeOut;
				webRequest.Method = "POST";

				webRequest.ContentType = "application/json";


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

				
				var json = SerializeiOSWithoutImage(parameters);
			

				Byte[] byteArray = Encoding.UTF8.GetBytes(json);
				webRequest.Headers.Add(string.Format("Authorization: key={0}", parameters.ServerKey));
				webRequest.Headers.Add(string.Format("Sender: id={0}", parameters.SenderId));
				webRequest.ContentLength = byteArray.Length;
				

				using (Stream dataStream = webRequest.GetRequestStream())
				{
					dataStream.Write(byteArray, 0, byteArray.Length);
					

					using (WebResponse webResponse = webRequest.GetResponse())
					{
						using (Stream dataStreamResponse = webResponse.GetResponseStream())
						{
							using (StreamReader streamReader = new StreamReader(dataStreamResponse))
							{								
								String sResponseFromServer = streamReader.ReadToEnd();
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

		public string SerializeiOSWithoutImage(PushNotificationParameters parameters)
		{
			string result = string.Empty;

			result = "{\"to\":\"" + parameters.DeviceId
				+ "\",\"notification\":{\"title\":\"" + parameters.Title
				+ "\",\"body\":\"" + parameters.Message
				+ "\",\"sound\":\"" + parameters.SoundEnable
				+ "\",\"messageAR\":\"" + parameters.NotificationAR
				+ "\",\"messageEN\":\"" + parameters.NotificationEN
				+ "\"}}";

			return result;

		}

	}
}
