using AutoMapper;
using DasherApp.Business.Repository.Interface;
using DasherApp.Business.Repository;
using DasherApp.Data;
using DasherApp.DataLoader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using ILoggerFactory factory = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Debug));
ILogger<LocationRepository> logger = factory.CreateLogger<LocationRepository>();

var options = new DbContextOptionsBuilder<AppDbContext>()
                   .UseSqlServer(Config.ConnectionString)
                   .Options;

var config = new MapperConfiguration(cfg =>
{
    //Configuring Employee and EmployeeDTO
    cfg.CreateMap<IDailyDashRepository, DailyDashRepository>();
    cfg.CreateMap<ILocationRepository, LocationRepository>();
    cfg.CreateMap<ITotalEarnedRepository, TotalEarnedRepository>();
    //Any Other Mapping Configuration ....

});
//Create an Instance of Mapper and return that Instance
var mapper = new Mapper(config);

var context = new AppDbContext(options);
var loader = new DataLoader(context, mapper, logger);
//await loader.LoadDash();
await loader.LoadRestaurants();

Console.WriteLine("Data loaded successfully.");
