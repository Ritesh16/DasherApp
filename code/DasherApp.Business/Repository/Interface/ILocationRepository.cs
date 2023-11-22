using DasherApp.Data.Entity;

namespace DasherApp.Business.Repository.Interface
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        Task<bool> LocationExists(string name);
        Task Save(string location);
    }
}
