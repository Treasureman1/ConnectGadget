using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConnectGadget.Cache;
using DataPortal;
using ConnectGadget.BusinessObjects;

namespace ConnectGadget.Security
{
    public partial class Login2 : System.Web.UI.Page
    {
        protected string _feedbackMessage;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Feedback.Text = _feedbackMessage;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string returnUrl = HttpUtility.UrlDecode(Request.QueryString["ReturnURL"]);
            _feedbackMessage = "Clicked!  Going to " + returnUrl;
            ConnectGadgetCache.CurrentUser = new User( userIdTextBox.Text );
            Response.Redirect(returnUrl, true);
        }
    }
}