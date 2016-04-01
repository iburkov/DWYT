using System.Web.Http;
using Owin;
using Tms.RestApi.AppStart;

namespace Tms.RestApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();

            RouteConfig.Register(httpConfiguration);

            ModuleConfig.Register(httpConfiguration);

            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}