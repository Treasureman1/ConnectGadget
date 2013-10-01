using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectGadget.BusinessObjects
{
    public class RoleBasedSecurable : ISecurable
    {
        protected List<Role> _roles;

        public RoleBasedSecurable(string name, bool allowAnonymous, IEnumerable<Role> roles)
        {
            this.Name = name;

            this.AllowAnonymous = allowAnonymous;

            _roles = new List<Role>();

            _roles.AddRange(roles);
        }

        public IEnumerable<Role> Roles
        {
            get
            {
                foreach (var role in _roles)
                {
                    yield return role;
                }
            }
        }

        public bool AllowAnonymous { get; set; }

        public string SecurableType
        {
            get
            {
                return ("Role");
            }
        }

        public bool IsAuthorized(User user)
        {
            foreach (var role in Roles)
            {
                if (role.IsUserInRole(user))
                {
                    return (true);
                }
            }

            return (false);
        }

        public string Name { get; set; }
    }
}