using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiegeApi.Data;

namespace SiegeApi.Controllers
{
    [Route("[controller]")]
    public class JobController : Controller
    {
        private readonly JobContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobController"/> class.
        /// </summary>
        public JobController(JobContext context)
        {
            _context = context;
        }

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
        public async Task<IEnumerable<Job>> Get()
        {
            return await _context.Jobs.ToListAsync();
        }

        /// <summary>
        /// Return Job Results.
        /// </summary>
        /// <param name="id">The Id of job to return results.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Job> Get(int id)
        {
            return await _context.FindAsync<Job>(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<int> Post([FromBody]Job job)
        {
            _context.Add(job);

            await _context.SaveChangesAsync();

            return job.Id;
        }
    }
}
