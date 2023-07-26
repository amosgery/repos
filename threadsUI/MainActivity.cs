using System;
using System.Threading;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace threadsUI
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {

        Button clockBtn;
        MyCLock myClock;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            clockBtn = (Button)this.FindViewById(Resource.Id.clockBtn);
            clockBtn.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            myClock = new MyCLock(10, clockBtn);
            myClock.Execute(new int[] { 1, 2, 3 });
        }

        public class MyCLock : AsyncTask<Int32, Int32, Int32>
        {
            int counter;
            Button btn;
            public MyCLock(int counter, Button btn)
            {
                this.counter = counter;
                this.btn = btn;
            }
            protected override int RunInBackground(params int[] @params)
            {
                while (counter >= 0)
                {
                    Thread.Sleep(1000);
                    counter--;
                    PublishProgress(counter);
                }
                return counter;
            }
            protected override void OnProgressUpdate(params int[] values)
            {
                base.OnProgressUpdate(values);
                btn.Text = "" + values[0];
            }
            protected override void OnPostExecute(int result)
            {
                base.OnPostExecute(result);
                btn.Text = "done " + result;
            }
        }
    }
}