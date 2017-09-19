﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SiegeApi.Data
{
    /// <summary>
    /// Represents a submitted Siege job request.
    /// </summary>
    public class Job
    {
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Job()
        {
            Users = 25;
            Delay = 1;
            Time = 60;
            IsSitemap = false;
            Urls = new List<Url>();
            Result = new JobResult();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        /// <param name="users">The number of simulated users.</param>
        /// <param name="delay">
        /// The random interval between 0 and number that each simulated user will sleep between request.
        /// </param>
        /// <param name="seconds">The number of seconds to run.</param>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Job(int users, int delay, int seconds)
        {
            Users = 25;
            Delay = delay;
            Time = seconds;
            IsSitemap = false;
            Urls = new List<Url>();
            Result = new JobResult();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Job"/> class.
        /// </summary>
        /// <param name="users">The number of simulated users.</param>
        /// <param name="delay">
        /// The random interval between 0 and number that each simulated user will sleep between request.
        /// </param>
        /// <param name="span">The time span that defines the time to run.</param>
        // ReSharper disable DoNotCallOverridableMethodsInConstructor
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors",
            Justification = "Entities Always Have Virtual Members")]
        public Job(int users, int delay, TimeSpan span)
        {
            Users = 25;
            Delay = delay;
            Time = Convert.ToInt32(span.TotalSeconds);
            IsSitemap = false;
            Urls = new List<Url>();
            Result = new JobResult();
        }

        /// <summary>
        /// Gets or sets the random interval between 0 and number that each simulated user will sleep
        /// between request.
        /// </summary>
        public virtual int Delay { get; protected set; }

        /// <summary>
        /// Gets or sets the ID of this job.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a indicate that the provided URLs are site maps that need to be parsed to
        /// get final list of URLs.
        /// </summary>
        public bool IsSitemap { get; protected set; }

        /// <summary>
        /// Gets or sets the status of the job.
        /// </summary>
        public JobStatus JobStatus { get; set; }

        /// <summary>
        /// Gets the result of the Siege job.
        /// </summary>
        public JobResult Result { get; private set; }

        /// <summary>
        /// Gets or sets the number of seconds to run.
        /// </summary>
        public virtual int Time { get; protected set; }

        /// <summary>
        /// Gets or sets the list of URLs to use.
        /// </summary>
        public IList<Url> Urls { get; protected set; }

        /// <summary>
        /// Gets or sets the number of simulated users.
        /// </summary>
        public virtual int Users { get; protected set; }

        /// <summary>
        /// Adds a of URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public virtual void AddUrl(string url)
        {
            var item = new Url()
            {
                Location = url
            };

            Urls.Add(item);
        }

        /// <summary>
        /// Adds a set of URLs.
        /// </summary>
        /// <param name="urls">The URL list.</param>
        public virtual void AddUrls(IEnumerable<string> urls)
        {
            ((List<string>)Urls).AddRange(urls);
        }

        public virtual void SetIsSitemap(bool sitemap)
        {
            IsSitemap = sitemap;
        }
    }
}
