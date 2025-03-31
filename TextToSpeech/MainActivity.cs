using Android.Content;
using Android.Speech.Tts;
using Android.Widget;
using Java.Util;

namespace TextToSpeech
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button saybtn, langBtn;
        EditText et;
        TextToSpeechHelper texttospeech;
        string selectedLang;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            saybtn = FindViewById<Button>(Resource.Id.btn);
            et = FindViewById<EditText>(Resource.Id.et);

            langBtn = FindViewById<Button>(Resource.Id.Langbtn);
            langBtn.Click += LangBtn_Click;
            saybtn.Click += OnClick;
            texttospeech = new TextToSpeechHelper(this);

        }

        private void LangBtn_Click(object? sender, EventArgs e)
        {
            Intent intent = new Intent();
            intent.SetAction("com.android.settings.TTS_SETTINGS");
            StartActivityForResult(intent, 0);
        }



        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 0)
            {
                // Re-initialize TTS to get the new language
                texttospeech = new TextToSpeechHelper(this);
            }
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