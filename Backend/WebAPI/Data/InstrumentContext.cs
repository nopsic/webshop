using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class InstrumentContext : DbContext
    {
        private readonly IConfiguration _config;

        public InstrumentContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Instrument> Instruments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Webshop"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 1,
                  Name = "French horn",
                  Code = "FH0049",
                  Price = 150000,
                  Description = "One of the best musical instruments ever",
                  Rating = 5.0,
                  Quantity = 3
              });

        }
    }
}
