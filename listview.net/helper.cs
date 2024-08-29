using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Util;

namespace listview.net
{
    public class Helper
    {
        public static string dbname = "dbTest1.db3";
        public Helper()
        {

        }
        public static string Path()
        {
            // Private Storage:
            //string path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Helper.dbname);
            // Public storage:
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            if (!Directory.Exists(documentsPath))
                Directory.CreateDirectory(documentsPath);

            string path = System.IO.Path.Combine(documentsPath, dbname);
            return path;
        }
        public static string BitmapToBase64(Bitmap bitmap)
        {
            string str = "";
            if (bitmap == null)
                return str;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                var bytes = stream.ToArray();
                str = Convert.ToBase64String(bytes);
            }
            return str;
        }

        public static Bitmap Base64ToBitmap(String base64String)
        {
            byte[] imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
            return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
        }
    }
}
