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
using SQLite;

namespace sqlite_firstapp
{
    [Table("Persons")]
    public class Person
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public Person()
        {
        }
        public Person(string fname, string lname, int age)
        {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        }
        public void setPerson(string fname, string lname, int age)
        {
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        }
    }
}