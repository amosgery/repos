using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace questions
{
        public class CustomDialog : Dialog, Android.Views.View.IOnClickListener
        {
            Context context;
            Button btnYes, btnNo;
            public CustomDialog(Context context) : base(context)
            {
                this.context = context;
                this.SetContentView(Resource.Layout.custom_layout);
                this.SetCancelable(false);
                this.SetTitle("Game Over");

                btnNo = FindViewById<Button>(Resource.Id.btnNo);
                btnYes = FindViewById<Button>(Resource.Id.btnYes);
                btnYes.SetOnClickListener(this);
                btnNo.SetOnClickListener(this);
            }
            public void OnClick(View v)
            {
                if (btnNo == v)
                {
                    ((Activity)context).Finish();
                    Toast.MakeText(context, "finish", ToastLength.Long).Show();


                }
                else if (btnYes == v)
                {
                    Toast.MakeText(context, "play again", ToastLength.Long).Show();
                    ((ITriviaFunctions)context).resetGame();
                    this.Dismiss();
                }
            }
        }
    

}
