using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using System.Security.Principal;

namespace ConnectGadget.BusinessObjects
{
    public class User : Person, IPrincipal
    {
        #region "Declarations"

       private string username;
       private string password;
       private bool userExists = false;

       private ISet<Role> _roles;

       DataPortal.PersonData pd = new DataPortal.PersonData();
       DataPortal.UserData ud = new DataPortal.UserData();
        
        #endregion

         #region "Constructors"

        public User() {}

        public User(int ID)
        {
            LoadUser(ID);
        }
      
        public User(DataRow UserDataRow)
        {
           
            username = UserDataRow["Username"].ToString();
            password = UserDataRow["Password"].ToString();
 
        }

        public User(IIdentity identity, IEnumerable<Role> roles)
        {
            this.Identity = identity;

            // Passing a custom comparer to force _roleNames to be case INsensitive
            _roles = new HashSet<Role>();

            foreach (var role in roles)
            {
                _roles.Add(role);
            }
        }

        #endregion

        #region "Properties"

        public bool UserExists
        {
            get
            {
                return userExists;
            }

            set
            {
                userExists = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password= value;
            }
        }

        public ISet<Role> Role
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new HashSet<Role>();

                    DataPortal.UserRoleData dp = new DataPortal.UserRoleData();

                    DataSet ds = dp.Fetch(id);

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UserRole ur = new UserRole(dr);
                        _roles.Add(ur.Role);
                    }
                }
                return _roles;
            }
        }

        #endregion

        #region "Public Methods"

        public void Load(int ID)  
        {
            LoadUser(ID);
        }

        public void Save()
        {          
            SaveUser(id);
        }

        public void Update()
        {
           // UpdateUser(ID);
        }

        public void Delete()
        { }

        #endregion

        #region "Private Methods"

        private void LoadUser(int id)
        {

            DataPortal.UserData ud = new DataPortal.UserData();            
            DataSet ds = ud.Fetch(id);

            id = (int)ds.Tables[0].Rows[0]["UserID"];
            username = ds.Tables[0].Rows[0]["Username"].ToString();
            password = ds.Tables[0].Rows[0]["Password"].ToString();                

        }

        private int SaveUser2()
        {

            DataPortal.PersonData pd = new DataPortal.PersonData();
            DataPortal.UserData ud = new DataPortal.UserData();
            
            if (userExists == false)
            {

                int UserID = ID;
                ud.InsertUser2(UserID, Username, Password);

            }

            if (userExists == true)
            {
                int UserID = ID;
                ud.UpdateUser(UserID, Username, Password);
            }
                     
            return 0;
        }
        private void SaveUser(int id)
        {
           

            if (id <= 0)
            {
                // id is null, so perform an insert

                // Save base object id returns a value from the base.save
                id = base.Save();

                // Now save the user object
              

               ud.InsertUser2(id, Username, Password);
               
            }

            if (id >= 1)
            {
                // id is not null, so perform an update

                // Save base object
                id = base.Save();

                // Now save the user object
               
                ud.UpdateUser(id, Username, Password);

            }

            
        }

        
        #endregion

        #region IPrincipal Members
        public IIdentity Identity { get; set; }

        public bool IsInRole(string roleName)
        {
            if (String.IsNullOrEmpty(roleName))
            {
                return (false);
            }

            foreach (var role in _roles)
            {
                if (String.IsNullOrEmpty(role.RoleName))
                {
                    continue;
                }

                if (role.RoleName.Equals(roleName))
                {
                    return (true);
                }
            }

            return (false);
        }
        #endregion
    }
}