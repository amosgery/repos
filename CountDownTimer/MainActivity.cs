using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace CountDownTimer
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView countdownTextView;
        private MyCountdownTimer countdownTimer;
        Button Start;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            countdownTimer = new MyCountdownTimer(10000, 1000); // 60 seconds countdown

            countdownTextView = FindViewById<TextView>(Resource.Id.countdownTextView);
            Start = FindViewById<Button>(Resource.Id.buttonStart);
            // Create and start the countdown timer
            countdownTimer.Tick += CountdownTimer_OnTick;
            countdownTimer.Finish += CountdownTimer_Finish;
            Start.Click += OnStartTimer;
        }

        private void CountdownTimer_Finish(object sender, EventArgs e)
        {
            // Countdown timer has finished
            countdownTextView.Text = "Countdown finished!";
        }

        private void OnStartTimer(object sender, EventArgs e)
        {
            countdownTimer.Start();
        }

        private void CountdownTimer_OnTick(object sender, long millisUntilFinished)
        {
            // Update the TextView with the remaining time
            countdownTextView.Text = "Time remaining: " + millisUntilFinished / 1000 + " seconds";
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // Stop the countdown timer to avoid memory leaks
            countdownTimer?.Cancel();
        }
    }
}