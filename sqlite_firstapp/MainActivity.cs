using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using Java.Nio.Channels;
using SQLite;
using static Java.Util.Jar.Attributes;

namespace sqlite_firstapp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public static string dbname = "dbTest10";
        string path;
        public int count = 0;
        Button btnInsert, btnGetAll, btnDelete, btnUpdate;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            btnInsert = (Button)FindViewById(Resource.Id.btnInsert);
            btnInsert.Click += BtnInsert_Click;

            btnGetAll = (Button)FindViewById(Resource.Id.btnGetAll);
            btnGetAll.Click += BtnGetAll_Click; ;

            btnUpdate = (Button)FindViewById(Resource.Id.btnUpdate);
            btnUpdate.Click += BtnUpdate_Click; ;

            btnDelete = (Button)FindViewById(Resource.Id.btnDelete);
            btnDelete.Click += BtnDelete_Click; ;

            //create person 
            path = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbname);
            var db = new SQLiteConnection(path);//create db object
            db.CreateTable<Person>();
        }
        void BtnInsert_Click(object sender, System.EventArgs e)
        {
            var db = new SQLiteConnection(path);//create db object
            Person person = new Person("Amos" + this.count, "G" + count, 59);//create person object
            count++;

            string strsql = string.Format($"INSERT INTO Persons (fname, lname, age) VALUES ('{person.fname}', '{person.lname}', '{person.age}')" );
            var persons = db.Query<Person>(strsql);
            //db.Insert(person);
            Toast.MakeText(this, "insert record "+person.fname + " with id : " + person.id, ToastLength.Short).Show();

        }
        void BtnGetAll_Click(object sender, System.EventArgs e)
        {
            //get persons 
            List<Person> allPerson = GetAllUsers();
            if (allPerson == null)
                return;
            foreach (var item in allPerson)
            {
                Person temp = (Person)item;
                Toast.MakeText(this, temp.fname + " with id : " + temp.id, ToastLength.Short).Show();
            }

        }
        public List<Person> getAllPerson()
        {
            List<Person> personsList = new List<Person>();

            var db = new SQLiteConnection(path);

            string strsql = string.Format("SELECT * FROM persons");
            var persons = db.Query<Person>(strsql);
            // persons.ToList();
            personsList = new List<Person>();
            if (persons.Count > 0)
            {
                foreach (var item in persons)
                {
                    personsList.Add(item);

                }
            }
            return personsList;
        }

        // Get all users from the database
        public List<Person> GetAllUsers()
        {
            var db = new SQLiteConnection(path);

            return db.Table<Person>().ToList();
        }
        //update 
        void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            List<Person> allPerson = getAllPerson();
            //update person 

            allPerson[0].setPerson("Nurit" + count, "Gery" + count, 56);
            var db = new SQLiteConnection(path);
            string strsql1 = string.Format($"SELECT* FROM Persons WHERE fname = 'Amos0'");
            var users = db.Query<Person>(strsql1);
            var user = users[0];
            //var user = db.Table<Person>().FirstOrDefault(u => u.fname == "Amos0");
            //db.Update(allPerson[0]);
            string strsql = string.Format($"Update Persons set fname ='{allPerson[0].fname}', lname ='{allPerson[0].lname}', age='{allPerson[0].age}' WHERE _id='0'");
            var persons = db.Query<Person>(strsql);
            Toast.MakeText(this, "update record " + allPerson[0].fname + " with id : " + allPerson[0].id, ToastLength.Short).Show();
        }

        void BtnDelete_Click(object sender, System.EventArgs e)
        {
            List<Person> allPerson = getAllPerson();
            var db = new SQLiteConnection(path);
            db.Delete<Person>(allPerson[0].id);
            Toast.MakeText(this, "delete record " + allPerson[0].fname + " with id : " + allPerson[0].id, ToastLength.Short).Show();

        }
    }
}