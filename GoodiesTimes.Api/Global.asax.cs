using GoodiesTimes.Api.Mappers;
using System.Web.Routing;
using System.Web.Http;


namespace GoodiesTimes.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Code that runs on application startup
            //AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.RegisterMappings();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Application_Error()
        {

        }
    }
}
