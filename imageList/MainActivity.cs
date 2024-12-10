
using Android.Graphics;

namespace imageList
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageView iv;
        LinearLayout main;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it

            loadPics(100);

        }
        public void loadPics(int num)
        {
            main = FindViewById<LinearLayout>(Resource.Id.l1);
            HorizontalScrollView hsv = new HorizontalScrollView(this);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.MatchParent);
            hsv.LayoutParameters = layoutParams;
            LinearLayout ll = new LinearLayout(this);
            ll.LayoutParameters = layoutParams;
            for (int i = 0; i < num; i++)
            {
                ImageView iv = new ImageView(this);
                LinearLayout.LayoutParams ivParams = new LinearLayout.LayoutParams(100, 150);
                ivParams.SetMargins(20, 0, 0, 0);
                iv.LayoutParameters = ivParams;
                int j = i % 9 + 1;
                int imageKey = Resources.GetIdentifier("astro" + j, "drawable", PackageName);
                iv.SetImageResource(imageKey);
                ll.AddView(iv);
                Bitmap bitmap = BitmapFactory.DecodeResource(Resources, imageKey);

            }
            hsv.AddView(ll);
            main.AddView(hsv);
        }
    }

}