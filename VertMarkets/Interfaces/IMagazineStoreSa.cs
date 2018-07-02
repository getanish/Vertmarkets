using System.Collections.Generic;
using System.Threading.Tasks;
using VertMarkets.Entities;

namespace VertMarkets.Interfaces
{
    /// <summary>
    /// Interface for MagezineStore Service Agent
    /// </summary>
    public interface IMagazineStoreSa
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        Task<List<string>> GetCategories();
        /// <summary>
        /// Gets the subscribers.
        /// </summary>
        /// <returns></returns>
        Task<List<Subscriber>> GetSubscribers();
        /// <summary>
        /// Gets the magazines.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        Task<List<Magazine>> GetMagazines(string category);
        /// <summary>
        /// Submits the answer.
        /// </summary>
        /// <param name="subcribers">The subcribers.</param>
        /// <returns></returns>
        Task<SubmissionResponse> SubmitAnswer(IEnumerable<string> subcribers);
    }
}
