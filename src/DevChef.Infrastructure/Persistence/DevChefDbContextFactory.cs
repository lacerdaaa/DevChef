using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DevChef.Infrastructure.Persistence;

public class DevChefDbContextFactory : IDesignTimeDbContextFactory<DevChefDbContext>
{
    public DevChefDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../DevChef.Api");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var connectionString = configuration.GetConnectionString("Pg");

        var optionsBuilder = new DbContextOptionsBuilder<DevChefDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new DevChefDbContext(optionsBuilder.Options);
    }
}