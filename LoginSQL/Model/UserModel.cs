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
namespace LoginSQL
{
    [Table("UserModel")]
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        // Additional property
        public string Email { get; set; }

        public UserModel() { }
        public UserModel(string username, string password) 
        {
            Username = username;
            Password = password;
        }
        // Additional method
        public void SendEmailVerification()
        {
            // Code to send an email verification
            // This method could contain the logic to send an email to the user's email address for verification
            // ...
        }
    }

}