using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using VertMarkets.Business;
using VertMarkets.Entities;
using VertMarkets.Interfaces;
using VertMarkets.ServiceAgents;

namespace VertMarkets
{
    class Program
    {
        static IReadOnlyDictionary<string, string> DefaultConfiguration { get; } =
            new Dictionary<string, string>()
            {
                ["MagezineStore:BaseUrl"] = "http://magazinestore.azurewebsites.net",
                ["MagezineStore:TimeOutInSeconds"] = "20"
            };

        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .AddInMemoryCollection(DefaultConfiguration)
                    .AddCommandLine(args);

                var configuration = builder.Build();
                var serviceProvider = new ServiceCollection()
                    .Configure<MagazineStoreConfiguration>(configuration.GetSection("MagezineStore"))
                    .AddTransient<IMagazineStoreSa, MagazineStoreSa>()
                    .AddTransient<IMagazineStore, MagazineStore>()
                    .BuildServiceProvider();


                var store = serviceProvider.GetService<IMagazineStore>();
                var result = await store.IdentifySubcribersToAllCategories();
                Console.WriteLine($"Result: {JsonConvert.SerializeObject(result)}");
            }
            catch (Exception)
            {
                Console.WriteLine("An eror as occurred.");
            }


        }
    }
}
