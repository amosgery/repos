using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
using Android.Runtime;
namespace intent
{

    [Activity(Label = "intent", MainLauncher = true)]

    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        EditText etFname, etLname;
        Button btnSave;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);

            // Get our button from the layout resource,

            // and attach an event to it

            etFname = FindViewById<EditText>(Resource.Id.etFname);

            etLname = FindViewById<EditText>(Resource.Id.etLname);

            btnSave = FindViewById<Button>(Resource.Id.btnSave);

            btnSave.SetOnClickListener(this);



        }

        public void OnClick(Android.Views.View view)

        {

            if (btnSave == view)

            {

                Intent intent = new Intent(this, typeof(SecondActivity));
                intent.PutExtra("fname", etFname.Text);

                intent.PutExtra("lname", etLname.Text);
                StartActivity(intent);

            }

        }

    }

}