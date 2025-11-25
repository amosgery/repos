using Android.AdServices.Common;
using Android.Content;
using Javax.Security.Auth;

namespace FirestoreApp;

[Activity(Label = "register")]
public class register : Activity
{
    EditText etName, etAge, etEmail, etPass;
    Button addBtn;
    TextView etMsg;


    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.register);

        etName = FindViewById<EditText>(Resource.Id.name);
        etEmail = FindViewById<EditText>(Resource.Id.email);
        etPass = FindViewById<EditText>(Resource.Id.password);
        etAge = FindViewById<EditText>(Resource.Id.age);
        addBtn = FindViewById<Button>(Resource.Id.addBtn);
        etMsg = FindViewById<TextView>(Resource.Id.msg);

        addBtn.Click += AddBtn_Click;

        var db = new FirestoreHelper(this);
        var user = await db.GetCurrentUser();
        if (user != null)
        {
            Person p = new Person();
            p.SetPerson(user);
            etName.Text = p.Name;
            etEmail.Text = p.Email;
            etPass.Text = p.Password;
            etAge.Text = p.Age.ToString();
            etMsg.Text = "Welcome " + p.Name;

        }
    }

    private async void AddBtn_Click(object? sender, EventArgs e)
    {
        var db = new FirestoreHelper(this);

        Person p = new Person(etName.Text, int.Parse(etAge.Text), etEmail.Text, etPass.Text);
        int result = await db.AddDocumentAsync("users", p.GetAsDictionary());
        switch (result)
        {
            case 1:
                etMsg.Text = "User " + p.Name + " registration failed";
                break;
            case 2:
                etMsg.Text = "User " + p.Name + " updated";
                break;
            default:
                etMsg.Text = "User " + p.Name + " registered successfuly";
                break;
        }
        CreateAlertDialog(etMsg.Text);
    }
    private void CreateAlertDialog(string msg)
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.SetTitle("Alert");
        builder.SetMessage(msg);
        builder.SetCancelable(true);
        builder.SetPositiveButton("OK", (sender, args) => 
        {
            if (!msg.Contains("failed"))
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
        });
        AlertDialog dialog = builder.Create();
        dialog.Show();
    }

}