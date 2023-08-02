using Android.App.AppSearch;

namespace firebase_client
{
    internal class dbItem 
    {
        string key;
        string value;

        public dbItem(string key, string value)
        {
            this.key = key;
            this.value = value;
        }

        public string GetValue()
        {
            return value;
        }

        public string GetKey()
        {
            return key;
        }
        public void SetValue(string value)
        {
            this.value = value;
        }

        public void SetKey(string key)
        {
            this.key = key;
        }
        public void Add(string key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}