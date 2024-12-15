using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            if (Intent != null)
            {
                string serializedObj = Intent.GetStringExtra("user");
                if (serializedObj != null)
                {
                    User user = new User(JsonConvert.DeserializeObject<User>(serializedObj));
                    Toast.MakeText(this, "Login recieved: " + user.Name, ToastLength.Long).Show();
                }
            }
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent();
            User user = new User();
            user.Name = username.Text;
            user.Pass = passwd.Text;
            string serializedObj = JsonConvert.SerializeObject(user);
            intent.PutExtra("username", serializedObj);
            SetResult(Result.Ok, intent);
            Finish();
        }
    }
}