using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace questions
{
    [Activity(Label = "Settings")]
    public class SettingsActivity : Activity, View.IOnClickListener
    {
        RadioButton radioOn, radioOff;
        static MediaPlayer mp=null;
        public void OnClick(View v)
        {
            ISharedPreferences sp = GetSharedPreferences("triv", 0);
            ISharedPreferencesEditor editor = sp.Edit();
            if (mp == null || !mp.IsPlaying)
                mp = MediaPlayer.Create(this, Resource.Raw.bgmusic);
            String sound = "";
            if (radioOn == v)
            {
                // return intent
                this.FinishActivity(1);
                sound = "Sound On";
                Toast.MakeText(this, "Sound On", ToastLength.Long).Show();
                if (!mp.IsPlaying)
                    mp.Start();
            }
            else if (radioOff == v)
            {
                this.FinishActivity(0);
                sound = "Sound Off";
                if (mp.IsPlaying)
                    mp.Stop();
                Toast.MakeText(this, "Sound Off", ToastLength.Long).Show();
            }
            editor.PutString("Sound", sound);
            editor.Commit();
            Intent intent = new Intent();
            intent.PutExtra("result", sound);
            SetResult(Result.Ok, intent);
            Finish();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ISharedPreferences sp = GetSharedPreferences("triv", 0);
            String sound ="";

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings);
            radioOff = FindViewById<RadioButton>(Resource.Id.radioOff);
            radioOn = FindViewById<RadioButton>(Resource.Id.radioOn);
            radioOff.SetOnClickListener(this);
            radioOn.SetOnClickListener(this);
            sp = GetSharedPreferences("triv", 0);
            sound = sp.GetString("Sound", "");
            if (sound == "Sound On")
            {
                radioOn.Checked = true;
            }
            else if (sound == "Sound Off")
            {
                radioOff.Checked = true;
            }

        }
    }
}