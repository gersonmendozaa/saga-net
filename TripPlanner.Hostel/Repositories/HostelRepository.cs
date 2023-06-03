using MongoDB.Driver;
using TripPlanner.Hostel.Data.Interfaces;
using TripPlanner.Hostel.Entities;
using TripPlanner.Hostel.Repositories.Interfaces;

namespace TripPlanner.Hostel.Repositories
{
    public class HostelRepository : IHostelRepository
    {
        private readonly ICatalogContext _context;

        public HostelRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<HostelEntity>> GetHostel()
        {
            return await _context
                            .Hostel
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<HostelEntity> GetHostel(string id)
        {
            return await _context
                           .Hostel
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<HostelEntity>> GetHostelByName(string name)
        {
            return await _context
                            .Hostel
                            .Find(p => p.Name == name)
                            .ToListAsync();
        }


        public async Task CreateHostel(HostelEntity hostel)
        {
            await _context.Hostel.InsertOneAsync(hostel);
        }

        public async Task<bool> UpdateHostel(HostelEntity hostel)
        {
            var updateResult = await _context
                                        .Hostel
                                        .ReplaceOneAsync(filter: g => g.Id == hostel.Id, replacement: hostel);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteHostel(string id)
        {
            FilterDefinition<HostelEntity> filter = Builders<HostelEntity>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Hostel
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}