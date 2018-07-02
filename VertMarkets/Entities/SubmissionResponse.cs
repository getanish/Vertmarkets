namespace VertMarkets.Entities
{
    /// <summary>
    /// SubmissionResponse
    /// </summary>
    /// <seealso cref="VertMarkets.Entities.ApiResponse" />
    public class SubmissionResponse:ApiResponse
    {
        /// <summary>
        /// Gets or sets the submission data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Submission Data { get; set; }
    }
}
