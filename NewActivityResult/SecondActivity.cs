using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NewActivityResult
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {

        private EditText etName;
        private Button btnSubmit;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondActivity);

            // Create your application here
            etName = FindViewById<EditText>(Resource.Id.etName);
            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string name = etName.Text;
            Intent intent = new Intent();
            intent.PutExtra("name", name);
            SetResult(Result.Ok, intent);
            Finish();
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            SetResult(Result.Canceled);
        }
    }
}