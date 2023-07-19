using System;
using System.Collections.Generic;
using Java.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace external_file
{
    public class InfoImage : Java.Lang.Object
    {
        private File file;
        private Bitmap bitmap;

        public InfoImage(File file, Bitmap bitmap)
        {
            this.file = file;
            this.bitmap = bitmap;
        }
        public Bitmap getBitmap()
        {
            return bitmap;
        }

        public void setBitmap(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public File getFile()
        {
            return file;
        }

        public void setFile(File file)
        {
            this.file = file;
        }
    }
}


