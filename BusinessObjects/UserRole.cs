using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataPortal;

namespace ConnectGadget.BusinessObjects
{
    public class UserRole
    {
        #region "Declarations"

        private Role _role;
        DataPortal.UserRoleData urd = new DataPortal.UserRoleData();
        DataSet ds = new DataSet();

        #endregion

        #region "Constructors"

        public UserRole() { }

        public UserRole(DataRow UserRoleDataRow)
        {
            UserID = (int)UserRoleDataRow["UserID"];
            RoleName = UserRoleDataRow["RoleName"].ToString();
        }

        #endregion

        #region "Properties"

        public int UserID { get; set; }
        public string RoleName { get; set; }
        public Role Role
        {
            get
            {
                if (_role == null)
                {
                    RoleData rd = new RoleData();
                    DataSet ds = rd.Fetch(RoleName);
                    _role = new Role( ds.Tables[0].Rows[0] );
                }

                return (_role);
            }
        }

        #endregion

        #region "Public Methods"

        public new void Save()
        { }

        public new void Delete()
        { }

        #endregion

        #region "Private Methods"

        #endregion
    }
}
