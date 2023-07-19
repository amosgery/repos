using System.IO;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.IO;
using static Android.Views.View;

namespace File_IO
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, IOnClickListener

    {

        Button btnsave;

        Button btnload;

        EditText et;

        TextView tv;

        FileOutputStream outTo;

        string str = null;

        protected override void OnCreate(Bundle savedInstanceState)

        {

            base.OnCreate(savedInstanceState);



            // Set our view from the "main" layout resource

            SetContentView(Resource.Layout.activity_main);



            // Get our button from the layout resource,

            // and attach an event to it



            btnsave = FindViewById<Button>(Resource.Id.btnsave);

            btnload = FindViewById<Button>(Resource.Id.btnload);



            et = FindViewById<EditText>(Resource.Id.etTitle);

            tv = FindViewById<TextView>(Resource.Id.textView1);

            btnsave.SetOnClickListener(this);

            btnload.SetOnClickListener(this);

        }



        public void OnClick(View v)

        {

            if (v == btnsave)

            {

                try

                {

                    str = et.Text;

                    using (Stream stream = OpenFileOutput("userinfo.xml", FileCreationMode.Private))

                    {

                        if (str != null)

                        {

                            try

                            {

                                stream.Write(Encoding.ASCII.GetBytes(str), 0, str.Length);

                                stream.Close();

                                Toast.MakeText(this, "save", ToastLength.Long).Show();

                            }

                            catch (Java.IO.IOException e)

                            {

                                e.PrintStackTrace();

                            }

                        }

                    }

                }

                catch (Java.IO.FileNotFoundException e)

                {

                    e.PrintStackTrace();

                }

            }////end of btnSave save file 
            if (v == btnload)
            {
                try
                {
                    using (Stream stream = OpenFileInput("userinfo.xml"))
                    {
                        try
                        {
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            string str = Encoding.ASCII.GetString(buffer);
                            tv.Text = str;
                            stream.Close();
                            Toast.MakeText(this, "load", ToastLength.Long).Show();
                        }
                        catch (Java.IO.IOException e)
                        {
                            e.PrintStackTrace();
                        }
                    }
                }
                catch (Java.IO.FileNotFoundException e)
                {
                    e.PrintStackTrace();
                }
            }////end of btnLoad load file




        }
    }
}