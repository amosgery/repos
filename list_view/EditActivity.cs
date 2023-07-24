using System;
using System.Collections.Generic;
using Android.Graphics;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace list_view
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        Button btnSave, btnAddPic;
        EditText etTitle, etSubtitle, etPrice;
        Bitmap bitmap;
        ImageView iv;
        int pos = -1;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.edit_item);
            iv = FindViewById<ImageView>(Resource.Id.ivProduct);
            btnSave = FindViewById<Button>(Resource.Id.btnSave);
            btnAddPic = FindViewById<Button>(Resource.Id.btnAddPic);
            etTitle = FindViewById<EditText>(Resource.Id.etTitle);
            etSubtitle = FindViewById<EditText>(Resource.Id.etSubTitle);
            etPrice = FindViewById<EditText>(Resource.Id.etPrice);
            pos = Intent.GetIntExtra("pos", -1);//-1 is default
            btnSave.Click += BtnSave_Click;
            btnAddPic.Click += BtnAddPic_Click;
            if (pos != -1) // update 
            {
                Toy temp = MainActivity.toyList[pos];
                Toast.MakeText(this, "position is  " + pos, ToastLength.Long).Show();
                etTitle.Text = temp.getTitle();
                etSubtitle.Text = temp.getSubTitle();
                etPrice.Text = "" + temp.getPrice();
                bitmap = temp.getBitmap();
                iv.SetImageBitmap(temp.getBitmap());
            }
            else // create new toy 
            {
                Toast.MakeText(this, "lets add new item ", ToastLength.Long).Show();
            }
        }
        void BtnAddPic_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Android.Provider.MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == 0)//coming from camera
            {
                if (resultCode == Result.Ok)
                {
                    bitmap = (Android.Graphics.Bitmap)data.Extras.Get("data");
                    iv.SetImageBitmap(bitmap);
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            int price = int.Parse(etPrice.Text);
            string title = etTitle.Text;
            string subtitle = etSubtitle.Text;
            Toy t = null;// = new Toy(price, title, subtitle, MainActivity.toyList[pos].getBitmap());
            if (pos != -1)//update 
            {
                t = new Toy(price, title, subtitle, bitmap);
                MainActivity.toyList[pos] = t;
                Finish();
            }
            else // create new toy
            {
                t = new Toy(price, title, subtitle, bitmap);
                MainActivity.toyList.Add(t);
                Finish();
            }
        }
    }
}
