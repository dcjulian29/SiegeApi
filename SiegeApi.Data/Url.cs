using System;
using System.Collections.Generic;
using System.Text;

namespace SiegeApi.Data
{
    /// <summary>
    /// A class for EF Core that will end up being a list of URLs.
    /// </summary>
    public class Url
    {
        /// <summary>
        /// Gets or sets the ID of this URL
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the location of the URL.
        /// </summary>
        public string Location { get; set; }
    }
}
