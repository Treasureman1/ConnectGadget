using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessObjects
{
   public class Phone
   {
       #region "Declarations"

       int phoneID;
       string areaCode;
       string phoneNumber;
       string extension; 
       int phoneTypeID;
     

       DataPortal.PersonPhoneData ppd = new DataPortal.PersonPhoneData();
       

       #endregion

       #region "Constructors"

       public Phone() { }

       #endregion

       #region "Properties"

       public int PhoneID
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

       public string AreaCode
       {
           get
           {
               return areaCode;
           }
           set
           {
               areaCode = value;
           }
       }

       public string PhoneNumber
       {
           get
           {
               return phoneNumber;
           }
           set
           {
               phoneNumber = value;
           }
       }

       public string Extension
       {
           get
           {
               return extension;
           }
           set
           {
               extension = value;
           }
       }

       public int PhoneTypeID
       {
           get
           {
               return phoneTypeID;
           }
           set
           {
               phoneTypeID = value;
           }

       }

       #endregion

           #region "Public Methods"

           public void Load(int PhoneID) 
           {}

       public int Save()
       {
          SavePhone();
           
           return PhoneID;
       }

       public void Delete()
       {}

#endregion

           #region "Private Methods"

       private int SavePhone() 
       {
           if (PhoneID <= 0)
           {
               object phoneID = ppd.InsertPhoneNumber(AreaCode, PhoneNumber, Extension, PhoneTypeID);
              // ppd.InsertPersonPhone(PersonID, PhoneID, Description, Notes, DoNotCall, DoNotText);
               BusinessObjects.PersonPhone pp = new BusinessObjects.PersonPhone();
               PhoneID = Convert.ToInt32(phoneID);
               //try to figure out how to get the description and notes dnc and dnt to show up here. 
              //pp.Save();
           } 

            
           

           if (PhoneID >= 1)
           {
            
               ppd.UpdatePhoneNumber(PhoneID, AreaCode, PhoneNumber, Extension, PhoneTypeID);
           }

           return PhoneID;
       }
#endregion


       }
   }

