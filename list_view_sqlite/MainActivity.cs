using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using SQLite;


namespace list_view
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener

    {
        public static List<Toy> toyList { get; set; }        //public static List<Toy> toyList { get;  set; }
        ToyAdapter toyAdapter;
        ListView lv;

        Button btnGo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var db = new SQLiteConnection(Helper.Path());
            //db.DropTable<Toy>();
            db.CreateTable<Toy>();
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           //phase 4 reference to listview
            lv = FindViewById<ListView>(Resource.Id.lv);
            btnGo = FindViewById<Button>(Resource.Id.btnGo);

            btnGo.Click += BtnGo_Click;

            lv.OnItemClickListener = this;     //update

            lv.OnItemLongClickListener = this;//delete 
            toyList = getAllToys();
            toyAdapter = new ToyAdapter(this, toyList);
            lv.Adapter = toyAdapter;

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
            var db = new SQLiteConnection(Helper.Path());
          
            // add OK/Cancel button
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            if (position < 0)
                return false;
            builder.SetMessage("Are you sure you want to delete this item?");

            builder.SetPositiveButton("OK", (sender, e) =>
            {
                // delete item
                db.Delete(toyList[position]);
                MainActivity.toyList.RemoveAt(position);
                toyAdapter.NotifyDataSetChanged();
            });
            builder.SetNegativeButton("Cancel", (sender, e) =>
            {

            });
            builder.Create().Show();
            return true;
        }
        public List<Toy> getAllToys()
        {
            var db = new SQLiteConnection(Helper.Path());
            //var hlpDB = new SQLiteOpenHelper(this, Helper.Path(), null, 1);
            //var list = new List<Toy>();


            string strsql = string.Format("SELECT * FROM Toys");
            var toys = db.Query<Toy>(strsql);
            toyList = new List<Toy>();
            if (toys.Count > 0)
            {
                foreach (var item in toys)
                {
                    toyList.Add(item);

                }
            }
            db.Close();
            return toyList;
        }
    }
}