using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Activity;
using AndroidX.Activity.Result;
using Android.Graphics;
using AndroidX.Activity.Result.Contract;
using Android.Content;
using System;

namespace NewActivityResult
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        const int REQUEST_INTENT_OLD = 999;

        Button btnIntent, btnContract, btnEvent, btnTakePicture;
        ImageView ivPic;
        TextView tvText;



        private IActivityResultCallback getNameResultCallback;
        private ActivityResultLauncher nameActivityLauncher;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            tvText = FindViewById<TextView>(Resource.Id.tvText);
            ivPic = FindViewById<ImageView>(Resource.Id.ivPic);

            // OPTION 1: OLD fashion 
            btnIntent = FindViewById<Button>(Resource.Id.btnIntent);
            btnIntent.Click += BtnIntent_Click;
            // END OPTION 1


            // OPTION 2: VIA non-custom contract:  ActivityResultContracts.StartActivityForResult
            btnContract = FindViewById<Button>(Resource.Id.btnContract);
            btnContract.Click += BtnContract_Click;
            // Object if a Class that will get the result for some activity! I know where and when I will use this object
            // so there is no need for REQUEST_CODE.
            // For another activity I will use a different object so there is no confusion!
            getNameResultCallback = new GetNameResultCallBack(tvText);
            // Prepare a 'launcher'.  the launcher will activate the activity and it will know what object has to be 
            // used for the callback
            nameActivityLauncher = RegisterForActivityResult(new ActivityResultContracts.StartActivityForResult(),
                                                                        getNameResultCallback);
            // END OPTION 2
        }

        private void BtnIntent_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            StartActivityForResult(intent, REQUEST_INTENT_OLD);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                if (requestCode == REQUEST_INTENT_OLD)
                {
                    string name = data.GetStringExtra("name");
                    tvText.Text = name;
                }
            }
            else
            {
                Toast.MakeText(this, "(Old) Activity cancelled!", ToastLength.Long).Show();
            }
        }
        // Get Name Activity button
        private void BtnContract_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            nameActivityLauncher.Launch(intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

    class GetNameResultCallBack : Java.Lang.Object, IActivityResultCallback
    {
        TextView tv;

        public GetNameResultCallBack(TextView tv)
        {
            this.tv = tv;
        }

        public void OnActivityResult(Java.Lang.Object result)
        {
            ActivityResult activityResult = result as ActivityResult; // (ActivityResult) result;
            if (activityResult.ResultCode == (int)Result.Ok)
            {
                tv.Text = activityResult.Data.Extras.Get("name").ToString();

            }
            else
            {
                tv.Text = "Cancelled";
            }
        }
    }
}