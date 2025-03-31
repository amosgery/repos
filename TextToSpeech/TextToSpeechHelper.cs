using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeech
{
    using Android.Speech.Tts;
    using Android.Content;
    using Android.OS;
    using Java.Util;

    public class TextToSpeechHelper : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        private TextToSpeech textToSpeech;
        private Context context;

        public TextToSpeechHelper(Context context)
        {
            this.context = context;
            textToSpeech = new TextToSpeech(context, this, "com.google.android.tts");

        }

        public void OnInit(OperationResult status)
        {
            //var availableLanguages = textToSpeech.AvailableLanguages;

            if (status == OperationResult.Success)
            {
                // Set language to Hebrew
                //textToSpeech.SetLanguage(Java.Util.Locale.ForLanguageTag("he-IL"));
            }
            else
            {

                // Initialization failed
            }
        }

        public void Speak(string text)
        {
               textToSpeech.Speak(text, QueueMode.Flush, null, null);
        }

        public void Shutdown()
        {
            textToSpeech.Stop();
            textToSpeech.Shutdown();
        }

        internal List<string> GetLanguageList()
        {
            List<string> availableLanguagesList = new List<string>();
            var availableLanguages = textToSpeech.AvailableLanguages;


            foreach (Voice voice in textToSpeech.Voices)
            {
                Locale locale = voice.Locale;
                
                availableLanguagesList.Add($"{locale.DisplayName} ({locale.Language}-{locale.Country})");
            }

            return availableLanguagesList;
        }
    }

}
