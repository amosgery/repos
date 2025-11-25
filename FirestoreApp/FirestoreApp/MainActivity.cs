using Android.Content;
using Android.Gms.Extensions;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Nio.FileNio;
using Java.Util;

namespace FirestoreApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button regBtn, logBtn;
        TextView etMsg;
        ListView listview;
        FirestoreListener listener = new FirestoreListener();
        protected override async void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etMsg = FindViewById<TextView>(Resource.Id.msg);
            regBtn = FindViewById<Button>(Resource.Id.register);
            logBtn = FindViewById<Button>(Resource.Id.login);
            listview = FindViewById<ListView>(Resource.Id.listview);

        
            listview.ItemClick += (sender, e) =>
            {
                string item = listview.Adapter.GetItem(e.Position).ToString();
                Toast.MakeText(this, "Clicked: " + item, ToastLength.Short).Show();
            };

            regBtn.Click += regBtn_Click;
            logBtn.Click += logBtn_Ckick;
            listener.OnDataChanged += Listener_OnDataChanged;

            var db = new FirestoreHelper(this);
            var user = await db.GetCurrentUser();
            if (user != null)
            {
                Person p = new Person();
                p.SetPerson(user);
                etMsg.Text = "Welcome "+ p.Name;
            }
        }

        private async void Listener_OnDataChanged(QuerySnapshot snapshot)
        {
            UpdateListview();
            foreach (var change in snapshot.DocumentChanges)
            {
                string name = change.Document.Get("Name").ToString();
                var db = new FirestoreHelper(this);

                QuerySnapshot users = await db.GetUserByName(name);
                foreach (var user in users.Documents)
                {
                    Console.WriteLine(user.Id);

                    Person person = new Person();
                    person.SetPerson(user);
                }

                if (change.GetType() == DocumentChange.Type.Added)
                {
                    Console.WriteLine($"Firestore, 🟢 Added user: {name}");
                    Toast.MakeText(this, "User Added: " + name, ToastLength.Short).Show();
                }
                else if (change.GetType() == DocumentChange.Type.Modified)
                {
                    Console.WriteLine($"Firestore, 🟢 Modified user: {name}");
                    Toast.MakeText(this, "User Updated: " + name, ToastLength.Short).Show();
                }
                else if (change.GetType() == DocumentChange.Type.Removed)
                {
                    Console.WriteLine($"Firestore, 🟢 Removed user: {name}");
                    Toast.MakeText(this, "User Removed: " + name, ToastLength.Short).Show();
                }

            }


        }

        private async void UpdateListview()
        {

            var db = new FirestoreHelper(this);
            List<Person> persons = await db.GetAllPersonAsync("users");
            string[] items = new string[persons.Count];
            int index = 0;
            foreach (Person p in persons)
            {
                items[index++] = p.Name + " " + p.Email + " " + p.Age;
            }

            var adapter = new ArrayAdapter<string>(
                this,
                Android.Resource.Layout.SimpleListItem1,
                items
            );

            listview.Adapter = adapter;
        }

        private void logBtn_Ckick(object? sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(login));
            StartActivity(intent);
            getAll();
        }

        private void regBtn_Click(object? sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(register));
            StartActivity(intent);
            getAll();
        }

        private async void getAll()
        {

            var db = new FirestoreHelper(this);

            List<Person> list = await db.GetAllPersonAsync("users");
            foreach (Person p in list)
            {
                Console.WriteLine(p.Name + " , " + p.Age);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            listener.StopListening();
            FirebaseAuth.Instance.SignOut();


        }
    }
}