using Android.AdServices.Common;
using Android.Content;
using Javax.Security.Auth;

namespace FirestoreApp;

[Activity(Label = "update")]
public class update : Activity
{
    EditText etName, etAge;
    Button addBtn;
    TextView etMsg;
    Person p;
    int item=0;

    protected override async void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.update);

        etName = FindViewById<EditText>(Resource.Id.name);
        etAge = FindViewById<EditText>(Resource.Id.age);
        addBtn = FindViewById<Button>(Resource.Id.addBtn);
        etMsg = FindViewById<TextView>(Resource.Id.msg);

        addBtn.Click += AddBtn_Click;

        item = Intent.GetIntExtra("item", 0);
        var db = new FirestoreHelper(this);
        var user = await db.GetUser(item);
        if (user != null)
        {
            p = new Person();
            p.SetPerson(user);
            etName.Text = p.Name;
            etAge.Text = p.Age.ToString();
            etMsg.Text = "Welcome " + p.Name;

        }
    }

    private async void AddBtn_Click(object? sender, EventArgs e)
    {
        var db = new FirestoreHelper(this);

        p.Name = etName.Text;
        p.Age = int.Parse(etAge.Text);

        int result = await db.UpdateDocument("users", p.GetAsDictionary());
        switch (result)
        {
            case 1:
                etMsg.Text = "User " + p.Name + " update failed";
                break;
            case 2:
                etMsg.Text = "User " + p.Name + " updated";
                break;
            default:
                etMsg.Text = "User " + p.Name + " updated successfuly";
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