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
                  Description = "One of the best musical instruments ever.",
                  Rating = 5.0,
                  Quantity = 3,
                  PictureName = "assets/images/french_horn.png",
                  Type = "brass"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 2,
                  Name = "Trumpet",
                  Code = "TR0050",
                  Price = 120000,
                  Description = "Everybody knows what trumpet looks like.",
                  Rating = 4.2,
                  Quantity = 6,
                  PictureName = "assets/images/trumpet.jpg",
                  Type = "brass"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 3,
                  Name = "Tuba",
                  Code = "TU0051",
                  Price = 200000,
                  Description = "Tuba is Tuba.",
                  Rating = 4.1,
                  Quantity = 2,
                  PictureName = "assets/images/tuba.jpg",
                  Type = "brass"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 4,
                  Name = "Trombone",
                  Code = "TB0052",
                  Price = 170000,
                  Description = "When mom isn't home meme.",
                  Rating = 4.6,
                  Quantity = 5,
                  PictureName = "assets/images/trombone.jpg",
                  Type = "brass"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 5,
                  Name = "Flugelhorn",
                  Code = "FH0053",
                  Price = 134000,
                  Description = "A valved brass musical instrument like a cornet but with a mellower tone.",
                  Rating = 3.7,
                  Quantity = 5,
                  PictureName = "assets/images/flugelhorn.jpg",
                  Type = "brass"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 6,
                  Name = "Flute",
                  Code = "FL0054",
                  Price = 80000,
                  Description = "Every girl want to play this instrument.",
                  Rating = 3.9,
                  Quantity = 12,
                  PictureName = "assets/images/flute.jpg",
                  Type = "woodwind"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 7,
                  Name = "Alto saxophone",
                  Code = "AS0055",
                  Price = 125000,
                  Description = "Epic sax guy.",
                  Rating = 4.4,
                  Quantity = 9,
                  PictureName = "assets/images/alto_saxophone.jpg",
                  Type = "woodwind"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 8,
                  Name = "Clarinet",
                  Code = "CL0056",
                  Price = 93590,
                  Description = "Squid had this instrument in SpongeBob.",
                  Rating = 4.3,
                  Quantity = 17,
                  PictureName = "assets/images/clarinet.png",
                  Type = "woodwind"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 9,
                  Name = "Bassoon",
                  Code = "FA0056",
                  Price = 134790,
                  Description = "A big windwood musical instrument.",
                  Rating = 2.5,
                  Quantity = 1,
                  PictureName = "assets/images/bassoon.jpg",
                  Type = "woodwind"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 10,
                  Name = "Snare drum",
                  Code = "SD0057",
                  Price = 42370,
                  Description = "Side drum.",
                  Rating = 4.0,
                  Quantity = 4,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "percussion"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 11,
                  Name = "Bass drum",
                  Code = "BD0058",
                  Price = 78640,
                  Description = "Bass drum.",
                  Rating = 3.7,
                  Quantity = 2,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "percussion"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 12,
                  Name = "Piano",
                  Code = "PI0059",
                  Price = 540990,
                  Description = "Classical piano.",
                  Rating = 4.6,
                  Quantity = 1,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "percussion"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 13,
                  Name = "Xylophone",
                  Code = "XY0060",
                  Price = 99990,
                  Description = "Xylophone.",
                  Rating = 3.3,
                  Quantity = 1,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "percussion"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 14,
                  Name = "Violin",
                  Code = "VI0061",
                  Price = 135760,
                  Description = "Violin.",
                  Rating = 4.3,
                  Quantity = 11,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "string"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 15,
                  Name = "Classical guitar",
                  Code = "CG0062",
                  Price = 49990,
                  Description = "Classical guitar, ideal for learning how to play the guitar.",
                  Rating = 4.6,
                  Quantity = 4,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "string"
              });
            bldr.Entity<Instrument>()
              .HasData(new
              {
                  InstrumentId = 16,
                  Name = "Electric guitar",
                  Code = "EG0063",
                  Price = 156490,
                  Description = "Electric guitar is a best choice to play hard rock.",
                  Rating = 4.7,
                  Quantity = 3,
                  PictureName = "assets/images/leaf_rake.png",
                  Type = "string"
              });
        }
    }
}
