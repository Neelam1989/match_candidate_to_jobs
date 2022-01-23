using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using recruitment_app.Clients;

namespace recruitment_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesSearchController : ControllerBase
    {
        private ApiClient client = new ApiClient();

        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetCandidates(int jobId)
        {
            var jobs = await client.GetJobs();
            var requiredSkills = jobs.Where(j => j.JobId == jobId).Select(j => j.Skills).First();

            var candidates = await client.GetCandidates();

            var requiredSkillsList = requiredSkills.Split(',').Select(c => c.Trim());

            return candidates.OrderByDescending(candidate =>
            {
                var candidateSkills = candidate.SkillTags.Split(',').Select(skillTag => skillTag.Trim());
                return requiredSkillsList.Intersect(candidateSkills).Count();
            })
            .ThenByDescending(candidate => candidate.SkillTags.Split(',').Count())
            .Take(5);
        }
    }
}
