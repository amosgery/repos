using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Firebase.Database.Query;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace firebase_client
{
    public static class DatabaseHelper
    {
        static readonly FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://xamarinfirstapp-2ae7d-default-rtdb.europe-west1.firebasedatabase.app/");

        public static dbItem ReadObjectFromFirebase()
        {
            try
            {
                // Get a reference to the database node
                var reference = firebaseClient.Child("records");
                var res = reference.Child("key1").OnceSingleAsync <dbItem> ().Result;
                // query for value - require adding an index rule to Firebase realtime DB
                var res2 = reference.OrderBy("MyProperty").EqualTo("hello").OnceAsync<dbItem>().Result;
                //res.Wait();
                return res;
 
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the read operation
                Console.WriteLine("Error reading data: " + ex.Message);
                //Toast.MakeText(this, "Error reading data: " + ex.Message, ToastLength.Short).Show();
            }
            return null;
        }

    }
}