using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MusicService
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button Start, Stop;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Start = FindViewById<Button>(Resource.Id.start);
            Stop = FindViewById<Button>(Resource.Id.stop);
            Start.Click += Start_Click;
            Stop.Click += Stop_Click;
        }

        private void Stop_Click(object sender, System.EventArgs e)
        {
            StopService(new Intent(this, typeof(BackgroundMusicService)));
        }

        private void Start_Click(object sender, System.EventArgs e)
        {
            StartService(new Intent(this, typeof(BackgroundMusicService)));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}