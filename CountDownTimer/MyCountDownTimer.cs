using System;

namespace CountDownTimer
{
    using Android.OS;

    public class MyCountdownTimer : CountDownTimer
    {
        // Event handler for timer tick
        public event EventHandler<long> Tick;

        // Event handler for timer finish
        public event EventHandler Finish;

        public MyCountdownTimer(long millisInFuture, long countDownInterval)
            : base(millisInFuture, countDownInterval)
        {
        }

        public override void OnTick(long millisUntilFinished)
        {
            // Notify subscribers about timer tick
             Tick?.Invoke(this, millisUntilFinished);
        }

        public override void OnFinish()
        {
            // Notify subscribers about timer finish
            Finish?.Invoke(this, EventArgs.Empty);
        }
    }

}