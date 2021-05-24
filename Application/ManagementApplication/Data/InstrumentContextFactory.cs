using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace ManagementApplication.Data
{
    public class InstrumentContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public InstrumentContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<InstrumentContext>();

            _configureDbContext(options);

            options.UseSqlServer("Data Source=tcp:nopsicwebshopdb.database.windows.net,1433;Initial Catalog=WebshopDB;User ID=nopsic;Password=H12d45h78d963;Connection Timeout=30;");

            return new InstrumentContext();
        }
    }
}
