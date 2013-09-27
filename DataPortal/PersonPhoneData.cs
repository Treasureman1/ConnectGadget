using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class PersonPhoneData
    {
        //C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
        String _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
      //  C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf
        //C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf
        public DataSet Fetch(int PersonID, int PhoneID)
        {
            DataSet ds = new DataSet();       
            ///////// AND (IsDeleted = 0 OR IsDeleted IS NULL)
            String sql = "SELECT PersonID, Phone.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM PersonPhones JOIN Phone ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID AND Phone.PhoneID = @PhoneID AND (IsDeleted = 0 OR IsDeleted IS NULL)";
            SqlConnection cn;

            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@PhoneID", PhoneID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        public DataSet FetchPhoneTypes()
        {
            DataSet phoneTypesDataSet = new DataSet();

            String sqlStatementString = "SELECT * FROM PhoneTypes";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();
            //We want to      ask the database to give us a command object we can use. 
            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);

            dbDataAdapter.Fill(phoneTypesDataSet);  //15

            dbConnection.Close();

            dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

            return phoneTypesDataSet;
        }

            public object InsertPersonPhone(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
        {
            // INNER JOIN PersonAddresses  ON Person.PersonID = PersonAddresses.PersonID AND Address.AddressID = PersonAddresses.AddressID
            String sqlStatementString = "INSERT INTO PersonPhones (PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText) VALUES (@PersonID, @PhoneID, @Description, @Notes, @DoNotCall, @DoNotText)";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@DoNotCall", DoNotCall);
            dbCommand.Parameters.AddWithValue("@DoNotText", DoNotText);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            return PersonID;
        }

        public object InsertPhoneNumber(String AreaCode, String PhoneNumber, String Extension, int PhoneTypeID)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO Phone (AreaCode, PhoneNumber, Extension, PhoneTypeID) VALUES (@AreaCode, @PhoneNumber, @Extension, @PhoneTypeID) SELECT @@IDENTITY AS PhoneID";
            SqlConnection dbConnection;

           object PhoneID;
            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@AreaCode", AreaCode);
            dbCommand.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            dbCommand.Parameters.AddWithValue("@Extension", Extension);
            dbCommand.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
           // PhoneID = dbCommand.ExecuteNonQuery();

           PhoneID = dbCommand.ExecuteScalar();

            //dbCommand.ExecuteNonQuery();
            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
           return PhoneID;
        }
        
        public void UpdatePhoneNumber(int PhoneID, String AreaCode, String PhoneNumber, String Extension, int PhoneTypeID)
        {
            DataSet ds = new DataSet();
            
            //String sqlStatementString = "UPDATE Phone SET AreaCode = @AreaCode, PhoneNumber = @PhoneNumber, Extension = @Extension, PhoneTypeID = @PhoneTypeID WHERE Phone.PhoneID = @PhoneID SELECT @@IDENTITY AS PhoneID";
            
           // String sql = "UPDATE Phone SET PhoneID = @PhoneID, AreaCode = @Areacode, PhoneNumber = @PhoneNumber, Extension = @Extension WHERE PhoneID = @PhoneID";
            String sqlStatementString = "UPDATE [Phone] SET AreaCode = @AreaCode, PhoneNumber = @PhoneNumber, Extension = @Extension, PhoneTypeID = @PhoneTypeID WHERE PhoneID = @PhoneID";
            
            SqlConnection cn;
            cn = new SqlConnection(_connectionString);

            cn.Open();
            
            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sqlStatementString;

            cmd.Parameters.AddWithValue("@PhoneID", PhoneID);
            cmd.Parameters.AddWithValue("@AreaCode", AreaCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
            cmd.Parameters.AddWithValue("@Extension", Extension);
            cmd.Parameters.AddWithValue("@PhoneTypeID", PhoneTypeID);
          
          //  cmd.ExecuteNonQuery();

          cmd.ExecuteNonQuery();
            

            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(ds);

            cn.Close();

           // da = null;
            cmd = null;
            cn = null;       
        }

        public void UpdatePersonPhones(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
        {
            DataSet ds = new DataSet();
            String sqlStatementString = "UPDATE PersonPhones SET Description = @Description, Notes = @Notes, DoNotCall = @DoNotCall, DoNotText = @DoNotText WHERE PersonID = @PersonID AND PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);
            dbCommand.Parameters.AddWithValue("@Description", Description);
            dbCommand.Parameters.AddWithValue("@Notes", Notes);
            dbCommand.Parameters.AddWithValue("@DoNotCall", DoNotCall);
            dbCommand.Parameters.AddWithValue("@DoNotText", DoNotText);
            dbCommand.ExecuteNonQuery();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public DataSet Update(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
        {
            DataSet ds = new DataSet();
            String sql = "UPDATE PersonPhones SET Description = @Description, Notes = @Notes, DoNotCall = @DoNotCall, DoNotText = @DoNotText WHERE PersonID = @PersonID AND PhoneID = @PhoneID";
            SqlConnection cn;
            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.Parameters.AddWithValue("@PhoneID", PhoneID);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@DoNotCall", DoNotCall);
            cmd.Parameters.AddWithValue("@DoNotText", DoNotText);
            cmd.ExecuteNonQuery();


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;
            return ds;
        }

        public int Delete(int PhoneID)  //, String Address, int PersonID, Boolean IsDeleted)
        {
            try
            {

                DataSet ds = new DataSet();
                String sqlStatementString = "UPDATE PersonPhones SET IsDeleted = 1 WHERE PhoneID = @PhoneID";
                SqlConnection dbConnection;
                dbConnection = new SqlConnection(_connectionString);
                dbConnection.Open();

                SqlCommand dbCommand = dbConnection.CreateCommand();

                dbCommand.CommandText = sqlStatementString;

                dbCommand.Parameters.AddWithValue("@PhoneID", PhoneID);

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
