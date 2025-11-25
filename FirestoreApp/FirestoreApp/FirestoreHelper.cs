using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.Runtime;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Firestore.Auth;
using Java.Util;
using static Android.Provider.ContactsContract.CommonDataKinds;


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
                        .SetProjectId("your-project-id")
                        .SetApplicationId("your-app-id")
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
            int result = 0;
            if (firestore == null)
                throw new InvalidOperationException("Firestore not initialized. Call FirestoreHelper.Initialize(context) first.");

            Java.Lang.Object name, age, email, pass, user = null;

            if (data.TryGetValue("Email", out email) && data.TryGetValue("Password", out pass))
            {
                try
                {
                    user = await LoginAsync(email.ToString(), pass.ToString());
                    if (user == null)
                    {
                        // New user

                        // Register
                        user = await RegisterUserAsync(email.ToString(), pass.ToString());
                        if (user == null)
                        {
                            Console.WriteLine("User registation failed: " + email);
                            result = 1;
                        }
                        else
                            Console.WriteLine("User registered: " + email);

                    }
                    else
                    {
                        // user already registered - update it's data
                        data.Remove("Email");
                        data.Remove("Password");
                        var newUser = user as FirebaseUser;
                        await firestore.Collection(collection).Document(newUser.Uid).Set(new HashMap(data));
                        // user added but not registered
                        result = 2;
                    }
                }
                catch (Exception ex)
                {
                    // user is not registered
                    Console.WriteLine(ex.Message);
                    try
                    {
                        // Register
                        user = await RegisterUserAsync(email.ToString(), pass.ToString());
                        if (user == null)
                        {
                            Console.WriteLine("User registation failed: " + email);
                            result = 1;
                        }
                        else
                            Console.WriteLine("User registered: " + email);
                    }
                    catch (Exception except)
                    {
                        Console.WriteLine(except.Message);
                        result = 1;
                    }

                }
                if (result == 0)
                {
                    // add it to the users collection without username and password
                    data.Remove("Email");
                    data.Remove("Password");
                    var newUser = user as FirebaseUser;
                    await firestore.Collection(collection).Document(newUser.Uid).Set(new HashMap(data));
                    // user added but not registered
                }
            }
            else
            {
                // No email or password

                Console.WriteLine($"Cannot register user");
                result = 1;  // user exists 
            }


            return result;
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
                foreach (DocumentSnapshot doc in arrayList.Documents)
                {
                    Person p = new Person();
                    p.SetPerson(doc);
                    personList.Add(p);
                }
                return personList;
            }
            return personList;
        }
        public async Task<DocumentSnapshot> GetUserAsync(string uid)
        {

            DocumentSnapshot snapshot = null;
            try
            {

                var query = firestore.Collection("users").Document(uid);
                snapshot = (DocumentSnapshot)await query.Get();

                if (snapshot == null)
                {
                    Console.WriteLine("No matching users found.");
                    return null;
                }
                else
                {
                    Java.Lang.Object str;
                    str = snapshot.Get("Name");
                    Console.WriteLine($"Found user: {str}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return snapshot;
        }

        public async Task<QuerySnapshot> GetUserByName(string name)
        {
            var db = FirebaseFirestore.Instance;
            QuerySnapshot snapshot = null;
            try
            {

                var query = await db.Collection("users").WhereEqualTo("Name", name).Get();
                snapshot = query as QuerySnapshot;

                if (snapshot == null)
                {
                    Console.WriteLine("No matching users found.");
                    return null;
                }

                return snapshot;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return snapshot;
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
            try
            {
                var auth = FirebaseAuth.Instance;

                var result = await auth.SignInWithEmailAndPasswordAsync(email, password);
                return result.User;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public async Task<Dictionary<string, Java.Lang.Object>> GetCurrentUser()
        {
            try
            {
                var user = FirebaseAuth.Instance.CurrentUser;
                if (user != null)
                {
                    var data = new Dictionary<string, Java.Lang.Object>();
                    DocumentSnapshot u = await GetUserAsync(user.Uid);
                    if (u != null)
                    {
                        foreach (var entry in u.Data)
                            data[entry.Key] = entry.Value;
                    }

                    // Add fields you want
                    data["Email"] = new Java.Lang.String(user.Email);

                    return data;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
