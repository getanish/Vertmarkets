using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// CategoriesResponse
    /// </summary>
    /// <seealso cref="VertMarkets.Entities.ApiResponse" />
    public class CategoriesResponse: ApiResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<string> Data { get; set; }
    }
}
