using DasherApp.Business.Repository.Interface;
using DasherApp.Data;
using DasherApp.Data.Entity;
using System.Data.Entity;

namespace DasherApp.Business.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly AppDbContext _context;
        public RestaurantRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task Save(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
        }
    }
}
