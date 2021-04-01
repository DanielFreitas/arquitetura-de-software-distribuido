using System;
using System.IO;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace SecureAPIClient
{
    public class AuthConfig
    {
        public string Instance { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string Authority { get; set; }
        public string ClientSecret { get; set; }
        public string BaseAddress { get; set; }
        public string ResourceID { get; set; }

        public static AuthConfig ReadFromXML()
        {
            AuthConfig config = new AuthConfig
            {
                Instance = ConfigurationManager.AppSettings["AuthConfig_Instance"],
                TenantId =  ConfigurationManager.AppSettings["AuthConfig_TenantId"],
                ClientId =  ConfigurationManager.AppSettings["AuthConfig_ClientId"],
                Authority = String.Format(CultureInfo.InvariantCulture, ConfigurationManager.AppSettings["AuthConfig_Instance"], ConfigurationManager.AppSettings["AuthConfig_TenantId"]),
                ClientSecret =  ConfigurationManager.AppSettings["AuthConfig_ClientSecret"],
                BaseAddress =  ConfigurationManager.AppSettings["AuthConfig_BaseAddress"],
                ResourceID =  ConfigurationManager.AppSettings["AuthConfig_ResourceId"],
            };

            return config;
        }
    }
}
