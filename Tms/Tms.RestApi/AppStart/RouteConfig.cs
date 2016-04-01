using System.Web.Http;

namespace Tms.RestApi.AppStart
{
    public class RouteConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}