using Microsoft.EntityFrameworkCore;

namespace ManagementApplication.Data
{
    public class InstrumentContext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<UserData> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public InstrumentContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:nopsicwebshopdb.database.windows.net,1433;Initial Catalog=WebshopDB;User ID=nopsic;Password=H12d45h78d963;Connection Timeout=30;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
