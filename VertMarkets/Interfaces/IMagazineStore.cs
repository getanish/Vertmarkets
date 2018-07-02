using System.Threading.Tasks;
using VertMarkets.Entities;

namespace VertMarkets.Interfaces
{
    /// <summary>
    /// Interface for MagazineStore
    /// </summary>
    public interface IMagazineStore
    {
        /// <summary>
        /// Identifies the subcribers that are subscribed to at least
        /// one magazine from each category
        /// </summary>
        /// <returns></returns>
        Task<SubmissionResponse> IdentifySubcribersToAllCategories();
    }
}
