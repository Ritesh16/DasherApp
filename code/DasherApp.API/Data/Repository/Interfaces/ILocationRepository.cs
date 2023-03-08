namespace DasherApp.API.Data.Repository.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<string> GetLocations();
    }
}
