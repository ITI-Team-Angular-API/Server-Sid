using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApi.Helpers
{
    public class ConfigHelper
    {
        public static string GetIssuer()
        {
            string result = System.Configuration.ConfigurationManager.AppSettings["Issuer"];
            return result;
        }

        public static string GetAudience()
        {
            string result = System.Configuration.ConfigurationManager.AppSettings["Audience"];
            return result;
        }

        public static SigningCredentials GetSigningCredentials()
        {
            var result = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            return result;
        }
        public static int GetTokenValidDuration()
        {
            int tokenValidDuration = 30; // 30 minutes is the default value
            
            string result = System.Configuration.ConfigurationManager.AppSettings["TokenValidDuration"];
            int.TryParse(result, out tokenValidDuration);
           
            return tokenValidDuration;
        }

        public static string GetSecurityKey()
        {
            string result = System.Configuration.ConfigurationManager.AppSettings["SigningSecurityKey"];
            return result;
        }

        public static byte[] GetSymmetricSecurityKeyAsBytes()
        {
            var issuerSigningKey = GetSecurityKey();
            byte[] data = Encoding.UTF8.GetBytes(issuerSigningKey);
            return data;
        }

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            byte[] data = GetSymmetricSecurityKeyAsBytes();
            var result = new SymmetricSecurityKey(data);
            return result;
        }

        public static string GetCorsOrigins()
        {
            string result = System.Configuration.ConfigurationManager.AppSettings["CorsOrigins"];
            return result;
        }
    }
}