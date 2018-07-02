﻿namespace VertMarkets.Entities
{
    /// <summary>
    /// ApiResponse
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string token { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ApiResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
    }
}
