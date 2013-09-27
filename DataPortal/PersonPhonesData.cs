using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace DataPortal
{
   public class PersonPhonesData
    {
        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();        
            //phone.PhoneID   I changed this
            String sql = "SELECT PersonID, phone.PhoneID, PersonPhones.Description, PersonPhones.Notes, PersonPhones.DoNotCall, PersonPhones.DoNotText, Phone.AreaCode, Phone.PhoneNumber, Phone.Extension, Phone.PhoneTypeID FROM PersonPhones JOIN Phone ON Phone.PhoneID = PersonPhones.PhoneID WHERE PersonID = @PersonID AND (IsDeleted = 0 OR IsDeleted IS NULL)";
        SqlConnection cn;
        cn = new SqlConnection(Config.ConnectionString);

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

       public void UpdatePersonPhones(int PersonID, int PhoneID, String Description, String Notes, bool DoNotCall, bool DoNotText)
       
       {
            DataSet ds = new DataSet();
            String sqlStatementString = "UPDATE PersonPhones SET Description = @Description, Notes = @Notes, DoNotCall = @DoNotCall, DoNotText = @DoNotText WHERE PersonID = @PersonID AND PhoneID = @PhoneID";
            SqlConnection dbConnection;

            dbConnection = new SqlConnection(Config.ConnectionString);

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

        public int Create()
        {
            int phoneID = 0;

            return phoneID;
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}
