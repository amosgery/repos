using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace questions
{
    [Activity(Label = "MaxScore")]
    public class MaxScoreActivity : Activity, View.IOnClickListener
    {
        TextView tvScore;
        Button btnClose;
        int max;

        public void OnClick(View v)
        {
            // return result
            Intent intent = new Intent();
            intent.PutExtra("result", max.ToString());
            SetResult(Result.Ok, intent);
            Finish();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.max_score);
            tvScore = FindViewById<TextView>(Resource.Id.tvScore);
            btnClose = FindViewById<Button>(Resource.Id.btnClose);
            btnClose.SetOnClickListener(this);
            ISharedPreferences sp = GetSharedPreferences("triv", 0);
            max = sp.GetInt("points", 0);
            tvScore.Text = "Your Highest Score: " + max.ToString();
            // Create your application here
        }
    }
}