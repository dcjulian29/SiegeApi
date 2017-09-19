using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiegeApi.Data
{
    public class JobResult
    {
        /// <summary>
        /// Gets or sets the average number of simultaneous connections, a number which rises as
        /// server performance decreases.
        /// </summary>
        public float Concurrency { get; set; }

        /// <summary>
        /// Gets or sets the sum of data transferred to every siege simulated user.
        /// </summary>
        public float DataTransferred { get; set; }

        /// <summary>
        /// Gets or sets the duration of the entire siege test in seconds.
        /// </summary>
        public float ElapsedTime { get; set; }

        /// <summary>
        /// Gets or sets the number of times the server returned a code greater than 400.
        /// </summary>
        public int FailedTransactions { get; set; }

        /// <summary>
        /// Gets or sets the ID of this job result.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the duration of the longest transaction in seconds.
        /// </summary>
        public float LongestTransaction { get; set; }

        /// <summary>
        /// Gets or sets the average time it took to respond to each simulated user's requests.
        /// </summary>
        public float ResponseTime { get; set; }

        /// <summary>
        /// Gets or sets the duration of the shortest transaction in seconds.
        /// </summary>
        public float ShortestTransaction { get; set; }

        /// <summary>
        /// Gets or sets the number of times the server returned a code less than 400.
        /// </summary>
        public int SuccessfulTransactions { get; set; }

        /// <summary>
        /// Gets or sets the average number of bytes transferred every second from the server to all
        /// the simulated users.
        /// </summary>
        public float Throughput { get; set; }

        /// <summary>
        /// Gets or sets the average number of transactions the server was able to handle per second.
        /// </summary>
        public float TransactionRate { get; set; }

        /// <summary>
        /// Gets or sets the number of server hits.
        /// </summary>
        public int Transactions { get; set; }
    }
}
