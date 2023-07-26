using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace clockHandler
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnStart, btnStop;
        ClockHandler clockHandler;   // used to delay runnable for a second which delay_RATE
        MyTimer myTimer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //initializing handler
            btnStart = (Button)FindViewById(Resource.Id.btnStart);
            btnStart.Click += StartBtn_Click;
            btnStop = (Button)FindViewById(Resource.Id.btnStop);
            btnStop.Click += StopBtn_Click;
            clockHandler = new ClockHandler(this, btnStart);
        }
        void StartBtn_Click(object sender, System.EventArgs e)
        {
            myTimer = new MyTimer(clockHandler, 5);
            myTimer.Start();
        }
        void StopBtn_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            myTimer.stop = !myTimer.stop;
            btn.Text = myTimer.stop == false ? "stop" : "continue";
        }
    }
}