using System.Collections.Generic;
using Java.Util;

namespace first_firebase_app
{
    internal class MyDatabaseRecord
    {

        public string MyProperty { get; set; }
        public List<string> MyProperties { get; set; }
        public int[] Numbers { get; set; }
        public MyDatabaseRecord() { }

        public MyDatabaseRecord(string myProperty, List<string> myProperties, int[] numbers)
        {
            MyProperty = myProperty;
            MyProperties = myProperties;
            Numbers = numbers;
        }
    }
}