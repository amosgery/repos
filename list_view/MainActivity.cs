using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;



namespace list_view
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener

    {
        public static List<Toy> toyList { get; set; }        //public static List<Toy> toyList { get;  set; }
        ToyAdapter toyAdapter;
        ListView lv;
        ImageView iv;
        Button btnGo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //var db = new SQLiteConnection(Helper.Path());
            //db.CreateTable<Toy>();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Android.Graphics.Bitmap home0 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.home0);
            Android.Graphics.Bitmap home1 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.home1);
            Android.Graphics.Bitmap home2 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.home2);
            Android.Graphics.Bitmap light0 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.light0);
            Android.Graphics.Bitmap light1 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.light1);
            Android.Graphics.Bitmap light2 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.light2);
            Android.Graphics.Bitmap phone0 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.phone0);
            Android.Graphics.Bitmap phone1 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.phone1);
            Android.Graphics.Bitmap phone2 = Android.Graphics.BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.phone2);
            Toy t1 = new Toy(50, "home", "very good toy", home0);

            Toy t2 = new Toy(70, "home", "average  toy", home1);

            Toy t3 = new Toy(90, "home", "nice toy", home2);

            Toy t4 = new Toy(29, "light", "very good toy", light0);

            Toy t5 = new Toy(37, "phone", "average  toy", phone0);

            Toy t6 = new Toy(50, "light", "nice toy", light1);

            Toy t7 = new Toy(29, "light", "average toy", light2);

            Toy t8 = new Toy(37, "phone", "average  toy", phone2);

            Toy t9 = new Toy(50, "phone", "nice toy", phone1);



            //phase 2 - add to array list

            toyList = new System.Collections.Generic.List<Toy>();

            toyList.Add(t1); toyList.Add(t2); toyList.Add(t3);

            toyList.Add(t4); toyList.Add(t5); toyList.Add(t6);

            toyList.Add(t7); toyList.Add(t8); toyList.Add(t9);

            //phase 3 - create adapter

            toyAdapter = new ToyAdapter(this, toyList);

            //phase 4 reference to listview

            lv = FindViewById<ListView>(Resource.Id.lv);

            lv.Adapter = toyAdapter;

            //phase 4 reference to listview

            btnGo = FindViewById<Button>(Resource.Id.btnGo);

            btnGo.Click += BtnGo_Click;

            lv.OnItemClickListener = this;     //update

            lv.OnItemLongClickListener = this;//delete 

        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(EditActivity));
            StartActivity(intent);
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            Intent intent = new Intent(this, typeof(EditActivity));
            Toy temp = MainActivity.toyList[position];
            intent.PutExtra("pos", position);
            //iv.SetImageBitmap(temp.getBitmap());
            StartActivity(intent);
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (toyAdapter != null)
            {
                toyAdapter.NotifyDataSetChanged();
            }
        }

        bool AdapterView.IOnItemLongClickListener.OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            // add OK/Cancel button
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            if (position < 0)
                return false;
            builder.SetMessage("Are you sure you want to delete this item?");

            builder.SetPositiveButton("OK", (sender, e) =>
            {
                // delete item
                MainActivity.toyList.RemoveAt(position);
                toyAdapter.NotifyDataSetChanged();
            });
            builder.SetNegativeButton("Cancel", (sender, e) =>
            {

            });
            builder.Create().Show();
            return true;
        }
    }
}