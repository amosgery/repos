using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace notification_bar
{
    [Service]
    public class MyService : Service
    {
        int count = 0;
        public MyService()
        {

        }
        public override void OnCreate()
        {
            base.OnCreate();
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Notification notification = new Notification(Android.Resource.Drawable.ButtonStar, "DemoService in foreground");
            Intent i = new Intent(this, typeof(SecondActiviy));
            notification.Icon = Android.Resource.Drawable.StarOn;
            i.PutExtra("key", "This is my message");
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, 0, i, PendingIntentFlags.OneShot);
            notification.SetLatestEventInfo(this, "DemoService", "DemoService is running in the foreground", pendingIntent);
            StartForeground((int)NotificationFlags.ForegroundService, notification);
            return base.OnStartCommand(intent, flags, startId);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            StopForeground(true);
        }
    }
}
