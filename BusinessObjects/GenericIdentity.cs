using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

namespace ConnectGadget.BusinessObjects
{
    public class SystemIdentity : IIdentity
    {
        protected String _name;

        public SystemIdentity(string name)
        {
            this._name = name;
        }

        public string AuthenticationType
        {
            get { return ("ConnectGadget"); }
        }

        public bool IsAuthenticated
        {
            get { return (true); }
        }

        public string Name
        {
            get { return (_name); }
            set { _name = value; }
        }
    }
}