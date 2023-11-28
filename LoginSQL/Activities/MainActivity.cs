// MainActivity.cs
using Android.App;
using Android.OS;
using Android.Widget;

namespace LoginSQL  
{
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText usernameEditText;
        private EditText passwordEditText;
        private Button loginButton, regButton;

        private DBHelper databaseHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login);

            usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);
            regButton = FindViewById<Button>(Resource.Id.registerButton);
            string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "yourDatabase.db3");
            databaseHelper = new DBHelper(dbPath);

            loginButton.Click += LoginButton_Click;
            regButton.Click += RegButton_Click;
        }

        private void RegButton_Click(object sender, System.EventArgs e)
        {
            string username = usernameEditText.Text;
            string password = passwordEditText.Text;

            if (databaseHelper.Add(username, password))
                Toast.MakeText(this, "Registration Successful", ToastLength.Short).Show();
            else
                Toast.MakeText(this, "Registration Failed", ToastLength.Short).Show();

        }

        private void LoginButton_Click(object sender, System.EventArgs e)
        {
            string username = usernameEditText.Text;
            string password = passwordEditText.Text;

            // Check if the entered credentials are valid
            bool isValid = databaseHelper.IsUserValid(username, password);

            if (isValid)
            {
                // Successful login, you can navigate to another activity or perform additional actions
                Toast.MakeText(this, "Login Successful", ToastLength.Short).Show();
            }
            else
            {
                // Invalid credentials
                Toast.MakeText(this, "Invalid Username or Password", ToastLength.Short).Show();
            }
        }
    }
}
