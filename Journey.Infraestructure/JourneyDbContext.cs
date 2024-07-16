using Journey.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infraestructure
{
    public class JourneyDbContext : DbContext
    {
        public DbSet<Trip> Trips { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=directory");
        }
    }
}
