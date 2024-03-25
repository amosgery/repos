using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using static Android.Views.View;

namespace halfButton
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnClickListener
    {
        public void OnClick(View v)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            GradientDrawable gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight,
                new int[] { Resource.Color.red_color, Resource.Color.green_color });

            // Set the drawable as the background for the button
            // You can handle button click events or other functionality here
            Button halfRedHalfGreenButton = FindViewById<Button>(Resource.Id.halfRedHalfGreenButton);
            halfRedHalfGreenButton.SetBackgroundDrawable(gradientDrawable);
            halfRedHalfGreenButton.SetOnClickListener(this);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}