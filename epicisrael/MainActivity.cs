using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using Firebase.Database;
using System;
using Firebase.Database.Query;
using Android.Views;
using Android.Text;
using Java.Util;

namespace epicisrael
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
   public class MainActivity : AppCompatActivity
    {
        const string ADMIN = "admin@epicisrael.com";

        Button btnSave, btnSignin, btnSignup, btnSaveSignin, btnSaveSignup, btnSignout, btnCheck;
        EditText et, etPass, etEmail, etName;
        TextView tv;
        FirebaseClient firebaseClient;
        Dialog dialog;
        static String email, pwd, name;
        ImageView iv;
        User User;
        FirebaseAuthConfig Config;
        dbItem[] dateTime;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnCheck = FindViewById<Button>(Resource.Id.btnCheck);
            btnSignin = FindViewById<Button>(Resource.Id.btnSignin);
            btnSignup = FindViewById<Button>(Resource.Id.btnSignup);
            btnSignout = FindViewById<Button>(Resource.Id.btnSignout);

            et = FindViewById<EditText>(Resource.Id.et);
            tv = FindViewById<TextView>(Resource.Id.tv);
            iv = FindViewById<ImageView>(Resource.Id.iv);
            btnSave.Enabled = false;
            btnCheck.Enabled = false;
            btnSignout.Enabled = false;
            btnSignin.Enabled = true;
            btnSignup.Enabled = false;
            btnSave.Click += btnSave_click;
            btnSignin.Click += btnSignin_click;
            btnSignup.Click += btnSignup_click;
            btnSignout.Click += btnSignout_click;
            btnCheck.Click += btnCheck_click;
            iv.Visibility = ViewStates.Invisible;
            et.Enabled = false;
            et.TextChanged += EditText_TextChanged;

            // auto login
            /*
            email = "amos@epicisrael.com";
            pwd = "cyclist1";
            if (!initFirebaseAuth(false))
                Toast.MakeText(this, "Init Failed !" + et.Text, ToastLength.Long).Show();
            */
        }

        private void EditText_TextChanged(object sender, TextChangedEventArgs e)
        {
            iv.Visibility = ViewStates.Invisible;
            if (et.Text.Contains("."))
            {
                string st = et.Text.Replace('.', '-');
                et.Text = st;
                et.SetSelection(et.Text.Length);

            }
        }

        private void btnCheck_click(object sender, EventArgs e)
        {
            CheckNumber();
        }


        private void btnSignout_click(object sender, EventArgs e)
        {
            SignOut();
        }


        private void btnSignup_click(object sender, EventArgs e)
        {
            CreateSignupDialog();
        }

        private void CreateSignupDialog()
        {

            dialog = new Dialog(this);

            dialog.SetContentView(Resource.Layout.signup_dialog);

            dialog.SetTitle("Sign up");

            dialog.SetCancelable(true);

            etPass = dialog.FindViewById<EditText>(Resource.Id.etPassword);
            etEmail = dialog.FindViewById<EditText>(Resource.Id.etEmail);

            etName = dialog.FindViewById<EditText>(Resource.Id.etName);

            btnSaveSignup = dialog.FindViewById<Button>(Resource.Id.btnSave);

            btnSaveSignup.Click += BtnSaveSignup_Click;

            dialog.Show();
        }

        private void BtnSaveSignup_Click(object sender, EventArgs e)
        {
            email = etEmail.Text;
            pwd = etPass.Text;
            name = etName.Text;
            if (initFirebaseAuth(true))
            {
                et.Text = "";

            }
        }

        private void btnSignin_click(object sender, EventArgs e)
        {
            createSigninDialog();
        }

        private void createSigninDialog()
        {

            dialog = new Dialog(this);

            dialog.SetContentView(Resource.Layout.Signin_dialog);

            dialog.SetTitle("Sign in");

            dialog.SetCancelable(true);

            etPass = dialog.FindViewById<EditText>(Resource.Id.etPassword);
            etEmail = dialog.FindViewById<EditText>(Resource.Id.etEmail);

            btnSaveSignin = dialog.FindViewById<Button>(Resource.Id.btnSave);

            btnSaveSignin.Click += BtnSaveSignin_Click;

            dialog.Show();
        }

        private void BtnSaveSignin_Click(object sender, EventArgs e)
        {
            email = etEmail.Text;
            pwd = etPass.Text;
            if (initFirebaseAuth(false))
            {
                et.Text = "";
            }
        }

        private void btnSave_click(object sender, EventArgs e)
        {
            saveNumber();
        }

        // insert a new number 
        private async void saveNumber()
        {
            try
            {
                string number = et.Text;
                await ReadValueForNumber(number);
                if (dateTime[0] != null)
                {
                    // number already exists
                    RaiseNumberAlreayExists(number);
                    return;
                }
                var response = await firebaseClient.Child("0").Child(number).PostAsync<dbItem>(new dbItem { }) ;
                SetVIcon();
                Toast.MakeText(this, "נשמר: " + et.Text, ToastLength.Short).Show();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private void RaiseNumberAlreayExists(string number)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle("Error");
            builder.SetMessage("המספר " + number + "  כבר קיים במערכת");
            builder.SetPositiveButton("OK", (sender, e) => { });
            builder.Show();
            SetNoEntry();
        }

        private async void CheckNumber()
        {
            try
            {
                int position;
                string number = et.Text;
                await ReadValueForNumber(number);
                if (dateTime[0] == null)
                {
                    RaiseNotRegisteredAlert(number);
                    return;
                }
                if ((position=DateExist(number)) >= 0)
                    RaiseDateAlreadyUsed(number, position);
                else
                    UpdateNumber(number);

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

        }

        private void RaiseDateAlreadyUsed(string number, int position)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle("Error");
            builder.SetMessage("המספר " + number + "  כבר נכנס היום בשעה " + dateTime[position].Time);
            builder.SetPositiveButton("OK", (sender, e) => { });
            builder.Show();
            SetNoEntry();

        }

        private void SetNoEntry()
        {
            iv.Visibility = ViewStates.Visible;
            iv.SetImageResource(Resource.Drawable.noentry);
        }

        private int DateExist(string number)
        {
            int position = 0;
            DateTime currentDate = DateTime.Now.Date;
            string date = currentDate.ToShortDateString();
            foreach (var record in dateTime)
            {
                if (dateTime[position] == null)
                    return -1;
                if (dateTime[position].Date == date)
                    return position;
                position++;
            }
            return -1;
        }

        // update dates for a number
        private async void UpdateNumber(string number)
        {
            try
            {
                dbItem item = new dbItem();
                var response = await firebaseClient.Child("0").Child(number).PostAsync<dbItem>(item);
                Toast.MakeText(this, "נרשם: " + et.Text, ToastLength.Short).Show();
                SetVIcon();
                await ScheduleMethodAsync();

            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }
        }

        private async Task ScheduleMethodAsync()
        {
            await Task.Delay(1000);
            et.Text = string.Empty;

        }

        private void SetVIcon()
        {
            iv.Visibility = ViewStates.Visible;
            iv.SetImageResource(Resource.Drawable.good);
        }

        private void RaiseNotRegisteredAlert(string number)
        {
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle("Error");
            builder.SetMessage("המספר " + number + " אינו רשום במערכת");
            builder.SetPositiveButton("OK", (sender, e) => { });
            builder.Show();
            SetNoEntry();
        }

        private async Task ReadValueForNumber(string number)
        {
            // Read a specific value from the database
            try
            {
                dateTime = null;
                // Get a reference to the database node
                var reference = firebaseClient.Child("0").Child(number);
                int position = 0;
                var res = await reference.OnceAsync<dbItem>();
                dateTime = new dbItem[res.Count+1];
                foreach (var record in res)
                {
                    dateTime[position] = new dbItem(record.Object);
                    position++;
  
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the read operation
                Console.WriteLine("Error reading data: " + ex.Message);
                //Toast.MakeText(this, "Error reading data: " + ex.Message, ToastLength.Short).Show();
            }

        }


        private bool initFirebaseAuth(bool signup)
        {
            try
            {
                firebaseClient = new FirebaseClient(
                  "https://epicisrael-8216d-default-rtdb.europe-west1.firebasedatabase.app/",
                  new FirebaseOptions
                  {
                      AuthTokenAsyncFactory = () => LoginAsync(false)
                  });
                return LoginAsync(signup) != null;
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                return false;
            }

        }

        public async Task<string> LoginAsync(bool signup)
        {
            // Configure...
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyBzIihNGv8eYmqJVdynDx2Rx6DxfgkLta4",
                AuthDomain = "epicisrael-8216d.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    // Add and configure individual providers
                    //new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                    // ...
                },
                // WPF:
                UserRepository = new FileUserRepository("FirebaseSample") // persist data into %AppData%\FirebaseSample

            };
            UserCredential userCredential = null;
            try
            {
                // ...and create your FirebaseAuthClient
                var client = new FirebaseAuthClient(config);
                // anonymous sign in
                // var user = await client.SignInAnonymouslyAsync();

                // sign up using google provider
                // var user = await client.SignInWithProviderAsync(new GoogleProvider());

                if (signup)
                {
                    userCredential = await client.CreateUserWithEmailAndPasswordAsync(email, pwd, name);
                    if (userCredential != null)
                    {
                        //Toast.MakeText(this, "User created", ToastLength.Long).Show();

                    }
                }
                else // signin
                {
                    userCredential = await client.SignInWithEmailAndPasswordAsync(email, pwd);
                    if (userCredential != null)
                    {
                        //Toast.MakeText(this, "User signed in", ToastLength.Long).Show();

                    }
                }

            }
            catch (Exception ex)
            {
                FirebaseAuthHttpException exception = ex as FirebaseAuthHttpException;
                string errorMessage = ex.Message;
                if (ex.GetType() == exception.GetType())
                {
                    errorMessage = exception.Reason.ToString() + " :תקלה בחיבור לדטהבייס";
                }
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetTitle("Error");
                builder.SetMessage(errorMessage);
                builder.SetPositiveButton("OK", (sender, e) => { });
                builder.Show();


                Console.WriteLine(ex.Message);
                SignOut();
                return null;
            }
            if (userCredential == null)
            {
                SignOut();
                return null;
            }
            // successful login
            SigninSuccess();


            var token = await userCredential.User.GetIdTokenAsync();
            User = userCredential.User;
            Config = config;
            return token.ToString();
        }

        private void SigninSuccess()
        {
            if (email == ADMIN)
            {
                btnSave.Enabled = true;
                btnSignup.Enabled = true;

            }
            else
            {
                btnSave.Enabled = false;
                btnSignup.Enabled = false;

            }
            btnSignin.Enabled = false;
            btnSignout.Enabled = true;
            btnCheck.Enabled = true;
            tv.Text = "User: " + email;
            et.Enabled = true;
            iv.Visibility = ViewStates.Invisible;
            dialog.Dismiss();
        }

        public void SignOut()
        {
            var uid = this.User?.Uid;
            this.User = null;
            this.Config.UserManager.DeleteExistingUser(uid);
            firebaseClient.Dispose();
            btnSave.Enabled = false;
            btnSignout.Enabled = false;
            btnSignin.Enabled = true;
            btnCheck.Enabled = false;
            btnSignup.Enabled = false;
            iv.Visibility = ViewStates.Invisible;
            et.Enabled = false;
            et.Text = "";
            tv.Text = "";
            email = "";
            pwd = "";
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}