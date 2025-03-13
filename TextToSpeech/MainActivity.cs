using Android.Content;
using Android.Speech.Tts;

namespace TextToSpeech
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button saybtn;
        EditText et;
        TextToSpeechHelper texttospeech;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            saybtn = FindViewById<Button>(Resource.Id.btn);
            et = FindViewById<EditText>(Resource.Id.et);
            saybtn.Click += OnClick;
            texttospeech = new TextToSpeechHelper(this);
        }

        private void OnClick(object? sender, EventArgs e)
        {
            texttospeech.Speak(et.Text);
        }

        protected override void OnDestroy()
        {

            texttospeech.Shutdown();
            base.OnDestroy();
        }
    }
}