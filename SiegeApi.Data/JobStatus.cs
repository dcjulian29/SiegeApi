using System;
using System.Collections.Generic;
using System.Text;

namespace SiegeApi.Data
{
    /// <summary>
    /// The status of a job.
    /// </summary>
    public enum JobStatus
    {
        /// <summary>
        /// The job is currently queued.
        /// </summary>
        Queued,

        /// <summary>
        /// The job is currently running.
        /// </summary>
        Running,

        /// <summary>
        /// The job is currently finished.
        /// </summary>
        Finished
    }
}
