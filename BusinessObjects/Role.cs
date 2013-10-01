using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataPortal;

namespace ConnectGadget.BusinessObjects
{
    public class Role
    {
        protected HashSet<User> _users;

        public Role(DataRow RoleDataRow)
        {
            RoleName = RoleDataRow["RoleName"].ToString();
        }

        public string RoleName { get; set; }

        public ISet<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new HashSet<User>();

                    UserRoleData urd = new UserRoleData();
                    DataSet ds = urd.Fetch(RoleName);

                    foreach (DataRow UserRoleDataRow in ds.Tables[0].Rows)
                    {
                        _users.Add(new User(UserRoleDataRow));
                    }
                }

                return (_users);
            }
        }

        public void AddUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                // assumption: user.Identity.Name is unique across users.
                _users.Add(user);
            }
        }

        public bool IsUserInRole(User user)
        {
            if( user == null ) {
                return( false );
            }

            if( String.IsNullOrEmpty( user.Username ) ) {
                return( false );
            }

            foreach (var thisUser in Users)
            {
                if (user.Username.Equals(thisUser.Username))
                {
                    return (true);
                }

            }

            return (false);
        }

    }
}