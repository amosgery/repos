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

    public class TextToSpeechHelper : Java.Lang.Object, TextToSpeech.IOnInitListener
    {
        private TextToSpeech textToSpeech;
        private Context context;

        public TextToSpeechHelper(Context context)
        {
            this.context = context;
            textToSpeech = new TextToSpeech(context, this);
        }

        public void OnInit(OperationResult status)
        {
            if (status == OperationResult.Success)
            {
                // Set language to Hebrew
                textToSpeech.SetLanguage(Java.Util.Locale.ForLanguageTag("he-IL"));
            }
            else
            {
                // Initialization failed
            }
        }

        public void Speak(string text)
        {
            if (textToSpeech.IsLanguageAvailable(Java.Util.Locale.ForLanguageTag("he-IL")) == LanguageAvailableResult.Available)
            {
                textToSpeech.Speak(text, QueueMode.Flush, null, null);
            }
            else
            {
                // Hebrew language not available
                textToSpeech.Speak(text, QueueMode.Flush, null, null);

            }
        }

        public void Shutdown()
        {
            textToSpeech.Stop();
            textToSpeech.Shutdown();
        }
    }

}
