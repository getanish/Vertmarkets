using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// Subscriber
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets the magazine ids.
        /// </summary>
        /// <value>
        /// The magazine ids.
        /// </value>
        public List<int> MagazineIds { get; set; } = new List<int>();
    }
}
