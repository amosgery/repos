using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content;

namespace questions
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, Android.Views.View.IOnClickListener
    {
        Button btnStart, btnSettings, btnMax;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnStart = FindViewById<Button>(Resource.Id.btnGame);
            btnStart.SetOnClickListener(this);
            btnSettings = FindViewById<Button>(Resource.Id.btnSettings);
            btnSettings.SetOnClickListener(this);
            btnMax = FindViewById<Button>(Resource.Id.btnMax);
            btnMax.SetOnClickListener(this);
        }
        public void OnClick(View v)
        {
            if (btnStart == v)
            {
                Intent intent = new Intent(this, typeof(QuestionActivity));
                StartActivityForResult(intent, 0);
            }
            else if (btnSettings == v)
            {
                Intent intent = new Intent(this, typeof(SettingsActivity));
                StartActivityForResult(intent, 1);
            }
            else if (btnMax == v)
            {
                Intent intent = new Intent(this, typeof(MaxScoreActivity));
                StartActivityForResult(intent, 2);
            }

        }
        // wait for the result from the other activity
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok)
            {
                if (requestCode == 0)
                    Toast.MakeText(this, "Game returned: " + data.GetStringExtra("result"), ToastLength.Long).Show();

                else if (requestCode == 1)
                {
                    Toast.MakeText(this, "Settings returned: " + data.GetStringExtra("result"), ToastLength.Long).Show();
                }
                else if (requestCode == 2)
                {
                    Toast.MakeText(this, "Max score returned: " + data.GetStringExtra("result"), ToastLength.Long).Show();
                }
            }
        }
    }
}