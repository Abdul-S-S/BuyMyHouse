using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BuyMyHouse.Interfaces;
using Datastore.Operators;
using Datastore.Operators.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BuyMyHouse;
using Datastore.Context;
using BuyMyHouse.Services;

[assembly: WebJobsStartup(typeof(Startup))]
namespace BuyMyHouse
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {

            builder.Services.AddDbContext<CosmosDbContext>();
            builder.Services.TryAddScoped(typeof(IReader), typeof(Reader));
            builder.Services.TryAddScoped(typeof(IWriter), typeof(Writer));
            builder.Services.TryAddScoped(typeof(IDBUnitOfWork), typeof(DBUnitOfWork));
            builder.Services.TryAddScoped(typeof(IHouseService), typeof(HouseService));
            builder.Services.TryAddScoped(typeof(IUserService), typeof(UserService));
            builder.Services.TryAddScoped(typeof(IMortgageOfferService), typeof(MortgageOfferService));
            builder.Services.AddLogging();

        }
    }
}