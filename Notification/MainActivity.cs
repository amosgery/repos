using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Notify
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnStart, btnFinish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnStart = FindViewById<Button>(Resource.Id.bntStart);
            btnFinish = FindViewById<Button>(Resource.Id.bntFinish);
            btnStart.Click += delegate {
                Toast.MakeText(this, "lets start", ToastLength.Short).Show();
                var nMgr = (NotificationManager)GetSystemService(NotificationService);
                Notification notification = new Notification(Resource.Drawable.a1, "Message from demo service");
                //notification.Icon = Resource.Drawable.a1;
                //notification.TickerText = "Message from demo service";
                //notification.SettingsText("setting text");
                //notification.SmallIcon = Resource.Drawable.a1;
                notification.Defaults |= NotificationDefaults.Sound;
                // Turn on vibrate if the sound switch is on:
                notification.Defaults |= NotificationDefaults.Vibrate;
                Intent i = new Intent(this, typeof(SecondActiviy));
                var pendingIntent = PendingIntent.GetActivity(this, 0, i, 0);
                notification.SetLatestEventInfo(this, "Demo Service Notification", "Message from demo service", pendingIntent);
                nMgr.Notify(0, notification);//0 is id for cancelling
            };
            btnFinish.Click += delegate {
                var nMgr = (NotificationManager)GetSystemService(NotificationService);
                //if want to cancel the notification from the code: nMgr.Cancel(0);

                nMgr.Cancel(0);
            };
        }
    }
}