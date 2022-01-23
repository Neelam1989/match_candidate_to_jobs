using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using recruitment_app.Clients;

namespace recruitment_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        private ApiClient client = new ApiClient();

        [HttpGet]
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await client.GetJobs();
        }
    }
}
