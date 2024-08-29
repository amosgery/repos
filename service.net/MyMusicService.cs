using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using Android.OS;

namespace service.net
{

    [Service]
    public class BackgroundMusicService : Service
    {
        private MediaPlayer? mediaPlayer;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            // Initialize the MediaPlayer
            mediaPlayer = MediaPlayer.Create(this, Resource.Raw.bgmusic);
            mediaPlayer.Looping = true; // Set looping to true for continuous playback
            mediaPlayer.Start(); // Start playing the background music
            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            // Release the MediaPlayer when the service is destroyed
            if (mediaPlayer != null)
            {
                mediaPlayer.Stop();
                mediaPlayer.Release();
                mediaPlayer = null;
            }
            base.OnDestroy();
        }
    }
}
