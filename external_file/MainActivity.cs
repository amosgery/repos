using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

using AndroidX.AppCompat.App;
using System;

namespace external_file
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, View.IOnClickListener, View.IOnLongClickListener
    {
        ImageView iv;
        TextView tv;
        LinearLayout linearLayout;
        bool mExternalStorageAvailable = false;
        bool mExternalStorageWriteable = false;
        Button btnTakePic, btnCancel, btnDelete;
        ImageButton btnimg;
        InfoImage infoImage;
        Dialog d;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            // Get our button from the layout resource,
            // and attach an event to it
            btnTakePic = FindViewById<Button>(Resource.Id.btnTakePic);
            btnTakePic.SetOnClickListener(this);
            iv = FindViewById<ImageView>(Resource.Id.iv);
            tv = FindViewById<TextView>(Resource.Id.tvPathFile);

            linearLayout = FindViewById<LinearLayout>(Resource.Id.gallery);
            SetPermissios();
            getAllFile2();
        }

        public void getAllFile()
        {
            string root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString();
            Java.IO.File myDir = new Java.IO.File(root + "/saved_images");
            if (myDir.IsDirectory)
            {
                String[] dirList = myDir.List();
                for (int i = 0; i < dirList.Length; i++)
                {
                    Java.IO.File file = new Java.IO.File(myDir, dirList[i]);
                    Bitmap tmp = BitmapFactory.DecodeFile(file.AbsolutePath);
                    btnimg = new ImageButton(this);
                    btnimg.SetOnClickListener(this);
                    btnimg.Tag = tmp;
                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(100, 100);
                    btnimg.SetImageBitmap(tmp);
                    linearLayout.AddView(btnimg);
                }
            }
        }

        public void getAllFile2()
        {
            string root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString();
            Java.IO.File myDir = new Java.IO.File(root + "/saved_images");
            if (myDir.IsDirectory)
            {
                String[] dirList = myDir.List();
                linearLayout.RemoveAllViews();
                for (int i = 0; i < dirList.Length; i++)
                {
                    Java.IO.File file = new Java.IO.File(myDir, dirList[i]);
                    Bitmap tmp = BitmapFactory.DecodeFile(file.AbsolutePath);
                    btnimg = new ImageButton(this);
                    btnimg.SetOnClickListener(this);
                    btnimg.SetOnLongClickListener(this);
                    infoImage = new InfoImage(file, tmp);
                    btnimg.Tag = infoImage;
                    LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(100, 100);
                    btnimg.SetImageBitmap(tmp);
                    linearLayout.AddView(btnimg);
                }
            }
        }
        public void SetPermissios()
        {
            string state = Android.OS.Environment.ExternalStorageState;
            if (Android.OS.Environment.MediaMounted.Equals(state))
            {
                //We can read and write the media
                mExternalStorageAvailable = mExternalStorageWriteable = true;
                Toast.MakeText(this, "We can read and write the media", ToastLength.Long).Show();
            }
            else if (Android.OS.Environment.MediaMountedReadOnly.Equals(state))
            {
                //We can only read the media
                mExternalStorageAvailable = true;
                mExternalStorageWriteable = false;
                Toast.MakeText(this, "We can only read the media", ToastLength.Long).Show();
            }
            else
            {
                //Something else is wrong. we can neither read nor write
                mExternalStorageAvailable = mExternalStorageWriteable = false;
                Toast.MakeText(this, "Something else is wrong. we can neither read nor write", ToastLength.Long).Show();
            }
        }
        public void OnClick(View v)
        {
            if (btnTakePic == v)
            {
                Intent intent = new Intent(Android.Provider.MediaStore.ActionImageCapture);
                StartActivityForResult(intent, 0);
            }
            else if (v == btnimg)
            {
                infoImage = (InfoImage)v.Tag;
                iv.SetImageBitmap(infoImage.getBitmap());
            }
            else
            {
                infoImage = (InfoImage)v.Tag;
                if (v == btnCancel)
                {
                    Toast.MakeText(this, "user cancel", ToastLength.Long).Show();
                    d.Dismiss();
                }
                else if (v == btnDelete)
                {
                    deleteFromExternalStorage_v1(infoImage.getFile());
                }
                else
                {
                    infoImage = (InfoImage)v.Tag;
                    iv.SetImageBitmap(infoImage.getBitmap());
                    tv.Text = infoImage.getFile().Path;
                }
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)//coming from camera
            {
                if (resultCode == Result.Ok)
                {
                    Android.Graphics.Bitmap bitmap = (Bitmap)data.Extras.Get("data");
                    iv.SetImageBitmap(bitmap);
                    SaveImageToExternalStorage_version1(bitmap);
                    getAllFile2();
                }
            }
        }
        private void SaveImageToExternalStorage_version1(Bitmap finalBitmap)
        {
            string root = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).ToString();
            Java.IO.File myDir = new Java.IO.File(root + "/saved_images");
            myDir.Mkdirs();

            Random generator = new Random();
            int n = 10000;
            n = generator.Next(n);
            String fname = "Image-" + n + ".jpg";

            Java.IO.File file = new Java.IO.File(myDir, fname);
            if (file.Exists())
                file.Delete();
            try
            {
                string path = System.IO.Path.Combine(myDir.AbsolutePath, fname);
                var fs = new FileStream(path, FileMode.Create);
                if (fs != null)
                {
                    finalBitmap.Compress(Bitmap.CompressFormat.Png, 90, fs);
                    tv.Text = path;
                }
                fs.Flush();
                fs.Close();
            }
            catch (Exception e)
            {
                tv.Text = e.ToString();
                Toast.MakeText(this, e.ToString(), ToastLength.Long).Show();

            }
        }

        public void createDialog(InfoImage infoImage)
        {
            d = new Dialog(this);
            d.SetContentView(Resource.Layout.dialog);
            TextView dialogTV = d.FindViewById<TextView>(Resource.Id.dialogTv);
            dialogTV.Text = "are you sure you want to delete this file?";
            btnCancel = d.FindViewById<Button>(Resource.Id.btnCancel);
            btnCancel.SetOnClickListener(this);
            btnDelete = d.FindViewById<Button>(Resource.Id.btnDelete);
            btnDelete.SetOnClickListener(this);
            btnDelete.Tag = infoImage;
            d.Show();
        }

        public bool OnLongClick(View v)
        {
            InfoImage infoImage = (InfoImage)v.Tag;
            createDialog(infoImage);
            return true;
        }
  

        public void deleteFromExternalStorage_v1(Java.IO.File file)
        {
            try
            {
                if (file.Exists())
                {
                    if (file.Delete())
                    {
                        Toast.MakeText(this, "file " + file.AbsolutePath + "deleted", ToastLength.Long).Show();
                        d.Dismiss();
                        linearLayout.RemoveAllViews();
                        getAllFile2();
                    }
                    else
                    {
                        Toast.MakeText(this, "file " + file.AbsolutePath + "not deleted", ToastLength.Long).Show();
                    }
                }
                else Toast.MakeText(this, file.AbsolutePath, ToastLength.Long).Show();
            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Exception while deleting file", ToastLength.Long).Show();
            }
        }
    }
}
