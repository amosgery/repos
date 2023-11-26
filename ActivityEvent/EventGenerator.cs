using System;
using System.Timers;

namespace ActivityEvent
{
    public class EventGenerator
    {
        // Define an event
        public event EventHandler DataUpdated;
        Timer timer;
        int seconds;
        public EventGenerator()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimerElapsed;

            // Start the timer
            timer.Start();
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            seconds++;
            OnDataUpdated();
        }

        // Method that triggers the event
        private void OnDataUpdated()
        {
            CustomEventArgs eventArgs = new CustomEventArgs(seconds);
            DataUpdated?.Invoke(this, eventArgs);
        }

    }

}
