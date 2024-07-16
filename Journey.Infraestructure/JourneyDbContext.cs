using Journey.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infraestructure
{
    public class JourneyDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pathDatabase = Environment.GetEnvironmentVariable("PATH_DATABASE");
            optionsBuilder.UseSqlite($"Data Source={pathDatabase}");
        }
    }
}
