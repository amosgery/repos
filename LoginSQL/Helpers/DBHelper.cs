using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Linq.Expressions;

namespace LoginSQL
{
    // DatabaseHelper.cs

    public class DBHelper
    {
        private readonly SQLiteConnection database;

        public DBHelper(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<UserModel>();
        }

        // Check if a user with the provided credentials exists
        public bool IsUserValid(string username, string password)
        {
            var user = database.Table<UserModel>().FirstOrDefault(u => u.Username == username && u.Password == password);
            List<UserModel> list = GetAllUsers();
            return user != null;
        }

        // Get all users from the database
        public List<UserModel> GetAllUsers()
        {
            return database.Table<UserModel>().ToList();
        }

        internal bool Add(string username, string password)
        {
            try
            {
                UserModel user = new UserModel(username, password);
                database.Insert(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
    }

}