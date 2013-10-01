using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text;
using ConnectGadget.BusinessObjects.Factories;
using ConnectGadget.Cache;
using ConnectGadget.BusinessObjects;

namespace ConnectGadget.Web
{
    public class Global : System.Web.HttpApplication, IRequiresSessionState
    {
        protected const string LOGIN_PAGE_URL = "~/Account/Login.aspx";

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            Console.WriteLine("Application_Start");

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
            Console.WriteLine("Session_Start");

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        protected string GetSecurableNameForCurrentRequestPath()
        {
            string[] components = Request.Path.Split('/');
            string fileName = components[components.Length - 1];
            string[] fileNameComponents = fileName.Split('.');
            string extension = fileNameComponents[fileNameComponents.Length - 1];

            if (String.IsNullOrEmpty(extension))
            {
                return( null );
            }

            if (!extension.ToLower().Equals("aspx"))
            {
                return( null );
            }

            StringBuilder securableName = new StringBuilder();

            for (int i = 0; i < components.Length - 1; i++)
            {
                if (!String.IsNullOrEmpty(components[i]))
                {
                    securableName.Append(components[i]);
                    securableName.Append(".");
                }
            }

            securableName.Append(fileNameComponents[0]);

            return (securableName.ToString());
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            string securableName = GetSecurableNameForCurrentRequestPath();

            if (String.IsNullOrEmpty(securableName))
            {
                return;
            }

            ISecurable relevantSecurable = SecurableFactory.Lookup(securableName);

            if (relevantSecurable == null)
            {
                return;
            }

            if (relevantSecurable.AllowAnonymous)
            {
                return;
            }

            if (!ConnectGadgetCache.IsAuthenticated)
            {
                // Redirect to the login page with the current URL as the return URL
                Response.Redirect(LOGIN_PAGE_URL + "?ReturnUrl=" + HttpUtility.UrlEncode( Request.Url.ToString() ), true);
            }

            if (!relevantSecurable.IsAuthorized(ConnectGadgetCache.CurrentUser))
            {
                throw (new UnauthorizedAccessException("You do not have access to this resource"));
            }
        }

    }
}
