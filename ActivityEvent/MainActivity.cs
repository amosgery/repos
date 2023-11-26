using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Util;
using System;

namespace ActivityEvent
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        private TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textView = FindViewById<TextView>(Resource.Id.textView);

            // Create an instance of YourClass
            var eventGenerator = new EventGenerator();

            // Subscribe to the DataUpdated event
            eventGenerator.DataUpdated += onDataUpdated;

        }

        // Event handler for DataUpdated event
        private void onDataUpdated(object sender, EventArgs e)
        {
            CustomEventArgs ev = (CustomEventArgs)e;
            // Update your activity UI here
            textView.Text = "Seconds: "+ev.Value;
        }
    }
}