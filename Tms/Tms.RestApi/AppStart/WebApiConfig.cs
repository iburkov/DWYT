using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace Tms.RestApi.AppStart
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }
    }
}