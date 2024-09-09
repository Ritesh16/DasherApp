using DasherApp.Model;
using DasherApp.Model.Helper;

namespace DasherApp.Business.Repository.Interface
{
    public interface ILocationRepository
    {
        public Task<PagedList<LocationModel>> Get();
        public Task<bool> LocationExists(string name);
        public Task Save(string location);
    }
}
