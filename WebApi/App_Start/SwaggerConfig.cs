using System.Web.Http;
using WebActivatorEx;
using WebApi;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApi
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c=> {
                    c.SingleApiVersion("v1", "WebApi");
                    c.IncludeXmlComments(string.Format(@"{0}\bin\WebApi.xml",
                          System.AppDomain.CurrentDomain.BaseDirectory));
                    c.DescribeAllEnumsAsStrings();
                })
                .EnableSwaggerUi(c=> { });
        }
    }
}
