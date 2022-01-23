using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace recruitment_app.Clients
{
    public class ApiClient
    {
        private const string JobsUrl = "http://private-76432-jobadder1.apiary-mock.com/jobs";

        private const string CabdidatessUrl = "http://private-76432-jobadder1.apiary-mock.com/candidates";

        public async Task<List<Job>> GetJobs()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(JobsUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
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
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
            return null;
        }

        public async Task<List<Candidate>> GetCandidates()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(CabdidatessUrl))
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
