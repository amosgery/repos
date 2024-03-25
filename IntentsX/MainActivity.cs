using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.Activity;
using AndroidX.Activity.Result;
using Android.Graphics;
using AndroidX.Activity.Result.Contract;
using Android.Content;
using Java.Lang;
using Android.Provider;
using Android.Widget;
using System;
using Java.Interop;


// !!!!!!!!!!!!!!!!!!!!!!!!!!!!
// READ ME
// READ ME
// READ ME or die alone:
// Must install tools->nugets->browse: ADD: Xamarin.AndroidX.Fragment

// https://www.youtube.com/watch?v=MTcdw6ETTlg&ab_channel=XamDroid
// Create ActivityResult Callback
// Create Activity ResultLauncher
// Register a Callback
// Launch the activityResultLauncher

namespace IntentsX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IActivityResultCallback
    {
        const int REQUEST_INTENT_OLD = 999;

        Button btnIntent, btnContract,  btnEvent, btnTakePicture;
        ImageView ivPic;
        TextView tvText;

        private ActivityResultLauncher pictureActivityLauncher;
        private IActivityResultCallback pictureResultCallback;

        private IActivityResultCallback getNameResultCallback;
        private ActivityResultLauncher nameActivityLauncher;

        private EventResultCallback eventResultCallback; // See my implementation of this class!!

        private ActivityResultLauncher eventActivityLauncher;
        //private ActivityResultLauncher ActivityLauncher;


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


            // OPTION 3. EVENT Go to some activity and return with stuff inside intent 
            btnEvent = FindViewById<Button>(Resource.Id.btnEvent);
            btnEvent.Click += BtnEvent_Click;

            // Using EvenHandler
            eventResultCallback = new EventResultCallback();
            
            // Give the object the address of a function I wrote: EventResultCallback_OnActivityResultCalled !!!
            eventResultCallback.OnActivityResultCalled += EventResultCallback_OnActivityResultCalled;

            // register via normal Android Contracts: ActivityResultContracts.StartActivityForResult
            eventActivityLauncher = RegisterForActivityResult(new ActivityResultContracts.StartActivityForResult(), 
                                                                        eventResultCallback);
            // END OPTION 3




            // 4 Example PICTURES

            btnTakePicture = FindViewById<Button>(Resource.Id.btnTakePicture);
            btnTakePicture.Click += BtnTakePicture_Click;




            // OPTION 4.0 - 
            // implemented THIS
            //pictureActivityLauncher = RegisterForActivityResult(new ActivityResultContracts.TakePicturePreview(), this);



            // USED IS ALL OPTION 4.1 and 4.2, 4.3
            // DO NOT COMMENT
            pictureResultCallback = new TakePictureCallBack(ivPic);

            // OPTION 4.1 via buit-in contracts
            //pictureActivityLauncher = RegisterForActivityResult(new ActivityResultContracts.TakePicturePreview(),
            //                pictureResultCallback);

            // OPTION 4.2 via Class: TakePicturePreviewContract
            // Launch something from Android using custom contract 
            // Implements are subclass (see below)
            //pictureActivityLauncher = RegisterForActivityResult(new TakePicturePreviewContract(), pictureResultCallback);

            // OPTION 4.3 PICTURE using builtin contracts: ActivityResultContracts.TakePicturePreview
            // Using StartActivityContract
            pictureActivityLauncher = RegisterForActivityResult(new ActivityResultContracts.TakePicturePreview(), pictureResultCallback);
            //new ActivityResultContracts.TakePicturePreview(), 
            //new ActivityResultCallback<Bitmap>() );


        }

        private void BtnIntent_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            StartActivityForResult(intent, REQUEST_INTENT_OLD);
        }

        // Get Name Activity button
        private void BtnContract_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            nameActivityLauncher.Launch(intent);
        }

        private void BtnEvent_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SecondActivity));
            eventActivityLauncher.Launch(intent);
        }

        // Similar to old old-fashion OnActivityResult
        // But now inplemented as inside a call with the IActivityResultCallback interface
        // REQUEST CODE NO LONGER NEEDED:  I come here only for the RESULT of an activity I know which one it is!!!!
        
        // *** MUST COMMENT OUT THE OLD OnActivityResult callback function for this to be called ***/
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

        /* EVEN CALLBACK ACTOVITY RESULT */
        private void EventResultCallback_OnActivityResultCalled(object sender, ActivityResult result)
        {
            if (result.ResultCode == (int)Result.Ok && result.Data.Extras != null)
            {
                tvText.Text = result.Data.Extras.Get(GetString(Resource.String.name)).ToString();
            }
            else
            {
                tvText.Text = "Who cancelled me?";
            }
        }
        
        private void BtnTakePicture_Click(object sender, EventArgs e)
        {
            // launch contract
            Java.Lang.Short i = null;
            pictureActivityLauncher.Launch(i);
        }


        public class TakePictureCallBack :  Java.Lang.Object, IActivityResultCallback
        {
            ImageView iv;
            public TakePictureCallBack(ImageView iv)
            {
                this.iv = iv;
            }

            void IActivityResultCallback.OnActivityResult(Java.Lang.Object result)
            {
                ActivityResult activity = result as ActivityResult;
                iv.SetImageBitmap((Bitmap)result);
            }

        }

        public void OnActivityResult(Java.Lang.Object result)
        {
            ivPic.SetImageBitmap((Bitmap)result);
        }
        /*
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                if (requestCode == REQUEST_INTENT_OLD)
                {
                    string name = data.GetStringExtra(GetString(Resource.String.name));
                    tvText.Text = name;
                }
            }
            else
            {
                Toast.MakeText(this, "(Old) Activity cancelled!", ToastLength.Long).Show();
            }
        }
        */
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}