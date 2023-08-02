using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace surface_view
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnGame;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnGame = (Button)FindViewById(Resource.Id.myButton);
            btnGame.Click += BtnGame_Click;

        }


        void BtnGame_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(GameActivity));
            StartActivity(intent);

        }


    }
}