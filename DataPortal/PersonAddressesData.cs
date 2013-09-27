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
        //public PersonAddressesData();//
        //C:\Users\Tom\Desktop\Person Manager\PersonManager\PersonManager_2013-03-12\PersonManager\DataManager\InventoryDatabase.mdf
        //C:\\BegASPNET\\PersonManager\\PersonManager\\PersonManager\\DataManager\\App_Data\\InventoryDatabase.mdf
        string _connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Tom\\Desktop\\Person Manager\\PersonManager\\PersonManager_2013-03-12\\PersonManager\\DataManager\\InventoryDatabase.mdf;Integrated Security=True;User Instance=True";

        public DataSet Fetch(int PersonID)
        {
            DataSet ds = new DataSet();

            String sql = "SELECT PersonID, Address.AddressID, AddressTypeID, PersonAddresses.Description, Notes, Street1, Street2, City, State, Zip FROM PersonAddresses JOIN Address ON Address.AddressID = PersonAddresses.AddressID WHERE PersonID = @PersonID";
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
