using Android.Content;
using Android.Graphics;
using Android.Provider;

namespace flowerML
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private const int CameraRequestCode = 1001;
        private InterpreterWrapper classifier;
        private ImageView imageView;
        private TextView resultText;
        private Java.IO.File imageFile;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            classifier = new InterpreterWrapper(Assets);

            imageView = FindViewById<ImageView>(Resource.Id.pic);
            resultText = FindViewById<TextView>(Resource.Id.res);
            var button = FindViewById<Button>(Resource.Id.picBtn);

            button.Click += (sender, e) => LaunchCamera();
        }

        private void LaunchCamera()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, CameraRequestCode);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == CameraRequestCode && resultCode == Result.Ok)
            {
                Bitmap bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");

                imageView.SetImageBitmap(bitmap);

                var result = classifier.Classify(bitmap);
                resultText.Text = $"Prediction: {result.label} ({result.confidence * 100:F1}%)";
            }
        }
    }
}