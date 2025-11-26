using Android.AdServices.Common;
using Android.Content;
using Android.Health.Connect.DataTypes.Units;
using static Android.Provider.ContactsContract.CommonDataKinds;

namespace FirestoreApp;

[Activity(Label = "login")]
public class login : Activity
{
    EditText etEmail, etPass;
    Button addBtn;
    TextView etMsg;
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.login);



        etEmail = FindViewById<EditText>(Resource.Id.email);
        etPass = FindViewById<EditText>(Resource.Id.password);
        addBtn = FindViewById<Button>(Resource.Id.addBtn);
        etMsg = FindViewById<TextView>(Resource.Id.msg);

        addBtn.Click += AddBtn_Click;

        // Create your application here
    }


    private async void AddBtn_Click(object? sender, EventArgs e)
    {
        var db = new FirestoreHelper(this);

        var user = await db.LoginAsync(etEmail.Text, etPass.Text);
        if (user != null)
        {
            etMsg.Text = "User " + etEmail.Text + " logged in";
            var u = await db.GetUserAsync(user.Uid);
            if (u != null)
            {
                Person p = new Person();
                p.SetPerson(u);
                etMsg.Text = "Welcome "+p.Name;
            }
        }
        else
            etMsg.Text = "Bad credentials";

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
            if (msg.StartsWith("Welcome"))
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }
        });
        AlertDialog dialog = builder.Create();
        dialog.Show();
    }
}