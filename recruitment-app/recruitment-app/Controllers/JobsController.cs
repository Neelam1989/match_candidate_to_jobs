using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace recruitment_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobsController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await GetJobsFromAPI();
            //return new List<Job>() {
            //    new Job()
            //    {
            //        JobId = 1,
            //        Name = "test",
            //        Company = "TCS",
            //        Skills = "C#, angular"
            //    }
            //};
        }

        public async Task<List<Job>> GetJobsFromAPI()
        {
            //Define your base url
            string baseURL = $"http://private-76432-jobadder1.apiary-mock.com/jobs";
            //Have your api call in try/catch block.
            try
            {
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();
                            
                            if (data != null)
                            {
                                
                                var response = await res.Content.ReadAsStringAsync();
                                var jobs = JsonConvert.DeserializeObject<List<Job>>(response);
                               
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
