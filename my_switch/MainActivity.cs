using Android.App;
using Android.Widget;
using Android.OS;
using System;
namespace my_switch
{
    [Activity(Label = "my_switch", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Switch sw;
        ImageView iv;
        SeekBar sb;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            sw = FindViewById<Switch>(Resource.Id.sw);
            iv = FindViewById<ImageView>(Resource.Id.iv);
            sb = FindViewById<SeekBar>(Resource.Id.sb);
            sw.CheckedChange += OnCheckedChanged;
            sb.ProgressChanged += SeekProgressChanged;
            sb.Progress = 50;
        }

        public void SeekProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {

            float a = (float)e.Progress / 100;

            iv.Alpha = a;

            //tv.Text = "alpha is " + a;

        }
    
        public void OnCheckedChanged(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
                iv.Visibility = Android.Views.ViewStates.Visible;
            else
                iv.Visibility = Android.Views.ViewStates.Invisible;

        }
    }
}