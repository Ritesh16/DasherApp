namespace DasherApp.Services.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<string>> GetLocations();
    }
}
