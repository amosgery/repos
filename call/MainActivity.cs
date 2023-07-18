using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android;
using AndroidX.Core.App;
using System;
using Android.Content.PM;

namespace call
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener

    {
        Button btnDial;
        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,

            // and attach an event to it



            btnDial = FindViewById<Button>(Resource.Id.btnDial);

            btnDial.SetOnClickListener(this);



        }

        public void OnClick(Android.Views.View view)

        {
            string phoneNumber = "+972549797156";
            if (btnDial == view)
            {

                int permissionCheck = (int)PackageManager.CheckPermission(Manifest.Permission.CallPhone, this.PackageName);

                if (permissionCheck == 0)
                {
                    // The permission is already granted, so make the call
                    makeCall(phoneNumber);
                }
                else
                {
                    // The permission is not granted, so request it
                    ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.CallPhone }, 1);
                    permissionCheck = (int)PackageManager.CheckPermission(Manifest.Permission.CallPhone, this.PackageName);
                    if (permissionCheck == 0)
                    {
                        // The permission is already granted, so make the call
                        makeCall(phoneNumber);
                    }
                    else
                        Toast.MakeText(this, "Permission Denied", ToastLength.Short).Show();
                }

            }

        }

        public void makeCall(string phoneNumber)
        {
            Intent intent = new Intent(Intent.ActionCall);
            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));
            StartActivity(intent);
        }



    }



}

