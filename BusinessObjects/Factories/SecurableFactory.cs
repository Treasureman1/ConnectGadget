using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectGadget.BusinessObjects;
using DataPortal;
using System.Data;

namespace ConnectGadget.BusinessObjects.Factories
{
    public class SecurableFactory
    {
        public static ISecurable Lookup(string securableName)
        {
            SecurableData sd = new SecurableData();

            var fetched = sd.Fetch(securableName);

            var firstRow = fetched.Tables[0].Rows[0];

            ISecurable toReturn = null;

            if( firstRow["SecurableType" ] == null ) {
                return( null );
            }

            string securableType = firstRow["SecurableType"].ToString();

            switch ( securableType )
            {
                case "Role":
                    var fetchedRows = sd.FetchRoles(securableName);

                    List<Role> roles = new List<Role>();

                    foreach (DataRow thisRoleRow in fetchedRows.Tables[0].Rows)
                    {
                        roles.Add(new Role(thisRoleRow));
                    }

                    toReturn = new RoleBasedSecurable(firstRow["Name"].ToString(), (bool)firstRow["AllowAnonymous"], roles);
                    break;

                default:
                    throw (new NotSupportedException("Unsupported securable type: " + securableType));
            }

            return (toReturn);

        }
    }
}
