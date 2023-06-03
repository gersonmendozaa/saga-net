using MongoDB.Driver;
using TripPlanner.Hostel.Data.Interfaces;
using TripPlanner.Hostel.Entities;

namespace TripPlanner.Hostel.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration){
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            Hostel = database.GetCollection<HostelEntity>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Hostel);
        }
        public IMongoCollection<HostelEntity> Hostel {get;}
    }
}