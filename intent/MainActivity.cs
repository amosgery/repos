using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Newtonsoft.Json;

namespace intent
{

    [Activity(Label = "intent", MainLauncher = true)]

    public class MainActivity : Activity, View.IOnClickListener
    {
        TextView tv;
        Button btnLogin;
        ISharedPreferences sp;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            tv = FindViewById<TextView>(Resource.Id.tvDisplay);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.SetOnClickListener(this);
            sp = GetSharedPreferences("details", FileCreationMode.Private);
            string strname = sp.GetString("username", null);
            if (strname != null)
            {
                tv.Text = "welcome " + strname;
            }

        }
        public void OnClick(Android.Views.View view)
        {
            if (btnLogin == view)
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivityForResult(intent, 0);
            }
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                var editor = sp.Edit();
                string serializedObj = data.GetStringExtra("username");
                User user = new User(JsonConvert.DeserializeObject<User>(serializedObj));

                string username = user.Name;
                tv.Text = "Welcome " + username;

                editor.PutString("username", username);
                editor.Commit();

                Toast.MakeText(this, "Login returned: " + username, ToastLength.Long).Show();

            }

        }
    }
}