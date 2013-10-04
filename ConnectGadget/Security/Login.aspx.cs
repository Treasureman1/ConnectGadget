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
            if (!IsPostBack)
            {
                if (IsLogoutQueryParameterSpecified)
                {
                    /* The user clicked the Logout button, so they were redirected to this page with
                     * the Logout query parameter specified
                     */
                    ConnectGadgetCache.CurrentUser = null;
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Feedback.Text = _feedbackMessage;

            // Only request the user's credentials if they are not yet authenticated.
            requestCredentialsPanel.Visible = !ConnectGadgetCache.IsAuthenticated;
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (ConnectGadgetCache.Authenticate(userIdTextBox.Text, passwordTextBox.Text))
            {
                string returnUrl = HttpUtility.UrlDecode(Request.QueryString["ReturnURL"]);
                ConnectGadgetCache.CurrentUser = new User(userIdTextBox.Text);

                if (!String.IsNullOrEmpty(returnUrl))
                {
                    Response.Redirect(returnUrl, true);
                }

            }
            else
            {

                _feedbackMessage = "Invalid user ID or password.  Please try again";
                ConnectGadgetCache.CurrentUser = null;
                     
            }
        }

        protected bool IsLogoutQueryParameterSpecified
        {
            get
            {
                if (String.IsNullOrEmpty(Request.QueryString["logout"]))
                {
                    return (false);
                }

                return (Request.QueryString["logout"].Equals("true"));
            }
        }
    }
}