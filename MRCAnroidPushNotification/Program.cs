using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace MRCAnroidPushNotification
{
	class Program
	{
		static void Main(string[] args)
		{
				
			AndriodPushNotification push = new AndriodPushNotification();
			push.SendPushNotificationForAndroidSWithoutImage();
		}
	}
}
