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
using Java.Lang;

namespace surface_view
{
    [Activity(Label = "GameActivity")]
    public class GameActivity : Activity
    {
        DrawSurfaceView ds;
        bool userAskBack = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            ds = new DrawSurfaceView(this);
            SetContentView(ds);
            ds.t.Start();
        }
        protected override void OnResume()
        {
            base.OnResume();
            if (ds != null)
            {
                ds.resume();
                Toast.MakeText(this, "OnResume", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "ds is null OnResume", ToastLength.Long).Show();
            }
        }

        protected override void OnStart()
        {
            base.OnStart(); ;
            Toast.MakeText(this, "OnStart", ToastLength.Long).Show();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Toast.MakeText(this, "OnDestroy", ToastLength.Long).Show();
        }

        protected override void OnStop()
        {
            base.OnStop();
            Toast.MakeText(this, "OnStop", ToastLength.Long).Show();

        }


        protected override void OnPause()
        {
            base.OnPause();
            if (userAskBack)
            {
                Toast.MakeText(this, "OnPause1", ToastLength.Long).Show();
            }
            else if (ds != null)
            {
                ds.pause();
                Toast.MakeText(this, "OnPause2", ToastLength.Long).Show();

            }
            Toast.MakeText(this, "OnPause3", ToastLength.Long).Show();
        }

        public override void Finish()
        {

            base.Finish();
            userAskBack = true;
            ds.threadRunning = false;
            while (true)
            {
                try
                {
                    ds.t.Join();
                }
                catch (InterruptedException e)
                {
                    //Toast.MakeText(this,"some problem happened",ToastLength.Long).Show();
                }
                break;
            }
            Toast.MakeText(this, "Finish" + ds.threadRunning, ToastLength.Long).Show();
        }
    }
}