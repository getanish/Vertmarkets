using System.Collections.Generic;

namespace VertMarkets.Entities
{
    /// <summary>
    /// Submission
    /// </summary>
    public class Submission
    {
        /// <summary>
        /// Gets or sets the total time.
        /// </summary>
        /// <value>
        /// The total time.
        /// </value>
        public string TotalTime { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [answer correct].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [answer correct]; otherwise, <c>false</c>.
        /// </value>
        public bool AnswerCorrect { get; set; }
        /// <summary>
        /// Gets or sets the should be.
        /// </summary>
        /// <value>
        /// The should be.
        /// </value>
        public List<string> ShouldBe { get; set; }
    }
}
