using Android.Gms.Extensions;
using Firebase.Firestore;

namespace FirestoreApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button addBtn;
        EditText etName, etAge;
        FirestoreListener listener = new FirestoreListener();
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etName = FindViewById<EditText>(Resource.Id.name);
            etAge = FindViewById<EditText>(Resource.Id.age);
            addBtn = FindViewById<Button>(Resource.Id.addBtn);

            addBtn.Click += AddBtn_Click;

        }

        private async void AddBtn_Click(object? sender, EventArgs e)
        {
            var db = new FirestoreHelper(this);

            Person p = new Person(etName.Text, int.Parse(etAge.Text));
            await db.AddDocumentAsync("users", p.GetAsDictionary());
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

        }
    }
}