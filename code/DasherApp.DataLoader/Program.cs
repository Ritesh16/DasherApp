using DasherApp.Data;
using DasherApp.DataLoader;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<AppDbContext>()
                   .UseSqlServer(Config.ConnectionString);
                   .Options;

var context = new AppDbContext(options);
var loader = new DataLoader(context);
await loader.LoadDash();

Console.WriteLine("Data loaded successfully.");
