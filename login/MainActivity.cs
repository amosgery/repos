using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace login
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView tv;
        private Button loginBtn, closeButton, processBtn;
        ISharedPreferences sp;

        private Dialog d;
        private EditText name;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.tv);
            loginBtn = FindViewById<Button>(Resource.Id.loginBtn);
            closeButton = FindViewById<Button>(Resource.Id.CloseBtn);
            processBtn = FindViewById<Button>(Resource.Id.ProcessBtn);
            closeButton.Click += closeBtnClick;
            processBtn.Click += processBtnClick;
            loginBtn.Click += Login_Click_Dialog;
            sp = GetSharedPreferences("details", FileCreationMode.Private);
            string username = sp.GetString("username", null);
            if (username != null)
            {
                tv.Text = "Welcome " + username;
            }
        }

        private void processBtnClick(object sender, EventArgs e)
        {
            ProgressDialog p = ProgressDialog.Show(this, "Progress dialog", "Loading, please wait...", true);
            p.SetCancelable(true);
            p.SetProgressStyle(ProgressDialogStyle.Horizontal);
            p.SetMessage("Loading...");
            p.Show();
            
        }

        private void closeBtnClick(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);

            builder.SetTitle("התרעה");
            builder.SetMessage(" ? בטוח לסיים את האפליקציה");
            builder.SetCancelable(true);
            builder.SetPositiveButton("כן", OkAction);
            builder.SetNegativeButton("לא", CancelAction);
            Android.App.AlertDialog dialog = builder.Create();
            dialog.Show();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "User cancelled", ToastLength.Long).Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            Finish();
        }

        private void Login_Click_Dialog(object sender, EventArgs e)
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.LoginLayout);
            d.SetTitle("Login Dialog");
            d.SetCancelable(true);
            //etPass = d.FindViewById<EditText>(Resource.Id.etPassword);
            name = d.FindViewById<EditText>(Resource.Id.userName);
            Button btnLogin = d.FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click += LoginDialogClick;
            d.Show();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            
            Intent intent = new Intent(this, typeof(LoginActivity));
            StartActivityForResult(intent, 0);
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            string username = data.GetStringExtra("username");
            tv.Text = "Welcome " + username;

            Toast.MakeText(this, "Login returned:" + username, ToastLength.Long).Show();
            ISharedPreferencesEditor editor = sp.Edit();
            editor.PutString("username", username);
            editor.Commit();
        }


        public void createLoginDialog()
        {

            d = new Dialog(this);
            d.SetContentView(Resource.Layout.LoginLayout);
            d.SetTitle("Login Dialog");
            d.SetCancelable(true);
            //etPass = d.FindViewById<EditText>(Resource.Id.etPassword);
            name = d.FindViewById<EditText>(Resource.Id.userName);
            Button btnLogin = d.FindViewById<Button>(Resource.Id.btnLogin);

            btnLogin.Click += LoginDialogClick;
            d.Show();
        }

        private void LoginDialogClick(object sender, EventArgs e)
        {
            d.Dismiss();
            tv.Text = "Welcome " + name.Text;
            Toast.MakeText(this, "username " + name.Text + " saved", ToastLength.Long).Show();
            ISharedPreferencesEditor editor = sp.Edit();
            editor.PutString("username", name.Text);
            editor.Commit();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}