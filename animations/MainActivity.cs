using System;
using Android.App;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;



namespace animations
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnFadeIn, btnFadeOut, btnTranslate, btnRotate, btnScale, btnSlideup, btnOffset;
        ImageView iv;
        //phase 1 - declare on animation object
        Animation animFadeIn, animFadeOut, animMove, animRotate, animScale, animSlideup, animOffset;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnFadeIn = (Button)FindViewById(Resource.Id.btnFadeIn);
            btnFadeOut = (Button)FindViewById(Resource.Id.btnFadeOut);
            btnTranslate = (Button)FindViewById(Resource.Id.btnTrans);
            btnRotate = (Button)FindViewById(Resource.Id.btnRotate);
            btnScale = (Button)FindViewById(Resource.Id.btnScale);
            btnSlideup = (Button)FindViewById(Resource.Id.btnSlideup);
            btnOffset = (Button)FindViewById(Resource.Id.btnOffset);
            iv = (ImageView)FindViewById(Resource.Id.ivRotate);
            btnFadeOut.Click += btnFadeOut_Click;
            btnFadeIn.Click += BtnFadeIn_Click;
            btnTranslate.Click += BtnTranslate_Click;
            btnRotate.Click += BtnRotate_Click;
            btnScale.Click += BtnScale_Click;
            btnSlideup.Click += BtnSlideup_Click;
            btnOffset.Click += BtnOffset_Click;
            //phase 2 - load xml animation
            animFadeIn = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_fadein);
            animFadeOut = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_fadeout);
            animMove = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_move);
            animRotate = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_rotate);
            animScale = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_scale);
            animSlideup = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_slideup);
            animOffset = AnimationUtils.LoadAnimation(this, Resource.Animation.anim_offset);
        }

        private void BtnOffset_Click(object sender, EventArgs e)
        {
            iv.StartAnimation(animOffset);
        }

        private void BtnSlideup_Click(object sender, EventArgs e)
        {
            iv.StartAnimation(animSlideup);
        }

        private void BtnScale_Click(object sender, EventArgs e)
        {
            iv.StartAnimation(animScale);
        }

        private void BtnRotate_Click(object sender, EventArgs e)
        {
            iv.StartAnimation(animRotate);
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            //btnTranslate.TranslationX = -100;
            btnTranslate.TranslationY = -50;
            
            animMove.Duration = 1000;
            
            animMove.Interpolator = new AccelerateDecelerateInterpolator();
            btnTranslate.StartAnimation(animMove);
        }

        private void btnFadeOut_Click(object sender, EventArgs e)
        {
            btnFadeOut.StartAnimation(animFadeOut);
        }

        void BtnFadeIn_Click(object sender, System.EventArgs e)
        {
            btnFadeIn.StartAnimation(animFadeIn);
        }
    }
}