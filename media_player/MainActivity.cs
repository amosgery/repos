using System;
using Android.App;
using Android.Content;
using Android.Media;

using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace media_player
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer mp;
        SeekBar sb;
        AudioManager am;
        MediaController media_controller;
        VideoView video_view;
        Button btnStartMusic, btnStartVideo;
        Button btnStopVideo, btnStopMusic;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            sb = (SeekBar)FindViewById(Resource.Id.sb);

            am = (AudioManager)GetSystemService(Context.AudioService);
            int max = am.GetStreamMaxVolume(Stream.Music);
            sb.Max = max;
            am.SetStreamVolume(Stream.Music, max / 2, 0);
            sb.ProgressChanged += Sb_ProgressChanged;
            btnStartMusic = FindViewById<Button>(Resource.Id.btnStartMusic);
            btnStartVideo = FindViewById<Button>(Resource.Id.btnStartVideo);
            btnStopMusic = FindViewById<Button>(Resource.Id.btnStopMusic);
            btnStopVideo = FindViewById<Button>(Resource.Id.btnStopVideo);

            video_view = FindViewById<VideoView>(Resource.Id.videoview);

            var uri = Android.Net.Uri.Parse("http://www.ilemon.mobi/lessonZB-an10-fragmentsPart1.mp4");

            video_view.SetVideoURI(uri);

            media_controller = new Android.Widget.MediaController(this);

            media_controller.SetMediaPlayer(video_view);

            video_view.SetMediaController(media_controller);

            video_view.RequestFocus();

            btnStartVideo.Click += StartVideo;
            btnStartMusic.Click += StartMusic;
            btnStopVideo.Click += StopVideo;
            btnStopMusic.Click += StopMusic;
        }

        private void StopMusic(object sender, EventArgs e)
        {
            if (mp != null && mp.IsPlaying)
                mp.Stop();
        }

        private void StopVideo(object sender, EventArgs e)
        {
            video_view.StopPlayback();
        }

        private void StartMusic(object sender, EventArgs e)
        {
            if (mp == null || !mp.IsPlaying)
                mp = MediaPlayer.Create(this, Resource.Raw.bgmusic);
            mp.Start();
        }

        void StartVideo(object sender, System.EventArgs e)
        {
            video_view.Start();
        }
    

        void Sb_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            am.SetStreamVolume(Stream.Music, e.Progress, VolumeNotificationFlags.PlaySound);
        }


    }
}