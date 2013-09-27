using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataPortal;

namespace BusinessObjects
{
    public class PersonPhone : Phone
    {
        #region "Declarations"

        PersonPhoneData ppd = new PersonPhoneData();
        int personID;
        int phoneID;
        string description;
        string notes;
        bool doNotCall;
        bool doNotText;

        #endregion

        #region "Constructors"

        public PersonPhone() 
        { 
        
        }

        public PersonPhone(int id)
        {
            DataPortal.PersonPhoneData dp = new DataPortal.PersonPhoneData();
            DataSet ds = new DataSet();
            ds = dp.Fetch(id, PhoneID);
        }

        public PersonPhone(DataRow PersonPhoneDataRow)
        {
            personID = (int)PersonPhoneDataRow["PersonID"];
            phoneID = (int)PersonPhoneDataRow["PhoneID"];
            description = PersonPhoneDataRow["Description"].ToString();
            notes = PersonPhoneDataRow["Notes"].ToString();

            doNotCall = (bool)PersonPhoneDataRow["DoNotCall"];
            doNotText = (bool)PersonPhoneDataRow["DoNotText"];
            AreaCode = PersonPhoneDataRow["AreaCode"].ToString();
            PhoneNumber = PersonPhoneDataRow["PhoneNumber"].ToString();
            Extension = PersonPhoneDataRow["Extension"].ToString();
            PhoneTypeID = (int)PersonPhoneDataRow["PhoneTypeID"];
        }

        public PersonPhone(int PersonID, int PhoneID)
        {
            DataPortal.PersonPhoneData dp = new DataPortal.PersonPhoneData();
            DataSet ds = new DataSet();
            ds = dp.Fetch(PersonID, PhoneID);


        }

        #endregion

        #region "Properties"

        //Warning	1	'BusinessObjects.PersonPhone.PhoneID' hides inherited member 'BusinessObjects.Phone.PhoneID'. Use the new keyword if hiding was intended.	C:\Users\Tom\Desktop\Person Manager\PersonManager_2013-03-12\PersonManager_2013-03-12\PersonManager\BusinessObjects\PersonPhone.cs	54	20	BusinessObjects
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
        
        public  int PhoneID 
        {
            get
            {
                return phoneID;
            }
            set
            {
                phoneID = value;
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

        public bool DoNotCall
        {
            get
            {
                return doNotCall;
            }
            set
            {
                doNotCall = value;
            }


        }

        public bool DoNotText
        {
            get
            {
                return doNotText;
            }
            set
            {
                doNotText = value;
            }


        }
        #endregion

        #region "Public Methods"

        public new void Load(int ID)
        { }

        public void SavePhone() 
        {
            SavePersonPhone();


        }

            public new int Delete(int PhoneID)
        {
            DeletePersonPhone(PhoneID);
            return PhoneID;
        }

            public DataSet Fetch(int id, int PhoneID)
            {
                DataSet ds = new DataSet();
                 ds = FetchPersonPhone(id, PhoneID);

                 return ds;
                
            }
        #endregion

        #region "Private Methods"

            private DataSet FetchPersonPhone(int id, int PhoneID) 
            {
                DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();
                DataSet ds = new DataSet();
               ds = ppd.Fetch(id, PhoneID); 
                return ds;
            }

            private void SavePersonPhone()
            {
                if (PhoneID <= 0)
                {
                    PhoneID = base.Save();

                    ppd.InsertPersonPhone(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);

                }
             
                /// 
                //PhoneID = 173;
                
  ///                 phoneID = base.Save();

               

                if (PhoneID >= 1)
                {
                 PhoneID = base.Save();
                
                    ppd.UpdatePersonPhones(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);
                }

              
            }

            private int DeletePersonPhone(int PhoneID) 
            {
                ppd.Delete(PhoneID);

                return PhoneID;
            }
        
        #endregion
    }

}

 //int personID;
 //       int phoneID;
 //       string description;
 //       string notes;
 //       bool doNotCall;
 //       bool doNotText;