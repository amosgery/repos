using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerThread
{
    internal class MyTimer(Activity context, TextView tv)
    {
        TextView textView = tv;
        Activity activity = context;
        private Thread _timerThread;
        private bool _isRunning = false;
        int counter = 0;

        public void StartTimer()
        {
            _isRunning = true;

            _timerThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    // Do your timed work
                    Console.WriteLine("Tick: " + DateTime.Now);
                    activity.RunOnUiThread(() =>
                    {
                        textView.Text = counter++.ToString();
                    });
                       // Sleep for 1 second
                        Thread.Sleep(1000);
                }
            });

            _timerThread.IsBackground = true;
            _timerThread.Start();
        }

        public void StopTimer()
        {
            _isRunning = false;

            if (_timerThread != null && _timerThread.IsAlive)
            {
                _timerThread.Join(); // Optional: wait for thread to finish
                _timerThread = null;
            }
        }

    }
}
