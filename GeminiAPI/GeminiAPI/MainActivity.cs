using System.Text.Json;

namespace GeminiAPI
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText etext;
        Button btnSend;
        TextView etAnswer;

        GeminiClient client;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etext = FindViewById<EditText>(Resource.Id.prompt);
            etAnswer = FindViewById <TextView> (Resource.Id.answer);
            btnSend = FindViewById<Button>(Resource.Id.send);

            btnSend.Click += BtnSend_Click;

            client = new GeminiClient("AIzaSyDh0Me23bGkBvg28V52Cglu_LWMCPbsLIo");

        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            var result = await client.SendPromptAsync(etext.Text);

            var doc = JsonDocument.Parse(result);
            var answer = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            Console.WriteLine(answer);

            Toast.MakeText(this, answer, ToastLength.Long).Show();

            etAnswer.Text = answer;
        }
    }
}