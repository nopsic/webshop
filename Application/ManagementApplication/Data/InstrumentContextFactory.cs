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

            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True;Connect Timeout=30;");

            return new InstrumentContext();
        }
    }
}
