using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Firebase.Database;
using Firebase.Database.Query;
using Java.Lang.Ref;
using static Android.Icu.Text.Transliterator;
using static Android.Views.View;

namespace firebase_client
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ListView.IOnItemLongClickListener, ListView.IOnItemClickListener
    {
        FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://xamarinfirstapp-2ae7d-default-rtdb.europe-west1.firebasedatabase.app/");
        TextView tv;
        Button btnCheck;
        ListView lv;
        IDisposable dispose;
        int Count=0, counter = 0;
        private Handler mainHandler;
        ListAdapter adapter;
        static List<dbItem> dbList { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            mainHandler = new Handler(Looper.MainLooper);

            SetContentView(Resource.Layout.activity_main);
            tv = FindViewById<TextView>(Resource.Id.tv);
            btnCheck = FindViewById<Button>(Resource.Id.btnCheck);
            lv = FindViewById<ListView>(Resource.Id.lv);
            lv.OnItemLongClickListener = this;//delete 
            btnCheck.Click += BtnCheck_Click;
            ReadDataFromFirebase();
            subscribe();
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        { 
            ReadDataFromFirebase();
            subscribe(); // re-subscribe
        }

    private void subscribe()
        {
            var reference = firebaseClient.Child("records");

            dispose = reference.AsObservable<MyDatabaseRecord>().Subscribe(data =>
            {
                Console.WriteLine(data.Object.MyProperty);
                if (data.Object != null)
                {
                    // New value inserted or existing value updated
                    if (data.Object.MyProperty == null)
                        tv.Text = "Deleted";
                    else
                    {
                        dbItem item = new dbItem(data.Key, data.Object.MyProperty);
                        //AddItemToList(item);
                        tv.Text = data.Object.MyProperty;
                    }
                }

                counter++;
                if (counter > Count) // after initialization
                {
                    mainHandler.Post(() =>  // This code will be executed on the main thread
                        ReadDataFromFirebase());
                }

            });
        }

        private void AddItemToList(dbItem item)
        {

            if (dbList == null) {
                dbList = new List<dbItem>();
                adapter = new ListAdapter(this, dbList);
            }
            dbList.Add(item);
            Count = dbList.Count;
            adapter.SetCangedPos(Count-1);
            adapter.NotifyDataSetChanged();
        }
        private async void ReadDataFromFirebase()
        {

            try
            {
                // Get a reference to the database node
                var reference = firebaseClient.Child("records");
                int count = 0;
                int position=-1;
                var res = await reference.OnceAsync<MyDatabaseRecord>();
                
                dbList = new List<dbItem>();
                foreach (var record in res)
                {
                    dbItem item = new dbItem(record.Key, record.Object.MyProperty);
                    dbList.Add(item);
                    if (tv.Text == record.Object.MyProperty)
                        position = count;
                    //Console.WriteLine(record.Object.MyProperty);
                    count++;
                }
                Count = dbList.Count;
                adapter = new ListAdapter(this, dbList);
                adapter.SetCangedPos(position);
                lv.Adapter = adapter;
                adapter.NotifyDataSetChanged();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the read operation
                Console.WriteLine("Error reading data: " + ex.Message);
                //Toast.MakeText(this, "Error reading data: " + ex.Message, ToastLength.Short).Show();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            //dispose.Dispose();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            DeleteListItem(position);
            return true;
        }
        public void DeleteListItem(int position)
        {
            try
            {
                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                if (position < 0)
                    return;
                builder.SetMessage("Are you sure you want to delete this item?");

                builder.SetPositiveButton("OK", (sender, e) => DeleteItem(position));

                builder.SetNegativeButton("Cancel", (sender, e) =>
                {

                });
                builder.Create().Show();
            }
            catch (Exception ex)
            {
                // Handle any errors that might occur during the deletion
                Toast.MakeText(this, "Error: " + ex.Message, ToastLength.Short).Show();
            }
        }
        public async void DeleteItem(int position)
        {
            // delete item
            var refDB = firebaseClient.Child("records");
            var reference = refDB.Child(dbList[position].GetKey());
            await reference.DeleteAsync();
            MainActivity.dbList.RemoveAt(position);
            adapter.NotifyDataSetChanged();
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            UpdateItem(position);
        }
        public void UpdateItem(int position)
        {
            // update item
            Toast.MakeText(this, "Update item not yet implemented", ToastLength.Short).Show();

        }
    }
}