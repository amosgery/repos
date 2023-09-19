using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
namespace intent
{

    [Activity(Label = "intent", MainLauncher = true)]

    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        TextView tv;
        Button btnLogin;

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
                tv.Text = "Welcome " + data.GetStringExtra("username");
                Toast.MakeText(this, "Login returned: " + data.GetStringExtra("username"), ToastLength.Long).Show();

            }

        }
    }
}