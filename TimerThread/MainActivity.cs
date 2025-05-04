namespace TimerThread
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView tv;
        MyTimer myTimer;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.tv);
            tv.Click += Tv_Click;
        }

        private void Tv_Click(object? sender, EventArgs e)
        {
            if (myTimer == null)
            {
                myTimer = new MyTimer(this, tv);
                myTimer.StartTimer();
            }
            else
            {
                myTimer.StopTimer();
                myTimer = null;
            }
        }
    }

}