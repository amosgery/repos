
using Firebase.Firestore;


namespace FirestoreApp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Dictionary<string, Java.Lang.Object> GetAsDictionary()
        {
            Dictionary<string, Java.Lang.Object> data = new Dictionary<string, Java.Lang.Object>();
            data.Add("Name", Name);
            data.Add("Age", Age);

            return data;
        }

        public void SetPerson(DocumentSnapshot data)
        {
            Java.Lang.Object val;
            if ((val = data.Get("Name")) != null)
                Name = val.ToString();

            if ((val = data.Get("Age")) != null)
                Age = int.Parse(val.ToString());
        }
    }


}
