﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace NewWebApp.Model
{

    public class Helper
    {
        private string conString;

        public Helper()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            conString = configuration.GetConnectionString("UsersDB");

        }

        public DataTable RetrieveTable(string SQLStr, string table)
        // Gets A table from the data base acording to the SELECT Command in SQLStr;
        // Returns DataTable with the Table.
        {
            // connect to DataBase
            SqlConnection con = new SqlConnection(conString);

            // Build SQL Query
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // Build DataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);

            // Build DataSet to store the data
            DataSet ds = new DataSet();

            // Get Data form DataBase into the DataSet
            ad.Fill(ds, table);

            return ds.Tables[table];
        }

        public bool UserExist(User user, string table)
        {
            string SQLStr = $"SELECT * FROM [{table}] WHERE Username LIKE '{user.Username}' AND Password LIKE '{user.Password}'";
            DataTable dt = RetrieveTable(SQLStr, "Users");

            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public int Insert(User user, string table)
        // The Method recieve a user objects and insert it to the Database as new row. 
        // if the user is already taken the method will return -1.
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM {table} WHERE Username Like '{user.Username}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת סכימת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count > 0)
            {
                return -1;
            }

            // בניית השורה להוספה
            DataRow dr = ds.Tables[table].NewRow();
            dr["First name"] = user.Firstname;
            dr["Last name"] = user.Lastname;
            dr["Username"] = user.Username;
            dr["Password"] = user.Password;
            dr["Birth date"] = user.Birthdate;


            ds.Tables[table].Rows.Add(dr);

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int n = adapter.Update(ds, table);
            return n;
        }

        public int ExecuteNonQuery(string SQL)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();

            // return the number of rows affected
            return n;
        }

        public int Delete(int id, string table)
        {
            if (id == 0)
            {
                return -1;
            }
            string SQL = $"DELETE FROM {table} WHERE ID = {id}";
            int n = ExecuteNonQuery(SQL);
            return n;
        }

        public int Update(User user, string table)
        {
            string SQL = $"UPDATE {table} " +
                $"SET Username='{user.Username}', Password = '{user.Password}', " +
                $"First name  = '{user.Firstname}', Last name = '{user.Lastname}', " +
                $"Admin = '{user.Admin.ToString()}', " +
                $"Birth date = '{user.Birthdate:dd-MM-yyyy}' " +
                $"WHERE Id = {user.ID}";
            int n = ExecuteNonQuery(SQL);
            return n;
        }

        public int Update_disconnected(User user, string table)
        {
            // The Method recieve a user objects and update its fields it to the Database . 
            // The method return the number of rows affected (1) if it succeded.
            // if the id of the user is not in the databse it will return -1

            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM {table} WHERE Id = {user.ID}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת סכימת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count != 1)
            {
                return -1;
            }

            // קבלת מצביע לשורה בטבלה
            DataRow dr = ds.Tables[table].Rows[0]; //Get the only row available

            // עדכון השורה
            dr["First name"] = user.Firstname;
            dr["Last name"] = user.Lastname;
            dr["Username"] = user.Username;
            dr["Password"] = user.Password;
            dr["Birth date"] = user.Birthdate;


            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int n = adapter.Update(ds, table);
            return n;
        }

        public int Delete_disconnected(int id, string table)
        {
            // The Method recieve an Id and delete it from the user table.
            // The method return the number of rows affected (1) if it succeded.
            // if the id of the user is not in the databse it will return -1

            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            string SQLStr = $"SELECT * FROM {table} WHERE Id = {id}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // בניית DataSet
            DataSet ds = new DataSet();

            // טעינת סכימת הנתונים
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count == 0)
            {
                return -1;
            }

            // מחיקת השורה
            ds.Tables[table].Rows[0].Delete();

            // עדכון הדאטה סט בבסיס הנתונים
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int n = adapter.Update(ds, table);
            return n;
        }

        public object GetScalar(string SQL)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            // ביצוע השאילתא
            con.Open();
            object scalar = cmd.ExecuteScalar();
            con.Close();

            return scalar;
        }

        public SqlDataReader GetDataReader(string SQL)
        {
            // התחברות למסד הנתונים
            SqlConnection con = new SqlConnection(conString);

            // בניית פקודת SQL
            SqlCommand cmd = new SqlCommand(SQL, con);

            con.Open();
            // Command behavior insure closing the reader will close the connection 
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
    }
}


