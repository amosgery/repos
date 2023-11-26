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

namespace ActivityEvent
{
    // CustomEventArgs.cs

    public class CustomEventArgs : EventArgs
    {
        public int Value { get; }

        public CustomEventArgs(int value)
        {
            Value = value;
        }
    }
}