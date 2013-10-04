using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ConnectGadget.BusinessObjects;

namespace ConnectGadget.Cache
{
    public class ConnectGadgetCache
    {
        protected static ConnectGadgetCache _instance;

        #region Lock Objects
        protected static object _lockSession = new object();
        #endregion

        #region Session Key Constants
        protected const string SESSION_KEY_CACHE = "SESSION_KEY_CACHE";
        protected const string SESSION_KEY_USER = "USER";
        #endregion

        #region Constructors
        static ConnectGadgetCache()
        {
            // Only one instance of this class is created for the whole application, no matter how many threads
            _instance = new ConnectGadgetCache();
        }

        public ConnectGadgetCache()
        {
        }
        #endregion

        #region Session Properties
        public static bool HasSessionStateYet
        {
            get
            {
                if (Session == null)
                {
                    return (false);
                }

                return (Session[SESSION_KEY_CACHE] != null);
            }
        }


        protected static HttpSessionState Session
        {
            get
            {
                return (HttpContext.Current.Session);
            }
        }

        /// <summary>
        /// SessionObjects is a dictionary (associative array) that is stored in the user's HttpSessionState.
        /// To prevent from cluttering up the user's HttpSessionState with many entries, only one object is
        /// stored in the user's HttpSessionState, and all properties are accessed within that one object.
        /// In this way, the application can store its own values in the user's HttpSessionState without
        /// worrying about overwriting values that are being stored in the user's HttpSessionState by
        /// the ConnectGadgetCache.
        /// </summary>
        protected static Dictionary<String, object> SessionObjects
        {
            get
            {
                Dictionary<String, object> toReturn = null;

                lock ( Session.SyncRoot )
                {
                    if (Session[SESSION_KEY_CACHE] == null)
                    {
                        toReturn = new Dictionary<string, object>();
                        Session[SESSION_KEY_CACHE] = toReturn;
                    }
                    else
                    {
                        toReturn = (Dictionary<String, object>)Session[SESSION_KEY_CACHE];
                    }
                }

                return( toReturn );
            }
        }

        public static User CurrentUser
        {
            get
            {
                User toReturn = null;

                lock (_lockSession)
                {

                    if (SessionObjects.ContainsKey(SESSION_KEY_USER))
                    {
                        toReturn = (User)SessionObjects[SESSION_KEY_USER];
                    }

                }

                return (toReturn);
            }

            set
            {
                lock (_lockSession)
                {
                    SessionObjects[SESSION_KEY_USER] = value;
                }
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
                if (!HasSessionStateYet)
                {
                    return (false);
                }

                return (CurrentUser != null);
            }
        }

        /// <summary>
        /// Determine whether or not the credentials passed in are valid
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Authenticate(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                return (false);
            }

            if (String.IsNullOrEmpty(password))
            {
                return (false);
            }

            var user = new User(userName);

            if (user == null)
            {
                return (false);
            }

            if (String.IsNullOrEmpty(user.Password))
            {
                return (false);
            }

            return (user.Password.Equals(password));
        }

        #endregion

    }
}