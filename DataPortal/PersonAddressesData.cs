using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataPortal
{
    public class PersonAddressesData
    {
        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT PersonID, Address.AddressID, AddressTypeID, PersonAddresses.Description, Notes, Street1, Street2, City, State, Zip FROM PersonAddresses JOIN Address ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID";
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



        public int Create()
        {
            int addressID = 0;

            return addressID;
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }

    }
}
