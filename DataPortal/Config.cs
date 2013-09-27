using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataPortal
{
    class Config
    {
        protected static object _fileLock;
        protected static object _cacheLock;

        protected static Dictionary<string, string> _cache;

        static Config()
        {
            _fileLock = new object();
            _cacheLock = new object();

            _cache = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        public static string ConnectionString
        {
            get
            {
                return (ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
            }
        }

        public string GetItem(string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                return (null);
            }

            string toReturn = null;

            lock (_cacheLock)
            {
                if (_cache.ContainsKey(key))
                {

                    toReturn = _cache[key];

                }
                else
                {

                    lock (_fileLock)
                    {
                        toReturn = ConfigurationManager.AppSettings[key];
                    }

                    _cache[key] = toReturn;

                }
            }

            return (toReturn);
        }
    }
}
