using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Runtime;
using Firebase;
using Firebase.Firestore;
using Java.Util;


namespace FirestoreApp
{
    public class FirestoreHelper
    {
        private FirebaseFirestore firestore;

        public FirestoreHelper(Context context)
        {
            Initialize(context);
        }

        public void Initialize(Context context)
        {
            try
            {
                // Try to get existing app
                var app = FirebaseApp.InitializeApp(context);

                if (app == null)
                {
                    // Fallback: initialize manually (optional, if google-services.json not auto-handled)
                    var options = new FirebaseOptions.Builder()
                        .SetProjectId("xamarinfirstapp-2ae7d")
                        .SetApplicationId("1:1045228157856:android:cf39db243843b7c28442c5")
                        .SetApiKey("your-api-key")
                        .SetStorageBucket("your-project-id.appspot.com")
                        .Build();

                    app = FirebaseApp.InitializeApp(context, options);
                }

                firestore = FirebaseFirestore.GetInstance(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Firestore] Initialization failed: {ex.Message}");
            }
        }

        public async Task AddDocumentAsync(string collection, Dictionary<string, Java.Lang.Object> data)
        {
            if (firestore == null)
                throw new InvalidOperationException("Firestore not initialized. Call FirestoreHelper.Initialize(context) first.");

            Java.Lang.Object name, age, val;
            data.TryGetValue("Name", out name);
            data.TryGetValue("Age", out age);
            var p = await GetUserAsync(name.ToString(), age.ToString());
            if (p== null)
            {
                await firestore.Collection(collection).Add(new HashMap(data));
            }
            else
            {
                Console.WriteLine($"User {name} aged {age} already exist");
            }
        }

        public async Task<QuerySnapshot> GetAllDocumentsAsync(string collection)
        {
            if (firestore == null)
                throw new InvalidOperationException("Firestore not initialized.");

            QuerySnapshot arrayList = (QuerySnapshot)await firestore.Collection(collection).Get();
            return arrayList;
        }

        public async Task<List<Person>> GetAllPersonAsync(string collection)
        {
            QuerySnapshot arrayList = await GetAllDocumentsAsync(collection);
            List<Person> personList = new List<Person>();
            if (arrayList != null)
            {
                foreach(DocumentSnapshot doc in arrayList.Documents)
                {
                    Person p = new Person();
                    p.SetPerson(doc);
                    personList.Add(p);
                }
                return personList;
            }
            return personList;
        }
        public async Task<DocumentSnapshot> GetUserAsync(string name, string age)
        {
            var db = FirebaseFirestore.Instance;

            int iage = int.Parse(age);
            // Query users where email == the given email
            var query = db.Collection("users").WhereEqualTo("Name", name).WhereEqualTo("Age", iage);
            QuerySnapshot snapshot = (QuerySnapshot)await query.Get();

            if (snapshot.Documents.Count == 0)
            {
                Console.WriteLine("No matching users found.");
                return null;
            }
            DocumentSnapshot p = null;
            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                Java.Lang.Object str;
                str = doc.Get("Name");
                Console.WriteLine($"Found user: {str}");
                p = doc;
            }


            return p;
        }


    }
}
