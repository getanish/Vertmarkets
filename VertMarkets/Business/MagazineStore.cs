using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using VertMarkets.Entities;
using VertMarkets.Interfaces;

namespace VertMarkets.Business
{
    /// <summary>
    /// MagazineStore
    /// </summary>
    /// <seealso cref="VertMarkets.Interfaces.IMagazineStore" />
    public class MagazineStore: IMagazineStore
    {
        /// <summary>
        /// The magazine store sa
        /// </summary>
        private readonly IMagazineStoreSa _magazineStoreSa;
        /// <summary>
        /// Initializes a new instance of the <see cref="MagazineStore"/> class.
        /// </summary>
        /// <param name="magazineStoreStoreSa">The magazine store store sa.</param>
        public MagazineStore(IMagazineStoreSa magazineStoreStoreSa)
        {
            _magazineStoreSa = magazineStoreStoreSa;
        }
        /// <summary>
        /// Identifies the subcribers that are subscribed to at least
        /// one magazine from each category
        /// </summary>
        /// <returns></returns>
        public async Task<SubmissionResponse> IdentifySubcribersToAllCategories()
        {
            var categories = await _magazineStoreSa.GetCategories();
            var subscribers = await _magazineStoreSa.GetSubscribers();
            var magazineTasks = new List<Task<List<Magazine>>>();
            foreach (var category in categories)
            {
                magazineTasks.Add(_magazineStoreSa.GetMagazines(category));
            }

            Task.WaitAll(magazineTasks.ToArray());
            var subcribersToAllCategories = from subscriber in subscribers.SelectMany(s => s.MagazineIds,
                    (subscriber, magazineId) => new {SubscriberId = subscriber.Id, MagazineId = magazineId})
                join magazine in magazineTasks.SelectMany(x => x.Result)
                    on subscriber.MagazineId equals magazine.Id
                select new
                {
                    subscriber.SubscriberId,
                    magazine.Category
                }
                into subscriberCategory
                group subscriberCategory by subscriberCategory.SubscriberId
                into subscriberGrouping
                select new
                {
                    SubcriberId = subscriberGrouping.Key,
                    CategoryCount = subscriberGrouping.Distinct().Count()
                }
                into subscriberCategoryCount
                where subscriberCategoryCount.CategoryCount == categories.Count
                select subscriberCategoryCount.SubcriberId;

           return await _magazineStoreSa.SubmitAnswer(subcribersToAllCategories);
        }
    }
}
