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
using Java.Util.Functions;

namespace intent
{
    internal class User
    {
        public string Name { get; set; }
        public string Pass { get; set; }

        public User() { }
        public User(User user)
        { 
            this.Name = user.Name;
            this.Pass = user.Pass; 
        }


    }
}