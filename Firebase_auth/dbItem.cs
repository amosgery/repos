using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Firebase_auth
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