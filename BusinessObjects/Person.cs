using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;

namespace BusinessObjects
{
    public class Person
    {
        #region "Declarations"

        DataPortal.PersonData pd = new DataPortal.PersonData();

        public int id;
       private string title;
       private string firstName;
       private string lastName;
        private bool isDirty = false;
        Collection<PersonAddress> personAddresses = null;
        Collection<PersonPhone> personPhones = null;
        Collection<EmailAddress> emailAddresses = null;
       
        #endregion

        #region "Constructors"

        public Person()
        {
        }

        public Person(int ID)
        {
            LoadPerson(ID);
        }

        #endregion

        #region "Properties"

        public int ID
        {
            get
            {
                return id;
            }
         
        }

        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                isDirty = true;
            }
        }

        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                isDirty = true;
            }
        }

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                isDirty = true;
            }
        }

        public bool IsDirty
        {
            get
            {
                return isDirty;
            }
        }

        public Collection<PersonAddress> Addresses
        {
            get
            {
                if (personAddresses == null)
                {
                    personAddresses = new Collection<PersonAddress>();

                    DataPortal.PersonAddressData dp = new DataPortal.PersonAddressData();
                    // DataPortal.PersonAddressesData dp = new DataPortal.PersonAddressesData();


                    DataSet ds = dp.Fetch(id);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PersonAddress pa = new PersonAddress(dr);
                        personAddresses.Add(pa);
                    }
                }
                return personAddresses;
            }
        }
        
       
        public Collection<EmailAddress> EmailAddresses
        {
            get
            {
                if (emailAddresses == null)
                {
                    emailAddresses = new Collection<EmailAddress>();

                    DataPortal.EmailAddressesData dp = new DataPortal.EmailAddressesData();
                    DataSet ds = dp.Fetch(id);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        EmailAddress ea = new EmailAddress(dr);//new EmailAddress(dr);
                        emailAddresses.Add(ea);
                    }
                }
                return emailAddresses;
            }
        }

        public Collection<PersonPhone> Phones
        {
            get
            {
                if (personPhones == null)
                {
                    personPhones = new Collection<PersonPhone>();

                   // DataPortal.PersonPhoneData dp = new DataPortal.PersonPhoneData();
                   DataPortal.PersonPhonesData dp = new DataPortal.PersonPhonesData();
                    DataSet ds = dp.Fetch(id);
                    //DataSet ds = dp.Fetch(PersonID, PhoneID);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        PersonPhone ph = new PersonPhone(dr);
                        personPhones.Add(ph);
                    }
                }
                return personPhones;
            }
        }
        #endregion

        #region "Public Methods"

        public int Save()
        {
            SavePerson();
            return id;
        }

        public int Fetch(int id)
        {
            FetchPerson(id);
            return id;
        }

        public void Load(int ID)
        {
            LoadPerson(ID);
        }

        public void Delete()
        {

        }

        #endregion

        #region "Private Methods"

        private void LoadPerson(int ID)
        {
            DataPortal.PersonData da = new DataPortal.PersonData();
            DataSet ds = da.Fetch(ID);

            id = (int)ds.Tables[0].Rows[0]["PersonID"];
            title = ds.Tables[0].Rows[0]["Title"].ToString();
            firstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
            lastName = ds.Tables[0].Rows[0]["LastName"].ToString();
        }

        private DataSet FetchPersonDS(int id) 
        {
            DataSet ds = new DataSet();

            return ds;
        }

        private int FetchPerson(int id)
        {

            
            object personID = pd.Fetch(id);
            id = Convert.ToInt32(id);
            return id;
        }

        private int SavePerson()
        {

            if (id <= 0)
            {
                object personID = pd.InsertPerson2(Title, FirstName, LastName);
                // return Convert.ToInt32(userID);
                id = Convert.ToInt32(personID);
            }

            if (id >= 1)
            {

                int PersonID = id;

                pd.UpdatePerson(PersonID, Title, FirstName, LastName);

            }

            return id;
        }

        private void DeletePerson()
        {

        }

        #endregion
    }
}