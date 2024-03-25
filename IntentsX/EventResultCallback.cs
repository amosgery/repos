using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Activity.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntentsX
{
    public class EventResultCallback : Java.Lang.Object, IActivityResultCallback
    {
        public event EventHandler<ActivityResult> OnActivityResultCalled;

        public void OnActivityResult(Java.Lang.Object result)
        {
            ActivityResult activityResult = result as ActivityResult;
            OnActivityResultCalled?.Invoke(this, activityResult);
        }
    }


}
