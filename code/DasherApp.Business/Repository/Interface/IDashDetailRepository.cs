using DasherApp.Data.Entity;

namespace DasherApp.Business.Repository.Interface
{
    public interface IDashDetailRepository
    {
        Task Save(DashDetail dashDetail);
    }
}
