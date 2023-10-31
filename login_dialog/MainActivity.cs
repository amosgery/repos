using Android;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using System;
using Android.Views;

namespace login_dialog

{

    [Activity(Label = "login_dialog", MainLauncher = true)]

    public class MainActivity : Activity, View.IOnClickListener
    {
        ISharedPreferences sp;
        Dialog d;
        EditText etUserName;
        EditText etPass;
        Button btnCustomLogin;
        Button btnLogin, btnAlert, btnProgress, btnDate, btnTime;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnAlert = FindViewById<Button>(Resource.Id.btnAlert);
            btnProgress = FindViewById<Button>(Resource.Id.btnProgress);
            btnDate = FindViewById<Button>(Resource.Id.btnDate);
            btnTime = FindViewById<Button>(Resource.Id.btnTime);
            btnTime.SetOnClickListener(this);
            btnDate.SetOnClickListener(this);
            btnLogin.SetOnClickListener(this);
            btnAlert.SetOnClickListener(this);
            btnProgress.SetOnClickListener(this);
            sp = GetSharedPreferences("details", Android.Content.FileCreationMode.Private);
        }

        public void OnClick(View view)
        {
            if (view == btnLogin)
            {
                createLoginDialog();
            }
            else if (view == btnCustomLogin)
            {
                ISharedPreferencesEditor editor = sp.Edit();
                editor.PutString("username", etUserName.Text);
                editor.PutString("pass", etPass.Text);
                editor.Commit();
                d.Dismiss();
                Toast.MakeText(this, "username " + etUserName.Text + " saved", ToastLength.Long).Show();
            }
            else if (view == btnAlert)
            {
                createAlertDialog();
            }
            else if (view == btnProgress)
            {
                createProgressDialog();
            }
            else if (view == btnDate)
            {
                createDateDialog();
            }
            else if (view == btnTime)
            {
                createTimeDialog();
            }
        }

        private void createTimeDialog()
        {
            DateTime today = DateTime.Today;
            TimePickerDialog timePickerDialog = new TimePickerDialog(this, OnTimeSet, today.Hour, today.Minute, true);
            timePickerDialog.Show(); ;
        }
        void OnTimeSet(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            String str = e.HourOfDay + ":" + e.Minute;
            Toast.MakeText(this, str, ToastLength.Long).Show();
            btnTime.Text = str;
        }

        private void createDateDialog()
        {
                DateTime today = DateTime.Today;
                DatePickerDialog datePickerDialog = new DatePickerDialog(this, OnDateSet, today.Year, today.Month - 1, today.Day);
                datePickerDialog.Show();
        }

        void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            String str = e.Date.ToLongDateString();
            Toast.MakeText(this, str, ToastLength.Long).Show();
            btnDate.Text = str;
        }
        private void createProgressDialog()
        {
            ProgressDialog p = ProgressDialog.Show(this, "Progress dialog", "Loading please wait...", true);
            p.SetCancelable(true);
            p.SetProgressStyle(ProgressDialogStyle.Horizontal);
            p.SetMessage("Loading...");
            p.Show();
        }

        private void createAlertDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetTitle("התרעה");
            builder.SetMessage(" ? לסיים את האפליקציה");
            builder.SetCancelable(true);
            builder.SetPositiveButton("כן", OkAction);
            builder.SetNegativeButton("לא", CancelAction);
            AlertDialog dialog = builder.Create();
            dialog.Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "OK clicked", ToastLength.Long).Show();
            Finish();
        }

        private void CancelAction(object sender, DialogClickEventArgs e)
        {
            Toast.MakeText(this, "Cancel clicked", ToastLength.Long).Show();
        }

        public void createLoginDialog()
        {
            //connect to sp
            string strname = sp.GetString("username", null);
            string strpass = sp.GetString("pass", null);
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.login);
            d.SetTitle("Reset");
            d.SetCancelable(true);
            etPass = d.FindViewById<EditText>(Resource.Id.etPassword);
            etUserName = d.FindViewById<EditText>(Resource.Id.etUserName);
            btnCustomLogin = d.FindViewById<Button>(Resource.Id.btnDialogLogin);
            if (strname != null && strpass != null)
            {
                etUserName.Text = strname;
                etPass.Text = strpass;
            }
            btnCustomLogin.SetOnClickListener(this);
            d.Show();
        }
    }
}