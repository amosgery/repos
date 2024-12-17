using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Graphics;
using Android.Util;
using SQLite;

namespace listview.net
{
    public static class Helper
    {
        static SQLiteConnection db;
        public static string dbname = "dbTest1.db3";
        static Helper()
        {
            db = new SQLiteConnection(Helper.Path());
            //db.DropTable<Toy>();
            db.CreateTable<Toy>();
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

        internal static void DeleteItem(Toy toy)
        {
            db.Delete(toy);
        }
        public static List<Toy> getAllToys()
        {
            string strsql = string.Format("SELECT * FROM Toys");
            var toys = db.Query<Toy>(strsql);
            List<Toy> toyList = new List<Toy>();
            if (toys.Count > 0)
            {
                foreach (var item in toys)
                {
                    toyList.Add(item);

                }
            }
            //db.Close();
            return toyList;
        }

        internal static void Update(Toy t)
        {
            db.Update(t);
        }

        internal static void Insert(Toy t)
        {
            db.Insert(t);
        }
    }
}
