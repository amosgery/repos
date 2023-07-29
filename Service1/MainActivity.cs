using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Service1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView tvService, tvIntentService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.myButton);
            Button startBtn = FindViewById<Button>(Resource.Id.startButton);
            Button stopBtn = FindViewById<Button>(Resource.Id.stopButton);
            tvService = FindViewById<TextView>(Resource.Id.tvService);
            tvIntentService = FindViewById<TextView>(Resource.Id.tvIntentService);

            button.Click += delegate {
                Intent intent = new Intent(this, typeof(MyService));
                intent.PutExtra("counter", 5);
                StartService(intent);
            };
            startBtn.Click += delegate {
                //Toast.MakeText(this, "lets start", ToastLength.Short).Show();
                StartService(new Intent(this, typeof(MyIntentService)));
                 //StopService (new Intent ("co.il.appschool.DemoService"));
            };
            stopBtn.Click += delegate {
                //Toast.MakeText(this, "Stopped", ToastLength.Short).Show();
                StopService(new Intent(this, typeof(MyIntentService)));
            };
        }
    }
}