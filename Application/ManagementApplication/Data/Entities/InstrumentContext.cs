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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
