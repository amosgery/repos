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

namespace clockHandler
{
    public class ClockHandler : Handler
    {
        Context context;
        Button btn;
        public ClockHandler(Context context, Button btn)
        {
            this.context = context;
            this.btn = btn;
        }
        public override void HandleMessage(Message msg)
        {
            btn.Text = "" + msg.Arg1;
        }
    }
}