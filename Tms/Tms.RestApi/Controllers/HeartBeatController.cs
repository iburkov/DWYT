using System;
using System.Threading.Tasks;
using System.Web.Http;
using Tms.Common.Constants;
using Tms.Configuration;
using Tms.Contracts.Dal.Repositories;
using Tms.Domain.Models;

namespace Tms.RestApi.Controllers
{
    public class HeartBeatController : ApiController
    {
        private readonly IConfigProvider config;
        private readonly IUserRepository userRepository;

        public HeartBeatController(IConfigProvider config, IUserRepository userRepository)
        {
            this.config = config;
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("API/HeartBeat")]
        public async Task<IHttpActionResult> Get()
        {
            var user = userRepository.FindOne(x => x.FirstName == "Heart" && x.LastName == "Beat");

            if (user == null)
            {
                user = await userRepository.CreateAsync(new User
                {
                    FirstName = "Heart",
                    LastName = "Beat"
                });
            }
            else
            {
                user.ModifiedAt = DateTime.UtcNow;
                userRepository.Update(user);
            }

            return Ok(new
            {
                IsAlive = true,
                Date = DateTime.Now,
                UtcDate = DateTime.UtcNow,
                Environment = await config.GetSettingAsync<string>(ConfigKeys.Environment),
                HeartBeatUser = user
            });
        }
    }
}
