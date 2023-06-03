using MongoDB.Driver;
using TripPlanner.Hostel.Entities;

namespace TripPlanner.Hostel.Data.Interfaces
{
    public interface ICatalogContext
    {
         IMongoCollection<HostelEntity> Hostel { get; }
    }
}