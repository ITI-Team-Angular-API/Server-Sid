using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Helpers;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
    
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
            new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = ConfigHelper.GetAudience(),
                    ValidIssuer = ConfigHelper.GetIssuer(),
                    IssuerSigningKey = ConfigHelper.GetSymmetricSecurityKey(),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                }
            });

            HttpConfiguration config = new HttpConfiguration();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //ConfigureOAuth(app);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);// config.MapHttpAttributeRoutes();
            
            SwaggerConfig.Register(config);


            app.UseWebApi(config);
        }
    }
}
