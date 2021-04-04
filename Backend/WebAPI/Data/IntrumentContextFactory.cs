using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WebAPI.Data
{
    public class IntrumentContextFactory : IDesignTimeDbContextFactory<InstrumentContext>
    {
        public InstrumentContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return new InstrumentContext(new DbContextOptionsBuilder<InstrumentContext>().Options, config);
        }
    }
}
