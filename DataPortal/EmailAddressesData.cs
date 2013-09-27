using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class EmailAddressesData
    {
       // C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
         //string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
        string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";

        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            //String sql = "SELECT EmailAddress.EmailAddressID, EmailAddress.Address, EmailAddress.PersonID FROM EmailAddress WHERE PersonID = @PersonID";
            //SqlConnection cn;

            String sql = "SELECT EmailAddress.EmailAddressID, EmailAddress.Address, EmailAddress.PersonID FROM EmailAddress WHERE PersonID = @PersonID AND (IsDeleted = 0 OR IsDeleted IS NULL)";
            SqlConnection cn;

            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }
        public int Create()
        {
            int emailAddressID = 0;

            return emailAddressID;
        }

        public object InsertEmailAddress(String Address, int PersonID, Boolean IsDeleted)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO EmailAddress (Address, PersonID) VALUES (@Address, @PersonID) SELECT @@IDENTITY AS EmailAddressID";
            SqlConnection dbConnection;


            object EmailAddressID;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Address", Address);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
           // dbCommand.Parameters.AddWithValue("@IsDeleted", IsDeleted);
            EmailAddressID = dbCommand.ExecuteScalar();


            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return EmailAddressID;
        }

        public void Update(int EmailAddressID, String Address, int PersonID)
        {
            DataSet ds = new DataSet();
            String sqlStatementString = "UPDATE EmailAddress SET Address = @Address, PersonID = @PersonID WHERE EmailAddressID = @EmailAddressID SELECT @@IDENTITY AS EmailAddressID";
            SqlConnection dbConnection;
            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
            dbCommand.Parameters.AddWithValue("@Address", Address);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public int Delete(int EmailAddressID) //, String Address, int PersonID, Boolean IsDeleted)
        {
            try
            {

                DataSet ds = new DataSet();
                String sqlStatementString = "UPDATE EmailAddress SET IsDeleted = 1 WHERE EmailAddressID = @EmailAddressID";
                SqlConnection dbConnection;
                dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();

                SqlCommand dbCommand = dbConnection.CreateCommand();

                dbCommand.CommandText = sqlStatementString;

                dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
                //dbCommand.Parameters.AddWithValue("@Address", Address);
                //dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
                //dbCommand.Parameters.AddWithValue("@IsDeleted", IsDeleted);

                int affectedRecords = dbCommand.ExecuteNonQuery();

                dbConnection.Close();

                dbCommand = null;
                dbConnection = null;

                return affectedRecords;

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete()
        {

        }
    }
}