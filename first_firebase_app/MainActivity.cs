using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Telecom;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Auth;


namespace first_firebase_app
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://xamarinfirstapp-2ae7d-default-rtdb.europe-west1.firebasedatabase.app/");
        Button btnSave;
        EditText et;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            et = FindViewById<EditText>(Resource.Id.et);
            btnSave.Click += BtnSave_Click;
        }


        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            if (et.Text != "")
            {
                firebaseClient.Child("records").PostAsync(new MyDatabaseRecord
                {
                    MyProperty = et.Text
                });
                Toast.MakeText(this, "Message sent: " + et.Text,  ToastLength.Short).Show();
                et.Text = "";

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}