using System;
using System.Linq;

using Firebase.Database;
using Firebase.Database.Query;


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