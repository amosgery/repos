using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace gallery
{
    public class HelperFile

    {

        public static void writeFileToInternalStorage(Context context, Bitmap bitmap, String filename)

        {

            Android.Content.ISharedPreferences sp = context.GetSharedPreferences("details", Android.Content.FileCreationMode.Private);

            int counter = sp.GetInt("counter", 0);



            using (Stream stream = context.OpenFileOutput(filename + counter, FileCreationMode.Private))

            {

                try

                {

                    bitmap.Compress(Bitmap.CompressFormat.Png, 90, stream);

                    stream.Close();

                    counter++;

                    var editor = sp.Edit();

                    editor.PutInt("counter", counter);

                    editor.Commit();

                    Toast.MakeText(context, "saved", ToastLength.Long).Show();

                }

                catch (Java.IO.IOException e)

                {

                    e.PrintStackTrace();

                }

            }

        }

        public static Bitmap readFileFromInternalStorage(Context context, String filename)

        {

            Bitmap b = null;



            try

            {

                using (Stream inTo = ((Activity)context).OpenFileInput(filename))

                    try

                    {

                        b = BitmapFactory.DecodeStream(inTo);

                    }

                    catch (Java.IO.IOException e)

                    {

                        e.PrintStackTrace();

                    }



            }

            catch (Java.IO.IOException e)
            {



                Toast.MakeText(context, "file not found", ToastLength.Long).Show();

            }

            return b;

        }

        public static List<Bitmap> getAllFils(Context context)

        {

            Java.IO.File mydir = context.FilesDir;

            Java.IO.File lister = mydir;



            List<Bitmap> arraylist = new List<Bitmap>();

            foreach (string list in lister.List())

            {

                //Toast.MakeText(context, list, ToastLength.Long).Show();

                Bitmap b = readFileFromInternalStorage(context, list);

                arraylist.Add(b);

            }

            return arraylist;

        }

    }
}