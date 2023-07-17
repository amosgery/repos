using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using Android;

using Android.App;

using Android.Content;

using Android.OS;

using Android.Runtime;

using Android.Views;

using Android.Widget;



namespace intent

{

    [Activity(Label = "SecondActivity")]

    public class SecondActivity : Activity

    {
        TextView tv;
        protected override void OnCreate(Bundle savedInstanceState)

        {



            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.second_activity);

            // Create your application here
            tv = FindViewById<TextView>(Resource.Id.tvDisplay);

            String fname = Intent.GetStringExtra("fname") ?? "fname not availabe";

            String lname = Intent.GetStringExtra("lname") ?? "lname not availabe";

            tv.Text = "welcone " + fname + " " + lname;


        }

    }

}