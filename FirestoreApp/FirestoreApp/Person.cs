
using Firebase.Firestore;


namespace FirestoreApp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Person()
        { }

        public Person(string name, int age, string email, string password)
        {
            Name = name;
            Age = age;
            Email = email;
            Password = password;
        }

        public Dictionary<string, Java.Lang.Object> GetAsDictionary()
        {
            Dictionary<string, Java.Lang.Object> data = new Dictionary<string, Java.Lang.Object>();
            data.Add("Name", Name);
            data.Add("Age", Age);
            data.Add("Email", Email);
            data.Add("Password", Password);
            return data;
        }

        public void SetPerson(DocumentSnapshot data)
        {
            Java.Lang.Object val;
            if ((val = data.Get("Name")) != null)
                Name = val.ToString();

            if ((val = data.Get("Age")) != null)
                Age = int.Parse(val.ToString());

            if ((val = data.Get("Email")) != null)
                Email = val.ToString();

            if ((val = data.Get("Password")) != null)
                Password = val.ToString();
        }
    }


}
