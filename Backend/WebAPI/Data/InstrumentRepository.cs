using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly InstrumentContext _context;
        private readonly ILogger<InstrumentRepository> _logger;

        public InstrumentRepository(InstrumentContext context, ILogger<InstrumentRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<Instrument[]> GetAllInstrumentAsync()
        {
            _logger.LogInformation($"Getting all Instruments");

            IQueryable<Instrument> query = _context.Instruments;
            // Order It
            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Instrument> GetInstrumentAsync(string name)
        {
            _logger.LogInformation($"Getting an Instrument with name: {name}");

            IQueryable<Instrument> query = _context.Instruments;

            // Query It
            query = query.Where(c => c.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
