using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class SecurableData
    {
        #region "Declarations"

        #endregion

        #region "Constructors"

        public SecurableData() { }

        #endregion

        #region "Public Methods"

        public DataSet Fetch(string securableName)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT Name, AllowAnonymous, SecurableType FROM Securable WHERE SecurableName = @SecurableName";
            SqlConnection cn;

            cn = new SqlConnection(Config.ConnectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@SecurableName", securableName);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(ds);

            cn.Close();

            da = null;
            cmd = null;
            cn = null;

            return ds;
        }

        // The output from this can be passed into the Role constructor
        public DataSet FetchRoles(string securableName)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT RoleName FROM Role where RoleName in ( select RoleName from SecurableRole WHERE SecurableName = @SecurableName )";
            SqlConnection cn;

            cn = new SqlConnection(Config.ConnectionString);

            cn.Open();

            SqlCommand cmd = cn.CreateCommand();

            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@SecurableName", securableName);

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
            string securableName = "";

            return securableName;
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
