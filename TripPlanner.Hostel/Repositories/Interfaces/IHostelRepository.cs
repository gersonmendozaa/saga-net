using TripPlanner.Hostel.Entities;

namespace TripPlanner.Hostel.Repositories.Interfaces
{
    public interface IHostelRepository
    {
         Task<IEnumerable<HostelEntity>> GetHostel();
        Task<HostelEntity> GetHostel(string id);
        Task<IEnumerable<HostelEntity>> GetHostelByName(string name);

        Task CreateHostel(HostelEntity hostelEntity);
        Task<bool> UpdateHostel(HostelEntity hostelEntity);
        Task<bool> DeleteHostel(string id);
    }
}