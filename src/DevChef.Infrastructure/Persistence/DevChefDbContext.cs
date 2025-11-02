using DevChef.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevChef.Infrastructure.Persistence;

public class DevChefDbContext : DbContext
{
    public DevChefDbContext(DbContextOptions<DevChefDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Cuisine> Cuisines => Set<Cuisine>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Favorite> Favorites => Set<Favorite>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevChefDbContext).Assembly);
    }
}