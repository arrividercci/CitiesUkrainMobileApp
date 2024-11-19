using CitiesUkrainMobileApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitiesUkrainMobileApp
{
    public class CitiesDbContext : DbContext
    {
        public CitiesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<City> Cities {get; set;}
    }
}
