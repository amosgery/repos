using Android.Gms.Extensions;
using Firebase.Firestore;

namespace FirestoreApp
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button addBtn;
        EditText etName, etAge, etEmail, etPass;
        TextView etMsg;
        FirestoreListener listener = new FirestoreListener();
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            etMsg = FindViewById<TextView>(Resource.Id.msg);
            etName = FindViewById<EditText>(Resource.Id.name);
            etEmail = FindViewById<EditText>(Resource.Id.email);
            etPass = FindViewById<EditText>(Resource.Id.password);
            etAge = FindViewById<EditText>(Resource.Id.age);
            addBtn = FindViewById<Button>(Resource.Id.addBtn);

            addBtn.Click += AddBtn_Click;

        }

        private async void AddBtn_Click(object? sender, EventArgs e)
        {
            var db = new FirestoreHelper(this);

            Person p = new Person(etName.Text, int.Parse(etAge.Text), etEmail.Text, etPass.Text);
            int result = await db.AddDocumentAsync("users", p.GetAsDictionary());
            switch (result)
            {
                case 1:
                    etMsg.Text = "User " + p.Name + " registered successfuly";
                    break;
                case 2:
                    etMsg.Text = "User " + p.Name + " logged in successfuly";
                    break;
                case 3:
                    etMsg.Text = "User " + p.Name + " added but not registered";
                    break;
                case 4:
                    etMsg.Text = "User " + p.Name + " exists but not logged in";
                    break;
                default:
                    etMsg.Text = "User " + p.Name + "not valid";
                    break;
            }
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