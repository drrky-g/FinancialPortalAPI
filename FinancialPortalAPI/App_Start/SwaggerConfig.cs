using System.Web.Http;
using WebActivatorEx;
using FinancialPortalAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace FinancialPortalAPI
{

    /// <summary>
    /// Configuration for Swagger
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// Register Swagger Config
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "Finance Portal API");
                    c.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}/bin/FinancialPortalAPI.xml");
                }).EnableSwaggerUi();


        }
    }
}
