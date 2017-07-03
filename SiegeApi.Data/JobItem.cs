using System;
using System.Collections.Generic;
using System.Text;

namespace SiegeApi.Data
{
    /// <summary>
    /// Represents a Job Item
    /// </summary>
    public class JobItem
    {
        public long Id { get; set; }

        public JobStatus JobStatus { get; set; }
    }
}
