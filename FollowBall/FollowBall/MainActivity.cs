namespace FollowBall
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our custom view as the screen content
            SetContentView(new FollowBallView(this));
        }
    }
}