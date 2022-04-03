using Microsoft.EntityFrameworkCore;

namespace Passenger.API.Model
{
    public class PassengerContext : DbContext
    {
        public DbSet<API.Model.Passenger> Passengers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }
        public PassengerContext(DbContextOptions<PassengerContext> options)
   : base(options)
        { }
    }
}