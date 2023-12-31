﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace downloadAsync
{
    [Activity(Label = "AsyncImageAndroid", MainLauncher = true,

               ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation)]

    public class MainActivity : Activity
    {
        int count = 1;
        WebClient webClient;
        Button downloadButton;
        Button clickButton;
        TextView infoLabel;
        ImageView imageview;
        ProgressBar downloadProgress;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            this.downloadButton = FindViewById<Button>(Resource.Id.downloadButton);
            this.clickButton = FindViewById<Button>(Resource.Id.clickButton);
            this.infoLabel = FindViewById<TextView>(Resource.Id.textView1);
            this.imageview = FindViewById<ImageView>(Resource.Id.imageView1);
            this.downloadProgress = FindViewById<ProgressBar>(Resource.Id.progressBar);

            downloadButton.Click += downloadAsync;
            clickButton.Click += delegate {
                clickButton.Text = string.Format("{0} clicks!", count++);
            };
        }

        async void downloadAsync(object sender, System.EventArgs ea)
        {
            webClient = new WebClient();
            var url = new Uri("https://lh3.googleusercontent.com/pw/AIL4fc_mCeFLa5qs5RaSg8ywBN0_UTAhrG3EDsCCK_B1ioYTAds5NUhiNWY6t0tijsriaDi67v7lsxbM-iOmZfxS0YVgfrsz2DDpUb_LZcJDnt5d_cr-CpuVc6RVTSU3nmtiomlM_TvF3btQTYbuUVxeDTla5A=w1920-h887-s-no");
            byte[] bytes = null;

            webClient.DownloadProgressChanged += HandleDownloadProgressChanged;
            imageview.SetImageBitmap(null);
            this.downloadButton.Text = "Cancel";
            this.downloadButton.Click -= downloadAsync;
            this.downloadButton.Click += cancelDownload;
            infoLabel.Text = "Downloading...";
            try
            {
                bytes = await webClient.DownloadDataTaskAsync(url);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task Canceled!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                infoLabel.Text = "Click Dowload button to download the image";

                this.downloadButton.Click -= cancelDownload;
                this.downloadButton.Click += downloadAsync;
                this.downloadButton.Text = "Download";
                this.downloadProgress.Progress = 0;
                return;
            }
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string localFilename = "downloaded.png";
            string localPath = System.IO.Path.Combine(documentsPath, localFilename);
            infoLabel.Text = "Download Complete";
            //Save the Image using writeAsync
            FileStream fs = new FileStream(localPath, FileMode.OpenOrCreate);
            await fs.WriteAsync(bytes, 0, bytes.Length);
            Console.WriteLine("localPath:" + localPath);
            fs.Close();

            infoLabel.Text = "Resizing Image...";
            BitmapFactory.Options options = new BitmapFactory.Options();
            options.InJustDecodeBounds = true;
            await BitmapFactory.DecodeFileAsync(localPath, options);

            options.InSampleSize = options.OutWidth > options.OutHeight ? options.OutHeight / imageview.Height : options.OutWidth / imageview.Width;
            options.InJustDecodeBounds = false;
            Bitmap bitmap = await BitmapFactory.DecodeFileAsync(localPath, options);
            Console.WriteLine("Loaded!");
            imageview.SetImageBitmap(bitmap);
            infoLabel.Text = "Click Dowload button to download the image";
            this.downloadButton.Click -= cancelDownload;
            this.downloadButton.Click += downloadAsync;
            this.downloadButton.Text = "Download";
            this.downloadProgress.Progress = 0;
        }

        void HandleDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.downloadProgress.Progress = e.ProgressPercentage;
        }
        void cancelDownload(object sender, System.EventArgs ea)
        {
            Console.WriteLine("Cancel clicked!");
            if (webClient != null)
                webClient.CancelAsync();
            webClient.DownloadProgressChanged -= HandleDownloadProgressChanged;
            this.downloadButton.Click -= cancelDownload;
            this.downloadButton.Click += downloadAsync;
            this.downloadButton.Text = "Download";
            this.downloadProgress.Progress = 0;
            imageview.SetImageBitmap(null);
            infoLabel.Text = "Click Download button to download the image";
        }
    }
}