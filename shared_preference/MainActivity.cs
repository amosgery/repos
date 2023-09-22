using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace shared_preference
{
    [Activity(Label = "shared_preference", MainLauncher = true)]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        ISharedPreferences sp;
        Button btnSave;
        EditText etFname, etLname;
        TextView tvDisplay;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnSave = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSave.SetOnClickListener(this);

            etFname = FindViewById<EditText>(Resource.Id.etFname);
            etLname = FindViewById<EditText>(Resource.Id.etLname);
            sp = this.GetSharedPreferences("details", FileCreationMode.Private);
            tvDisplay = FindViewById<TextView>(Resource.Id.tvDisplay);
            String strfname = sp.GetString("fname", null);
            String strlname = sp.GetString("lname", null);
            if (strlname != null && strfname != null)
            {
                tvDisplay.Text = "welcome " + strfname + " " + strlname;
            }
        }

        public void OnClick(Android.Views.View view)
        {
            if (btnSave == view)
            {
                var editor = sp.Edit();
                editor.PutString("fname", etFname.Text);
                editor.PutString("lname", etLname.Text);
                editor.Commit();
                tvDisplay.Text = "welcome " + etFname.Text + " " + etLname.Text;
            }
        }
    }
}