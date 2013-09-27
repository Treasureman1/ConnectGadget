using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class EmailAddressData
    {
        public DataSet Fetch(int EmailAddressID) 
        {
            DataSet ds = new DataSet();

            //String sql = "SELECT PersonID, Address.AddressID, AddressTypeID, PersonAddresses.Description, Notes, Street1, Street2, City, State, Zip FROM PersonAddresses JOIN Address ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID AND AddressID = @AddressID";
            //SqlConnection cn;

            String sql = "SELECT EmailAddress.EmailAddressID, EmailAddress.Address, EmailAddress.PersonID FROM EmailAddress WHERE EmailAddressID = @EmailAddressID";
            SqlConnection cn;

            cn = new SqlConnection( Config.ConnectionString );

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
           
            cmd.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        public object InsertEmailAddress(String Address, int PersonID)
        {
            //"INSERT INTO Person (FirstName, LastName) VALUES (@FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            String sqlStatementString = "INSERT INTO EmailAddress (Address, PersonID) VALUES (@Address, @PersonID) SELECT @@IDENTITY AS EmailAddressID";
            SqlConnection dbConnection;

            object EmailAddressID;
            dbConnection = new SqlConnection( Config.ConnectionString );

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Address", Address);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            EmailAddressID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
            return EmailAddressID;
        }

        public void Update(int EmailAddressID, string Address, int PersonID) 
        {
            DataSet ds = new DataSet();
            String sql = "UPDATE EmailAddress SET Address = @Address, PersonID = @PersonID WHERE EmailAddressID = @EmailAddressID";
            SqlConnection cn;
            cn = new SqlConnection( Config.ConnectionString );
            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PersonID", PersonID);
            cmd.ExecuteNonQuery();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;
           // return ds;
        }

        public object Delete(int EmailAddressID)
        {
            try
            {

                DataSet ds = new DataSet();
                String sqlStatementString = "UPDATE EmailAddress SET IsDeleted = 1 WHERE EmailAddressID = @EmailAddressID";
                SqlConnection dbConnection;
                dbConnection = new SqlConnection( Config.ConnectionString );
                dbConnection.Open();

                SqlCommand dbCommand = dbConnection.CreateCommand();

                dbCommand.CommandText = sqlStatementString;

                dbCommand.Parameters.AddWithValue("@EmailAddressID", EmailAddressID);

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