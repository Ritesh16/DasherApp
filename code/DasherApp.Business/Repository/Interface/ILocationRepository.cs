using DasherApp.Model;
using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface ILocationRepository
    {
        Task<PagedList<LocationModel>> Get();
        Task<bool> LocationExists(string name);
        Task Save(string location);
    }
}
