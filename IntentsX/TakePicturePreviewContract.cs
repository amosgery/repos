using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Provider;

using Android.Content;

using AndroidX.Activity;
using AndroidX.Activity.Result;
using Android.Graphics;


using AndroidX.Activity.Result.Contract;

namespace IntentsX
{
    public class TakePicturePreviewContract : ActivityResultContract
    {
        
        public override Intent CreateIntent(Context context, Java.Lang.Object input)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            return intent;
        }

        public override Java.Lang.Object ParseResult(int resultCode, Intent intent)
        {
            if ((int)Result.Ok != resultCode || intent == null)
                return null;
            return intent.GetParcelableExtra("data");
        }
    }
}