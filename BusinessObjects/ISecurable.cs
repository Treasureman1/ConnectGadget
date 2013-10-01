using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectGadget.BusinessObjects
{
    public interface ISecurable
    {
        string Name { get; set; }
        bool AllowAnonymous{ get; }
        bool IsAuthorized(User user);
        string SecurableType { get; }
    }
}
