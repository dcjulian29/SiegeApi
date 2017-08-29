using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiegeApi.Data;

namespace SiegeApi.Controllers
{
    [Route("[controller]")]
    public class JobController : Controller
    {
        /// <summary>
        /// Deletes a Job.
        /// </summary>
        /// <param name="id">The job Id to delete.</param>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
        }

        /// <summary>
        /// Return a list of Jobs.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<JobItem> Get()
        {
            var jobList = new List<JobItem>();

            jobList.Add(new JobItem
            {
                Id = 1,
                JobStatus = JobStatus.Finished
            });

            return jobList;
        }

        /// <summary>
        /// Return Job Results.
        /// </summary>
        /// <param name="id">The Id of job to return results.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JobResult Get(int id)
        {
            var jobResult = new JobResult();

            return jobResult;
        }

        // POST api/values
        [HttpPost]
        public int Post([FromBody]Job job)
        {
            return 0;
        }
    }
}
