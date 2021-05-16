using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementApplication.Data
{
    public class InstrumentRepository : IInstrumentRepository
    {
        private readonly InstrumentContext _context = new InstrumentContext();

        public InstrumentRepository()
        {
            
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Instrument[]> GetAllInstrumentsAsync()
        {
            IQueryable<Instrument> query = _context.Instruments;
            // Order It
            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }

        public async Task<Instrument> GetInstrumentAsync(string code)
        {
            IQueryable<Instrument> query = _context.Instruments;

            // Query It
            query = query.Where(c => c.Code == code);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Instrument> UpdateInstrumentAsync(string code, Instrument instrument)
        {
            if (string.IsNullOrEmpty(code))
            {
                code = instrument.Code;
            }

            var toUpdate = await GetInstrumentAsync(code);

            if (toUpdate == null)
            {
                return null;
            }

            if (toUpdate.Code != instrument.Code)
            {
                if (await GetInstrumentAsync(instrument.Code) != null)
                {
                    return null;
                }
            }

            if (instrument.Name == "" || instrument.Code == "" || instrument.Price < 0 || instrument.Description == ""
                || instrument.Rating < 0 || instrument.Quantity < 0 || instrument.PictureName == "" || instrument.Type == "")
            {
                return null;
            }

            toUpdate.InstrumentId = instrument.InstrumentId;
            toUpdate.Code = instrument.Code;
            toUpdate.Price = instrument.Price;
            toUpdate.Description = instrument.Description;
            toUpdate.Rating = instrument.Rating;
            toUpdate.Quantity = instrument.Quantity;
            toUpdate.PictureName = instrument.PictureName;
            toUpdate.Type = instrument.Type;

            return toUpdate;
        }

        public async Task<Instrument[]> GetInstrumentsByTypeAsync(string type)
        {
            IQueryable<Instrument> query = _context.Instruments;

            // Query It
            query = query.Where(c => c.Type == type);
            // Order It
            query = query.OrderBy(c => c.Name);

            return await query.ToArrayAsync();
        }

        public async Task<UserData> GetRegisteredUserAsync(string email)
        {
            IQueryable<UserData> query = _context.Users;

            // Query It
            query = query.Where(c => c.Email == email);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Order[]> GetOrderByEmailAsync(string email)
        {
            IQueryable<Order> query = _context.Orders;

            // Query It
            query = query.Where(c => c.Email == email);

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Order> GetLastOrderAsync()
        {
            IQueryable<Order> query = _context.Orders;

            // Order It
            query = query.OrderByDescending(c => c.OrderNumber);

            return await query.FirstOrDefaultAsync();
        }
    }
}
