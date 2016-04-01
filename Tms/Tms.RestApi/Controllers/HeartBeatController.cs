using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tms.Configuration;

namespace Tms.RestApi.Controllers
{
    public class HeartBeatController : ApiController
    {
        private readonly IConfigProvider config;

        public HeartBeatController(IConfigProvider config)
        {
            this.config = config;
        }

        [HttpGet]
        [Route("API/HeartBeat")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok(new
            {
                IsAlive = true,
                Date = DateTime.Now,
                UtcDate = DateTime.UtcNow,
                Environment = await config.GetSettingAsync<string>("Environment")
            });
        }
    }
}
