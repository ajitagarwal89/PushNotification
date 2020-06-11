using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRCAnroidPushNotification
{
	public class PushNotificationParameters
	{
		public string DeviceId { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public string SoundEnable { get; set; }
		public string NotificationAR { get; set; }
		public string NotificationEN { get; set; }
		public int RequestTimeOut { get; set; }
		public string ServerKey { get; set; }
		public string SenderId { get; set; }
		//public string ImageURL { get; set; }
	}
}
