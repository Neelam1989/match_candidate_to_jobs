using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; 

namespace recruitment_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesSearchController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Candidate>> GetCandidates(string requiredSkills)
        {
            var candidates = await GetCandidateFromAPI();
            var requiredSkillsList= requiredSkills.Split(',').Select(c => c.Trim());
            return candidates.Select(c => c).OrderByDescending(c => {

                var skillTags =  c.SkillTags.Split(',').Select(c => c.Trim());
                return skillTags.Intersect(requiredSkillsList).Count();

            }).Take(5);
           
        }

        public async Task<List<Candidate>> GetCandidateFromAPI()
        {
            //Define your base url
            string baseURL = $"http://private-76432-jobadder1.apiary-mock.com/candidates";
            try
            {         
                using (HttpClient client = new HttpClient())
                {    
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {     
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();

                            if (data != null)
                            {

                                var response = await res.Content.ReadAsStringAsync();
                                var jobs = JsonConvert.DeserializeObject<List<Candidate>>(response);

                                return jobs;

                            }

                        }
                    }
                }
                //Catch any exceptions and log it into the console.
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
            return null;
        }
    }
}
