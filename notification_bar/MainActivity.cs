using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;

namespace notification_bar
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnStart, btnFinish;
        int count = 0;
        NotificationChannel notificationChannel;
        NotificationManager notificationManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnStart = FindViewById<Button>(Resource.Id.bntStart);
            btnFinish = FindViewById<Button>(Resource.Id.bntFinish);

            notificationChannel = new NotificationChannel("my_channel_id", "My Channel", 0);
            notificationManager = (NotificationManager)GetSystemService(NotificationService);

            notificationManager.CreateNotificationChannel(notificationChannel);
            btnStart.Click += delegate {
                /* using foreground service:
                Intent i = new Intent(this, typeof(MyService));
                StartService(i);
                */
                Intent i = new Intent(this, typeof(SecondActiviy));
                i.PutExtra("key", "new message");
                PendingIntent pendingIntent = PendingIntent.GetActivity(this, 0, i, PendingIntentFlags.OneShot);
                Notification.Builder notificationBuilder = new Notification.Builder(this)
                    .SetSmallIcon(Resource.Drawable.a1)
                    .SetContentTitle("title")
                    .SetContentText("text text" + count);
                notificationBuilder.SetContentIntent(pendingIntent);
                notificationBuilder.SetChannelId(notificationChannel.Id);
                var nb = notificationBuilder.Build();
                notificationManager.Notify(1, nb);
                count++;

            };
            btnFinish.Click += delegate {
                /* using foreground service:
                Intent i = new Intent(this, typeof(MyService));
                StopService(i);
                */
                var nMgr = (NotificationManager)GetSystemService(NotificationService);
                //if want to cancel the notification from the code: nMgr.Cancel(0);
                nMgr.Cancel(0);

            };
        }
    }
}