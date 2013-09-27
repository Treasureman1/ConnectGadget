using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class PersonData
    {
        #region "Declarations"

        //string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
        string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";
      
        #endregion

        #region "Constructors"

        public PersonData() { }

        #endregion

        #region "Public Methods"

        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT PersonID, Title, FirstName, LastName FROM Person WHERE PersonID = @PersonID";
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

        //public DataSet Fetch(int PersonID, int AddressID)
        //{
        //    DataSet ds = new DataSet();

        //    String sql = "SELECT PersonID, Title, FirstName, LastName FROM Person WHERE PersonID = @PersonID AND AddressID = @AddressID";
        //    SqlConnection cn;

        //    cn = new SqlConnection(_connectionString);

        //    cn.Open();

        //    SqlCommand cmd = cn.CreateCommand();

        //    cmd.CommandText = sql;
        //    cmd.Parameters.AddWithValue("@PersonID", PersonID);
        //    cmd.Parameters.AddWithValue("@AddressID", AddressID);

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);

        //    da.Fill(ds);

        //    cn.Close();

        //    da = null;
        //    cmd = null;
        //    cn = null;

        //    return ds;
        //}

        public object
          InsertPerson2(String Title, String FirstName, String LastName)
        {

            String sqlStatementString = "INSERT INTO Person (Title, FirstName, LastName) VALUES (@Title, @FirstName, @LastName) SELECT @@IDENTITY AS PersonID";
            SqlConnection dbConnection;

            // We need a variable to hold the ID value of the record we are inserting
            object personID;

            dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@Title", Title);
            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);
          
            personID = dbCommand.ExecuteScalar();

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;

            // Finally, we need to return the value of personID
            return personID;
        }


        public DataSet FetchAll()
        {
            DataSet ds = new DataSet();

            String sql = "SELECT PersonID, Title, FirstName, LastName FROM Person";
            SqlConnection cn;

            cn = new SqlConnection(_connectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;

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
            int addressID = 0;

            return addressID;
        }

        public void Update()
        {
        }

        public void UpdatePerson(int PersonID, String Title, String FirstName, String LastName) 
        {
           // DataSet ds = new DataSet();

            String sqlStatementString = "UPDATE Person SET Title = @Title, FirstName = @FirstName, LastName = @LastName WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;

            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);
            dbCommand.Parameters.AddWithValue("@Title", Title);
            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);
            
            dbCommand.ExecuteNonQuery();


     //       SqlDataAdapter dbDataAdapter = new SqlDataAdapter(dbCommand);
          //  dbDataAdapter.Fill(ds); //2

            dbConnection.Close();

    //        dbDataAdapter = null;
            dbCommand = null;
            dbConnection = null;

         //   return ds;

        }

        public void Update(int PersonID, String Title, String FirstName, String LastName) 
        {

            String sqlStatementString = "UPDATE Person SET FirstName = @FirstName, LastName = @LastName WHERE PersonID = @PersonID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(_connectionString);

            dbConnection.Open();

            SqlCommand dbCommand = dbConnection.CreateCommand();

            dbCommand.CommandText = sqlStatementString;
            dbCommand.Parameters.AddWithValue("@Title", Title);

            dbCommand.Parameters.AddWithValue("@FirstName", FirstName);
            dbCommand.Parameters.AddWithValue("@LastName", LastName);
            dbCommand.Parameters.AddWithValue("@PersonID", PersonID);

            dbCommand.ExecuteNonQuery();            //Execute Non Query method is used if there is not a return value for a function 

            dbConnection.Close();

            dbCommand = null;
            dbConnection = null;
        }

        public void Delete()
        {
        }

        #endregion
    }
}
