using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using SQLite;

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
            Person person = new Person("Amos" + this.count, "G" + count, 12);//create person object
            count++;
            db.Insert(person);
            Toast.MakeText(this, "insert record "+person.fname + " with id : " + person.id, ToastLength.Short).Show();

        }
        void BtnGetAll_Click(object sender, System.EventArgs e)
        {
            //get persons 
            List<Person> allPerson = getAllPerson();
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
        //update 
        void BtnUpdate_Click(object sender, System.EventArgs e)
        {
            List<Person> allPerson = getAllPerson();
            //update person 
            allPerson[0].setPerson("Nurit" + count, "G" + count, 12);
            var db = new SQLiteConnection(path);
            db.Update(allPerson[0]);
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