using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessObjects
{
    public class Address
    {
        #region "Declarations"

        int addressID;
        string street1;
        string street2;
        string city;
        string state;
        string zip;
        bool addressExists = false;

        DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();

        DataSet ds = new DataSet();

        #endregion

        #region "Constructors"

        public Address() {}

        #endregion

        #region "Properties"

        public int AddressID
        {
            get
            {
                return addressID;
            }
            set
            {
                addressID = value;
            }
        }

        public string Street1
        {
            get
            {
                return street1;
            }
            set
            {
                street1 = value;
            }
        }

        public string Street2
        {
            get
            {
                return street2;
            }
            set
            {
                street2 = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                zip = value;
            }
        }


        #endregion

        #region "Public Methods"

        public void Load(int AddressID)
        { }

        public void Save()
        {
            SaveAddress(); 
        }

        public void Delete()
        { }

        #endregion

        #region "Private Methods"


        private int SaveAddress()
        {
           
            if (AddressID <= 0) 
            {
               object _addressID = pad.InsertAddress(Street1, Street2, City, State, Zip);
               AddressID = Convert.ToInt32(_addressID.ToString());
            

            }
            return AddressID;
        }
        #endregion
    }
}