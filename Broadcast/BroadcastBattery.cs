using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Broadcast
{
    public class BroadcastBattery : BroadcastReceiver
    {
        TextView tv;
        public BroadcastBattery()
        {
        }
        public BroadcastBattery(TextView tv)
        {
            this.tv = tv;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            int battery = intent.GetIntExtra("level", 0);
            tv.Text = "Battery status (%): " + battery;
            if (battery > 75) 
                tv.SetTextColor(Android.Graphics.Color.Green);
            else if (battery > 50)
                tv.SetTextColor(Android.Graphics.Color.Orange);
            else if (battery > 25)
                tv.SetTextColor(Android.Graphics.Color.Yellow);
            else
                tv.SetTextColor(Android.Graphics.Color.Red);

        }
    }

    public class BroadcastBluetooth : BroadcastReceiver
    {
        TextView tv;
        public BroadcastBluetooth()
        {
        }
        public BroadcastBluetooth(TextView tv)
        {
            this.tv = tv;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            string action = intent.Action;

            if (action.Equals(BluetoothAdapter.ActionStateChanged))
            {
                int state = intent.GetIntExtra(BluetoothAdapter.ExtraState, BluetoothAdapter.Error);

                tv.Text = "Bluetooth state: " + state;
            }
        }
    }
}