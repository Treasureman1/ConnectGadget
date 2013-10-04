using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class UserRoleData
    {
        public DataSet Fetch(int UserID)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT u.UserID, r.RoleName FROM User u INNER JOIN UserRole ur ON ur.UserID = u.UserID WHERE u.UserID = @UserID";
            SqlConnection cn;

            cn = new SqlConnection(Config.ConnectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@UserID", UserID);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        public DataSet Fetch( string roleName )
        {
            DataSet ds = new DataSet();

            String sql = "SELECT u.UserName, ur.RoleName FROM [dbo].[User] u INNER JOIN UserRole ur ON ur.UserID = u.UserID WHERE ur.RoleName = @RoleName";
            SqlConnection cn;

            cn = new SqlConnection(Config.ConnectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@RoleName", roleName);

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
            int userID = 0;

            return userID;
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }

    }
}
