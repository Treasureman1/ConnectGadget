using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class UsersData
    {
        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            //String sql = "SELECT EmailAddress.EmailAddressID, EmailAddress.Address, EmailAddress.PersonID FROM EmailAddress WHERE PersonID = @PersonID";
            //SqlConnection cn;

            String sql = "SELECT * FROM [User] WHERE PersonID = @PersonID AND (IsDeleted = 0 OR IsDeleted IS NULL)";
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
    }
}
