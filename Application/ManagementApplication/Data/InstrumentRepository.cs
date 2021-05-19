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

        public async Task<Instrument> GetInstrumenByIdtAsync(int id)
        {

            IQueryable<Instrument> query = _context.Instruments;

            // Query It
            query = query.Where(c => c.InstrumentId == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Instrument> UpdateInstrumentAsync(int id, Instrument instrument)
        {
            if (id == 0)
            {
                id = instrument.InstrumentId;
            }

            var toUpdate = await GetInstrumenByIdtAsync(id);

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
                || instrument.Rating < 0 || instrument.Quantity < 0 || instrument.Type == "" || instrument.Image == null)
            {
                return null;
            }

            toUpdate.InstrumentId = instrument.InstrumentId;
            toUpdate.Name = instrument.Name;
            toUpdate.Code = instrument.Code;
            toUpdate.Price = instrument.Price;
            toUpdate.Description = instrument.Description;
            toUpdate.Rating = instrument.Rating;
            toUpdate.Quantity = instrument.Quantity;
            toUpdate.Image = instrument.Image;
            toUpdate.Type = instrument.Type;

            return toUpdate;
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            IQueryable<Order> query = _context.Orders;

            // Order It
            query = query.OrderBy(c => c.OrderNumber);

            return await query.ToArrayAsync();
        }

        public async Task<Order[]> GetOrdersByOrderNumberToSetStatusAsync(int orderNumber, string status)
        {
            IQueryable<Order> query = _context.Orders;

            // Query It
            query = query.Where(c => c.OrderNumber == orderNumber);

            var updateOrder = await query.ToArrayAsync();

            if (updateOrder == null)
            {
                return null;
            }

            foreach (var item in updateOrder)
            {
                item.Status = status;
            }

            return updateOrder;
        }

        public async Task<Order[]> GetOrdersByOrderNumberAsync(int orderNumber)
        {
            IQueryable<Order> query = _context.Orders;

            // Query It
            query = query.Where(c => c.OrderNumber == orderNumber);

            var orders = await query.ToArrayAsync();

            if (orders == null)
            {
                return null;
            }

            return orders;
        }
    }
}
