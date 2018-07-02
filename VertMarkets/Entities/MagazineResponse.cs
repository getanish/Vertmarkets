using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// MagazineResponse
    /// </summary>
    /// <seealso cref="VertMarkets.Entities.ApiResponse" />
    public class MagazineResponse:ApiResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Magazine> Data { get; set; }
    }
}
