using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using System.Configuration;
using System.Net;
using System.IO;



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
