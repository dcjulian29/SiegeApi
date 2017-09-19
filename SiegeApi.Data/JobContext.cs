using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SiegeApi.Data
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
