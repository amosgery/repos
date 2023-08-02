using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Notify
{
    [Activity(Label = "Second")]
    public class SecondActiviy : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second);
            TextView tv = FindViewById<TextView>(Resource.Id.tv);
            String str = Intent.GetStringExtra("key") ?? "key not availabe";
            tv.Text = str;
            Toast.MakeText(this, "hello from status bar notification", ToastLength.Short).Show();
        }
    }
}