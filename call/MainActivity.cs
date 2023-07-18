using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Android;

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

            if (btnDial == view)

            {

                Intent intent = new Intent();

                intent.SetAction(Intent.ActionCall);

                Android.Net.Uri data = Android.Net.Uri.Parse("tel:" + "52-11101111");

                intent.SetData(data);

                StartActivity(intent);

            }

        }



    }



}

