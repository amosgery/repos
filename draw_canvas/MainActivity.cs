﻿using Android.App;
using Android.OS;


namespace draw_canvas
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Boardgame b;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            b = new Boardgame(this);
            SetContentView(b);


        }
    }
}
