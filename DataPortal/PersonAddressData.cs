using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class PersonAddressData
    {

      

        //C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
        //  String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";

        String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";

        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT PersonID, Address.AddressID, AddressTypeID, PersonAddresses.Description, Notes, Street1, Street2, City, State, Zip FROM PersonAddresses JOIN Address ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID AND (IsDeleted = 0 OR IsDeleted IS NULL)";
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

        public DataSet Fetch(int PersonID, int AddressID)
        {
            DataSet ds = new DataSet();
            // AND (PersonAddresses.IsDeleted = 0 OR PersonAddresses.IsDeleted IS NULL)
            String sql = "SELECT PersonID, PersonAddresses.AddressID, AddressTypeID, PersonAddresses.Description, PersonAddresses.IsDeleted, Notes, Street1, Street2, City, State, Zip FROM PersonAddresses JOIN Address ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID AND Address.AddressID = @AddressID";
            SqlConnection cn;
            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@AddressID", AddressID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        public DataSet FetchAddressTypes()
        {
            DataSet addressesDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM AddressTypes";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(addressesDataSet); //4

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return addressesDataSet;
        }

        public void InsertPersonAddress(int PersonID, int AddressID, int AddressTypeID, String Description, String Notes)
        {
            // INNER JOIN PersonAddresses ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO PersonAddresses (PersonID, AddressID, AddressTypeID, Description, Notes) VALUES (@PersonID, @AddressID, @AddressTypeID, @Description, @Notes)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@AddressTypeID", AddressTypeID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public object InsertAddress(String Street1, String Street2, String City, String State, String Zip)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO Address (Street1, Street2, City, State, Zip) VALUES (@Street1, @Street2, @City, @State, @Zip) SELECT @@IDENTITY AS AddressID";
            SqlConnection dbConnection;

            object AddressID;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Street1", Street1);
            dbCommand.Parameters.AddWithValue("@Street2", Street2);
            dbCommand.Parameters.AddWithValue("@City", City);
            dbCommand.Parameters.AddWithValue("@State", State);
            dbCommand.Parameters.AddWithValue("@Zip", Zip);

            AddressID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return AddressID;
        }

        public DataSet Update(int PersonID, int AddressID, int AddressTypeID, String Description, String Notes)
        {
            DataSet ds = new DataSet();
            String sql = "UPDATE PersonAddresses SET AddressTypeID = @AddressTypeID, Description = @Description, Notes = @Notes WHERE PersonID = @PersonID AND AddressID = @AddressID";
            SqlConnection cn;
            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@AddressID", AddressID);
            cmd.Parameters.AddWithValue("@AddressTypeID", AddressTypeID);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;
            return ds;
        }

        public void UpdateAddress(int AddressID, String Street1, String Street2, String City, String State, String Zip)
        {
            DataSet ds = new DataSet();
            String sqlStatementString = "UPDATE Address SET Street1 = @Street1, Street2 = @Street2, City = @City, State = @State, Zip = @Zip WHERE AddressID = @AddressID SELECT @@IDENTITY AS AddressID";
            SqlConnection dbConnection;
            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
            dbCommand.Parameters.AddWithValue("@Street1", Street1);
            dbCommand.Parameters.AddWithValue("@Street2", Street2);
            dbCommand.Parameters.AddWithValue("@City", City);
            dbCommand.Parameters.AddWithValue("@State", State);
            dbCommand.Parameters.AddWithValue("@Zip", Zip);

            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public int Delete(int AddressID) //, String Address, int PersonID, Boolean IsDeleted)
        {
            try
            {

                DataSet ds = new DataSet();
                String sqlStatementString = "UPDATE PersonAddresses SET IsDeleted = 1 WHERE AddressID = @AddressID";
                SqlConnection dbConnection;
                dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();

                SqlCommand dbCommand = dbConnection.CreateCommand();

                dbCommand.CommandText = sqlStatementString;

                dbCommand.Parameters.AddWithValue("@AddressID", AddressID);
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
    }
}