using System.Collections.Generic;
using Android.App;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AllSensors
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        List<string> sensors;
        ArrayAdapter<string> adapter;
        ListView lv;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            lv = FindViewById<ListView>(Resource.Id.lv);
            sensors = GetAllSensors();
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, sensors);
            lv.Adapter = adapter;
        }
        public List<string> GetAllSensors()
        {
            SensorManager sm = (SensorManager)this.GetSystemService(SensorService);
            var all = sm.GetSensorList(SensorType.All);
            List<string> list = new List<string>();
            for (int i = 0; i < all.Count; i++)
            {
                list.Add(all[i].Name);
            }
            return list;
        }
    }
}