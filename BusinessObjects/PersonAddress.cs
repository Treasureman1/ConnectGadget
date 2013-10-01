using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConnectGadget.BusinessObjects
{
    public class PersonAddress : Address
    {
        #region "Declarations"

        int personID;
        int addressTypeID;
        string description;
        string notes;
        DataPortal.PersonAddressData pad = new DataPortal.PersonAddressData();
        DataSet ds = new DataSet();

        #endregion

        #region "Constructors"

        public PersonAddress() { }

        public PersonAddress(DataRow PersonAddressDataRow)
        {
            personID = (int)PersonAddressDataRow["PersonID"];
            addressTypeID = (int)PersonAddressDataRow["AddressTypeID"];
            description = PersonAddressDataRow["Description"].ToString();
            notes = PersonAddressDataRow["Notes"].ToString();

            AddressID = (int)PersonAddressDataRow["AddressID"];
            Street1 = PersonAddressDataRow["Street1"].ToString();
            Street2 = PersonAddressDataRow["Street2"].ToString();
            City = PersonAddressDataRow["City"].ToString();
            State = PersonAddressDataRow["State"].ToString();
            Zip = PersonAddressDataRow["Zip"].ToString();
        }

        public PersonAddress(int PersonID, int AddressID)
        {
           // DataPortal.PersonAddressesData dp = new DataPortal.PersonAddressesData();
            DataPortal.PersonAddressData dp = new DataPortal.PersonAddressData();
            DataSet ds = new DataSet();
            //int PersonID;
            //int AddressID;
          // ds = dp.Fetch(PersonID, AddressID);
           ds = dp.Fetch(PersonID);
         
            //I don't know what dataSource to set this to, and where to bind it to?
            //data tier middle tier, user interfave
            //this week

            //This is a business object, PersonAddress is a class that defines
            //personAddress class has properties and methods.
            // Create UPDATE, DELETE, View the data Action words, things that can be done
            //properties are a unique way of describing what 
            //strongly types our data. 
            //instantiata an object of type personAddress, and we can get to the data through the properties. 
            

            //set the properties using the results that have been sent to it. 
            //you would need to fetch the data then use it. fetch the values and then  set them using these values and propertietr
            //in the past I would usde the dataManager,  like fetch person address, I cazn re use that, howerver I am not to ue
            //use the dataPortal object, the fetch method that i need, but it in the person address.cs file which is an empty class
            //put in a fetch  call it fetch. the only things that will go in this class
            //data access object and called a method like fetch person address, that dataset would set values, 
            //in here call a methor in perosn address data that method needs to return a dataset
            //and then you will use that dataset to initialize the variablea and properties of your class.  
            //more reading on object oriented pay close attention to inheritence
            //second source as well for that .  
        }

        #endregion

        #region "Properties"

        public int PersonID
        {
            get
            {
                return personID;
            }
            set
            {
                personID = value;
            }
        }

      
        public int AddressTypeID
        {
            get
            {
                return addressTypeID;
            }
            set
            {
                addressTypeID = value;
            }
        }

        public string Description 
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        #endregion

        #region "Public Methods"

        //public DataSet Fetch(int PersonID, int AddressID)
        //{

        //}

        public DataSet FetchDataTypes()
        {
           
           ds = fetchDataTypes();

           return ds;
           
        }

        public DataSet LoadAddress(int PersonID, int AddressID)    
        {
            DataSet ds = new DataSet();
           ds = LoadPersonAddress(PersonID,AddressID);
            return ds;

        }

        public new void Save()
        { }

        public new void Delete()
        { }

        #endregion

        #region "Private Methods"

        private DataSet LoadPersonAddress(int PersonID, int AddressID)
        {
            DataSet ds = new DataSet();
            ds = pad.Fetch(PersonID, AddressID);
            return ds;
        }

        private DataSet fetchDataTypes()
        {
            DataSet ds = pad.FetchAddressTypes();
            return ds;
        }

        private int SavePersonAddress()
        {
          
            
            int personAddress = 0;
            //if (AddressID <= 0)
            //{
            //}
           // personAddress = base.Save();
            //do a base.save, and that save is calling the address object save method, that needs to return an id, the addressID that I save. 
            //that ID is wh
                pad.InsertPersonAddress(PersonID, AddressID, AddressTypeID, Description, Notes);
               // bool personAddressExists = true;
            

            return personAddress;
        }

        #endregion
    }
}
