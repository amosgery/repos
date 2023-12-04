using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using Firebase.Database.Query;

namespace Firebase_auth
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnSave, btnSignin, btnSignup, btnSaveSignin, btnSaveSignup, btnSignout;
        EditText et, etPass, etEmail, etName;
        FirebaseClient firebaseClient;
        Dialog dialog;
        ListView lv;
        static String email, pwd, name;
        private Handler mainHandler;
        ListAdapter adapter;
        static List<dbItem> dbList { get; set; }
        User User;
        FirebaseAuthConfig Config;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnSignin = FindViewById<Button>(Resource.Id.btnSignin);
            btnSignup = FindViewById<Button>(Resource.Id.btnSignup);
            btnSignout = FindViewById<Button>(Resource.Id.btnSignout);

            et = FindViewById<EditText>(Resource.Id.et);
            lv = FindViewById<ListView>(Resource.Id.lv);
            mainHandler = new Handler(Looper.MainLooper);

            btnSave.Enabled = false;
            btnSignout.Enabled = false;
            btnSignin.Enabled = true;
            btnSignup.Enabled = true;
            btnSave.Click += btnSave_click;
            btnSignin.Click += btnSignin_click;
            btnSignup.Click += btnSignup_click;
            btnSignout.Click += btnSignout_click;
        }

        private void btnSignout_click(object sender, EventArgs e)
        {
            SignOut();
        }

        // not working  - not used
        private void subscribe()
        {
            if (firebaseClient == null)
                return;

            var reference = firebaseClient.Child("records");

            reference.AsObservable<MyDatabaseRecord>().Subscribe(data =>
            {
                Console.WriteLine(data.Object.MyProperty);
                if (data.Object != null)
                {
                    // New value inserted or existing value updated

                }
                mainHandler.Post(() =>  // This code will be executed on the main thread
                        ReadDataFromFirebase());
                
            });
        }
        private async void ReadDataFromFirebase()
        {

            try
            {
                // Get a reference to the database node
                var reference = firebaseClient.Child("records");
                int position = -1;
                var res = await reference.OnceAsync<MyDatabaseRecord>();

                dbList = new List<dbItem>();
                foreach (var record in res)
                {
                    dbItem item = new dbItem(record.Key, record.Object.MyProperty);
                    dbList.Add(item);

                }
                adapter = new ListAdapter(this, dbList);
                adapter.SetCangedPos(position);
                lv.Adapter = adapter;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the read operation
                Console.WriteLine("Error reading data: " + ex.Message);
                //Toast.MakeText(this, "Error reading data: " + ex.Message, ToastLength.Short).Show();
            }
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
                ReadDataFromFirebase();
                subscribe();
            }
        }

        private void btnSignin_click(object sender, EventArgs e)
        {
            createSigninDialog();
        }

        private void createSigninDialog()
        {

            dialog = new Dialog(this);

            dialog.SetContentView(Resource.Layout.signin_dialog);

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
                ReadDataFromFirebase();
                subscribe();
            }
        }

        private void btnSave_click(object sender, EventArgs e)
        {
            saveText();
        }

        private async void saveText()
        {
            try 
            { 

                var response = await firebaseClient.Child("records").PostAsync(new MyDatabaseRecord
                {
                    MyProperty = et.Text
                });

                Toast.MakeText(this, "saved: "+et.Text, ToastLength.Long).Show();
                //ReadDataFromFirebase();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
            }

        }


        private bool initFirebaseAuth(bool signup)
        {
            try
            {
                firebaseClient = new FirebaseClient(
                  "https://fir-auth-9bc62-default-rtdb.europe-west1.firebasedatabase.app/",
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
                ApiKey = "AIzaSyDnAZTfMd7HeHgxouZUw_aKxocHL52zQnI",
                AuthDomain = "fir-auth-9bc62.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    // Add and configure individual providers
                    new GoogleProvider().AddScopes("email"),
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

                        dialog.Dismiss();

                    }
                }
                else // signin
                {
                    userCredential = await client.SignInWithEmailAndPasswordAsync(email, pwd);
                    if (userCredential != null)
                    {
                        //Toast.MakeText(this, "User signed in", ToastLength.Long).Show();

                        dialog.Dismiss();


                    }
                }

            }
            catch (Exception ex)
            {
                var firebaseAuthHttpException = (Firebase.Auth.FirebaseAuthHttpException)ex;
                var errorMessage = firebaseAuthHttpException.Reason.ToString();
                //Toast.MakeText(this, errorMessage, ToastLength.Long).Show();
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
            btnSignup.Enabled = false;
            btnSignin.Enabled = false;
            btnSignout.Enabled = true;
            btnSave.Enabled = true;
            
            var token = await userCredential.User.GetIdTokenAsync();
            User = userCredential.User;
            Config = config;
            return token.ToString();
        }

        public void SignOut()
        {
            mainHandler.Dispose();
            var uid = this.User?.Uid;
            this.User = null;
            this.Config.UserManager.DeleteExistingUser(uid);
            firebaseClient.Dispose();
            btnSave.Enabled = false;
            btnSignout.Enabled = false;
            btnSignin.Enabled = true;
            btnSignup.Enabled = true;
            if (dbList != null)
                dbList.Clear();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}