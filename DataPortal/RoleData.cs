using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class RoleData
    {
        #region "Declarations"

        #endregion

        #region "Constructors"

        public RoleData() { }

        #endregion

        #region "Public Methods"

        public DataSet Fetch(string roleName)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT RoleName FROM Role WHERE RoleName = @RoleName";
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

        public DataSet FetchAll()
        {
            DataSet ds = new DataSet();

            String sql = "SELECT RoleName FROM Role order by RoleName";
            SqlConnection cn;

            cn = new SqlConnection(Config.ConnectionString);

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



        public string Create()
        {
            string roleName = "";

            return roleName;
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }

        #endregion
    }
}
