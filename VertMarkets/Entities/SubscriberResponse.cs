using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// SubscriberResponse
    /// </summary>
    /// <seealso cref="VertMarkets.Entities.ApiResponse" />
    public class SubscriberResponse:ApiResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Subscriber> Data { get; set; }
    }
}
