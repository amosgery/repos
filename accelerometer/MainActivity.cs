using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace accelerometer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, Android.Hardware.ISensorEventListener
    {
        //phase 1
        static readonly object _syncLock = new object();
        SensorManager sensorManager;
        TextView tv;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,
            // and attach an event to it
            sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            tv = FindViewById<TextView>(Resource.Id.tv);

        }
        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            // We don't want to do anything here.
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                tv.Text = string.Format("First: x={0:f}, y={1:f}, z={2:f}", e.Values[0], e.Values[1], e.Values[2]);
            }
            if (e.Values[0] > 8.5) {
                Intent intent = new Intent(this, typeof(Second));
                StartActivity(intent);

            }

        }
        protected override void OnResume()
        {
            base.OnResume();
            sensorManager.RegisterListener(this, sensorManager.GetDefaultSensor(SensorType.Accelerometer),
                                            SensorDelay.Ui);
        }
        protected override void OnPause()
        {
            base.OnPause();
            sensorManager.UnregisterListener(this);
        }
    }
}