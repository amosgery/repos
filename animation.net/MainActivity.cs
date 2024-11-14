using Android.Animation;
using Android.Views;
using Android.Views.Animations;

namespace animation.net
{
	[Activity(Label = "@string/app_name", MainLauncher = true)]
	public class MainActivity : Activity
	{
		TextView tv;
		float endX = 300f; // New end location for X
		float endY = 500f; // New end location for Y
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

			// Assuming `view` is the View you want to animate

			endX *= -1; // New end location for X
			endY *= -1; // New end location for Y

			ObjectAnimator animatorX = ObjectAnimator.OfFloat(tv, "translationX", endX);
			ObjectAnimator animatorY = ObjectAnimator.OfFloat(tv, "translationY", endY);

			// Optional: Set duration or interpolator
			animatorX.SetDuration(2000);
			animatorY.SetDuration(2000);
			animatorX.SetInterpolator(new AccelerateInterpolator());
			animatorY.SetInterpolator(new DecelerateInterpolator());

			animatorX.Start();
			animatorY.Start();
		}
	}
}