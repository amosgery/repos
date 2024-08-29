using Android.Runtime;
using Firebase.Database;
using Firebase.Database.Query;

namespace firebase.net
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://xamarinfirstapp-2ae7d-default-rtdb.europe-west1.firebasedatabase.app/");
        Button btnSave;
        EditText et;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

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
                List<string> list = new List<string>();
                int[] numbers = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    list.Add(et.Text + i);
                    numbers[i] = i;
                }
                MyDatabaseRecord myData = new MyDatabaseRecord(et.Text, list, numbers);
                //var myRef = firebaseClient.Child("records").Child("key1");
                // Set the data at the specified location
                //myRef.PutAsync(myData);
                //var result = firebaseClient.Child("users").PostAsync(myData);
                var key = firebaseClient.Child("records").PostAsync(myData);
                Toast.MakeText(this, "Message sent: " + et.Text, ToastLength.Short).Show();
                et.Text = "";

            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}