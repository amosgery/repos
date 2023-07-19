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
        Button btnDial, btnWeb, btnYoutube, btnEmail, btnSMS, btnMap;
        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,

            // and attach an event to it



            btnDial = FindViewById<Button>(Resource.Id.btnDial);
            btnDial.SetOnClickListener(this);
            btnWeb = FindViewById<Button>(Resource.Id.btnWeb);
            btnWeb.SetOnClickListener(this);
            btnYoutube = FindViewById<Button>(Resource.Id.btnYoutube);
            btnYoutube.SetOnClickListener(this);
            btnEmail = FindViewById<Button>(Resource.Id.btnEmail);
            btnEmail.SetOnClickListener(this);
            btnSMS = FindViewById<Button>(Resource.Id.btnSMS);
            btnSMS.SetOnClickListener(this);
            btnMap = FindViewById<Button>(Resource.Id.btnMap);
            btnMap.SetOnClickListener(this);
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
            if (btnWeb == view)
            {
                // make sure you have Internet permission set in your AndroidManifest.xml file
                Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("https://www.stelvio-sys.com"));
                StartActivity(intent);
            }
            if (btnYoutube == view)
            {
                try
                {
                    String videoId = "qjgcTEsLbNw";
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetData(Android.Net.Uri.Parse("https://www.youtube.com/watch?v=" + videoId));
                    //intent.SetPackage("com.google.android.youtube");
                    //intent.PutExtra("VIDEO_ID", videoId);
                    StartActivity(intent);
                }
                catch (Exception e)
                {
                    Toast.MakeText(this, "cant open youtube"+e.Message, ToastLength.Long).Show();
                }
            }
            if (btnEmail == view)

            {
                String[] emails = { "admin@stelvio-sys.com" };
                Intent intent = new Intent(Intent.ActionSend);
                intent.SetType("text/plain");
                intent.PutExtra(Intent.ExtraEmail, emails);
                intent.PutExtra(Intent.ExtraSubject, "Sent from Android test app");
                intent.PutExtra(Intent.ExtraText, "I'm email body.");
                StartActivity(Intent.CreateChooser(intent, "Send Email"));
            }
            if (btnSMS == view)

            {
                String message = "I love you";
                Intent intent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("sms:" + phoneNumber));
                intent.PutExtra("sms_body", message);
                StartActivity(intent);
            }
            if (btnMap == view)
            {
                Intent intent = new Intent(Intent.ActionView);
                intent.SetData(Android.Net.Uri.Parse("geo:19.076,72.8777"));
                Intent chooser = Intent.CreateChooser(intent, "Launch Map");
                StartActivity(chooser);
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

