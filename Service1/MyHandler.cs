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

namespace Service1
{
    public class MyHandler : Handler
    {
        Context context;
        public MyHandler()
        {
        }
        public MyHandler(Context context)
        {
            this.context = context;
            //Toast.MakeText(context, "Service started", ToastLength.Short).Show();
        }
        public override void HandleMessage(Message msg)
        {
            Toast.MakeText(context, "Id: " + msg.Arg2 + " counter: " + msg.Arg1, ToastLength.Short).Show();
        }
    }
}