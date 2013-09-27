using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessObjects
{
   public class EmailAddress
    {
        #region "Declarations"

        int emailAddressID;
        string address;
        int personID;

        #endregion
       
      
         #region "Constructors"

        public EmailAddress() {}

        public EmailAddress(DataRow EmailAddressDataRow)
        {
            emailAddressID = (int)EmailAddressDataRow["EmailAddressID"];
            address = (String)EmailAddressDataRow["Address"];
            personID = (int)EmailAddressDataRow["PersonID"];
        }

        #endregion

        #region "Properties"

        public int EmailAddressID 
        {
            get
            {
                return emailAddressID;
            }
            set
            {
                emailAddressID = value;
            }
        }

        public string Address 
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

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
        #endregion
        #region "Public Methods"

        public DataSet Load(int EmailAddressID) 
        {
            DataSet ds = new DataSet();
          ds = LoadEmailAddress(EmailAddressID);
          return ds;
        }

        public void Save()
        { 
        SaveEmailAddress();
        }

        public int Delete(int EmailAddressID)
        {
            DeleteEmailAddress(EmailAddressID);
            return EmailAddressID;
        }

        #endregion

        #region "Private Methods"

        private DataSet LoadEmailAddress(int EmailAddressID)
        {
            DataSet ds = new DataSet();
            DataPortal.EmailAddressData ead = new DataPortal.EmailAddressData();
          ds =  ead.Fetch(EmailAddressID);
          return ds;

        }

        private void SaveEmailAddress()
        {
            DataPortal.EmailAddressData ead = new DataPortal.EmailAddressData();
            
            if (EmailAddressID <= 0)
            {
                ead.InsertEmailAddress(Address, PersonID);
            }

           // if (EmailAddressID >= 1)
            else
            {
                ead.Update(EmailAddressID, Address, PersonID);
            }
            
           
        }

        private int DeleteEmailAddress(int EmailAddressID)
        {
            DataPortal.EmailAddressData ead = new DataPortal.EmailAddressData();
            if (EmailAddressID >= 1)
            {
                ead.Delete(EmailAddressID);
            }

            return EmailAddressID;
        }

        #endregion
    }
}