using Android.App;
using Android.OS;
using Android.Views;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Android.Content;
using Android.Provider;
using Android.Graphics;
using Android.Media;
using System.Drawing;
using System.Collections.Generic;

namespace gallery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener
    {
        Button btnAdd;
        LinearLayout gallery;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            gallery = FindViewById<LinearLayout>(Resource.Id.gallery);
            btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            btnAdd.SetOnClickListener(this);
            loadPictures();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void OnClick(View v)
        {
            if (v == btnAdd)
            {
                // take a picture
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
                // add picture to gallery

            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 0)
            {
                Android.Graphics.Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
                HelperFile.writeFileToInternalStorage(this, bitmap, "image");
                loadPictures();

            }
        }

        public void loadPictures()
        { 
            gallery.RemoveAllViews();
            List<Android.Graphics.Bitmap> bitmaps = HelperFile.getAllFils(this);
            for (int i = 0; i < bitmaps.Count; i++) { 
                Android.Graphics.Bitmap bitmap = bitmaps[i];
                ImageView imageView = new ImageView(this);
                LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(100, 100);
                layoutParams.SetMargins(10, 10, 0, 0);
                imageView.SetImageBitmap(bitmap);
                gallery.AddView(imageView);
            }
        }
    }
}