using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebMvcSgq.Utils
{
    public static class AppSettings
    {
        public static string GetConnectionStringByName(string name)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            string connectionString = string.Format(settings.ConnectionString, 
                                                    ConfigurationManager.AppSettings["SqlServerConnection_DataSource"],
                                                    ConfigurationManager.AppSettings["SqlServerConnection_UserId"],
                                                    ConfigurationManager.AppSettings["SqlServerConnection_Password"]);

            return connectionString;
        }
    }
}