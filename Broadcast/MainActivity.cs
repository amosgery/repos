using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Broadcast
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView tv, tvBluetooth;
        BroadcastBattery broadCastBattery;
        BroadcastBluetooth broadcastBluetooth;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            tv = FindViewById<TextView>(Resource.Id.tv);
            tvBluetooth = FindViewById<TextView>(Resource.Id.tvBluetooth);
            broadCastBattery = new BroadcastBattery(tv);
            broadcastBluetooth = new BroadcastBluetooth(tvBluetooth);
        }
        protected override void OnResume()
        {
            base.OnResume();
            RegisterReceiver(broadCastBattery, new IntentFilter(Intent.ActionBatteryChanged));
            RegisterReceiver(broadcastBluetooth, new IntentFilter("android.bluetooth.adapter.action.STATE_CHANGED"));
        }

        protected override void OnPause()
        {
            UnregisterReceiver(broadCastBattery);
            UnregisterReceiver(broadcastBluetooth);

            base.OnPause();
        }
    }
}