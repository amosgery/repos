using Android;
using Android.Content;
using Android.Content.PM;
using Android.Database.Sqlite;
using Android.Util;
using Android.Views;
using SQLite;

namespace listview.net
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity, ListView.IOnItemClickListener, ListView.IOnItemLongClickListener
    {
        public static List<Toy> toyList { get; set; }        //public static List<Toy> toyList { get;  set; }
        ToyAdapter toyAdapter;
        ListView lv;

        Button btnGo;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (CheckSelfPermission(Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                RequestPermissions(new String[] { Manifest.Permission.WriteExternalStorage }, 100);
            }



            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            //phase 4 reference to listview
            lv = FindViewById<ListView>(Resource.Id.lv);
            btnGo = FindViewById<Button>(Resource.Id.btnGo);

            btnGo.Click += BtnGo_Click;

            lv.OnItemClickListener = this;     //update

            lv.OnItemLongClickListener = this;//delete 
            Helper.CreateTable<Toy>();
            toyList = Helper.getAllToys();
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
            // add OK/Cancel button
            Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
            if (position < 0)
                return false;
            builder.SetMessage("Are you sure you want to delete this item?");

            builder.SetPositiveButton("OK", (sender, e) =>
            {
                // delete item
                Helper.DeleteItem(toyList[position]);

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