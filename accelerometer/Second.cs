using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace accelerometer
{
    [Activity(Label = "Second")]
    public class Second : Activity, Android.Hardware.ISensorEventListener
    {
        TextView tv;
        SensorManager sensorManager;
        static readonly object _syncLock = new object();

        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            Window.AddFlags(WindowManagerFlags.KeepScreenOn);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.second);

            // Get our button from the layout resource,
            // and attach an event to it
            sensorManager = (SensorManager) GetSystemService(Context.SensorService);
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
            tv.Text = string.Format("Second: x={0:f}, y={1:f}, z={2:f}", e.Values[0], e.Values[1], e.Values[2]);
        }
        if (e.Values[0] < 5.5)
        {
                Finish();
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