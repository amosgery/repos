using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace intent
{
    [Activity(Label = "Login")]

    public class LoginActivity : Activity
    {
        EditText username, passwd;
        Button btnSave;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);
            username = FindViewById<EditText>(Resource.Id.etUserName);
            passwd = FindViewById<EditText> (Resource.Id.etPassword);
            btnSave = FindViewById<Button>(Resource.Id.btnDialogLogin);
            // Create your application here
            btnSave.Click += BtnSave_Click;

        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            intent.PutExtra("username", username.Text);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}