using System.Web.Http;
using Tms.Common.IoC;

namespace Tms.RestApi.AppStart
{
    public class ModuleConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.DependencyResolver = ModuleLoader.LoadResolver();
        }
    }
}