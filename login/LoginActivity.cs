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

namespace login
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        EditText et;
        Button btnLogin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginLayout);

            et = FindViewById<EditText>(Resource.Id.userName);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click += BtnLogin_Click;

            // Create your application here
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.PutExtra("username", et.Text);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}