using Firebase.Firestore;
using Android.Util;

namespace FirestoreApp
{

    public class FirestoreListener : Java.Lang.Object, IEventListener
    {
        private readonly FirebaseFirestore db;
        private IListenerRegistration listenerRegistration;

        public FirestoreListener()
        {
            db = FirebaseFirestore.Instance;
            if (db != null)
                ListenToUsersCollection();
        }

        public void ListenToUsersCollection()
        {
            listenerRegistration = db.Collection("users").AddSnapshotListener(this);
        }

        // Called automatically when the collection changes
        public void OnEvent(Java.Lang.Object value, FirebaseFirestoreException error)
        {
            if (error != null)
            {
                Log.Error("Firestore", $"Listen failed: {error.Message}");
                return;
            }

            var snapshot = value as QuerySnapshot;
            if (snapshot == null) 
                return;

            foreach (var change in snapshot.DocumentChanges)
            {

                if (change.GetType() == DocumentChange.Type.Added)
                    Console.WriteLine($"Firestore, 🟢 Added user: {change.Document.Get("Name").ToString()}");
                else if (change.GetType() == DocumentChange.Type.Modified)
                    Console.WriteLine($"Firestore, 🟢 Modified user: {change.Document.Get("Name").ToString()}");
                else if (change.GetType() == DocumentChange.Type.Removed)
                    Console.WriteLine($"Firestore, 🟢 Removed user: {change.Document.Get("Name").ToString()}");
            }
        }

        public void StopListening()
        {
            listenerRegistration?.Remove();
            listenerRegistration = null;
        }
    }


}
