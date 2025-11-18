using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Runtime;
using Firebase;
using Firebase.Auth;
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

        public async Task<int> AddDocumentAsync(string collection, Dictionary<string, Java.Lang.Object> data)
        {
            if (firestore == null)
                throw new InvalidOperationException("Firestore not initialized. Call FirestoreHelper.Initialize(context) first.");

            Java.Lang.Object name, age, email, pass;

            if (data.TryGetValue("Name", out name) && data.TryGetValue("Age", out age))
            {
                var p = await GetUserAsync(name.ToString(), age.ToString());
                if (p == null)
                {
                    // New user
                    if (data.TryGetValue("Email", out email) && data.TryGetValue("Password", out pass))
                    {
                        try
                        {
                            // Register
                            var user = await RegisterUserAsync(email.ToString(), pass.ToString());
                            
                            Console.WriteLine("User created: " + user.Email);
                            return 1;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    // add it to the users collection
                    await firestore.Collection(collection).Add(new HashMap(data));
                    return 3;  // user added but not registered
                }
                else
                {
                    // Existing user
                    if (data.TryGetValue("Email", out email) && data.TryGetValue("Password", out pass))
                    {
                        try
                        {
                            var user = await LoginAsync(email.ToString(), pass.ToString());
                            if (user != null)
                                Console.WriteLine($"User {name} logged in");
                            return 2;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    Console.WriteLine($"User {name} aged {age} already exist");
                    return 4;  // user exists but not registered
                }
            }
            return 0;
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

        public async Task<FirebaseUser> RegisterUserAsync(string email, string password)
        {
            try
            {
                var auth = FirebaseAuth.Instance;

                // Register user
                var result = await auth.CreateUserWithEmailAndPasswordAsync(email, password);

                // Return Firebase user info
                return result.User;
            }
            catch (FirebaseAuthUserCollisionException)
            {
                throw new Exception("Email already exists.");
            }
            catch (FirebaseAuthWeakPasswordException)
            {
                throw new Exception("Password is too weak.");
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }
        }

        public async Task<FirebaseUser> LoginAsync(string email, string password)
        {
            var auth = FirebaseAuth.Instance;

            var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
            return result.User;
        }


    }
}
