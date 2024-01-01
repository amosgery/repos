using System.Collections.Generic;
using Android.App.AppSearch;

namespace firebase_client
{
    internal class dbItem 
    {
        public string Key { get; set; }
        public string MyProperty { get; set; }
        public List<string> MyProperties { get; set; }
        public int[] Numbers { get; set; }
        public dbItem(string key, string value)
        {
            this.Add(key, value);
        }

        public dbItem() { }

        public dbItem(string myProperty, List<string> myProperties, int[] numbers)
        {
            MyProperty = myProperty;
            MyProperties = myProperties;
            Numbers = numbers;
        }

        public void Add(string key, string value)
        {

            this.Key = key;
            this.MyProperty = value;
            this.MyProperties = new List<string>(new string[5]);
            this.Numbers = new int[5];
        }
    }
}