using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// ApiAnswer
    /// </summary>
    public class ApiAnswer
    {
        /// <summary>
        /// Gets or sets the subscribers.
        /// </summary>
        /// <value>
        /// The subscribers.
        /// </value>
        public IEnumerable<string> Subscribers { get; set; }
    }
}
