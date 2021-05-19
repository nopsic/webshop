using System.Threading.Tasks;

namespace ManagementApplication.Data
{
    public interface IInstrumentRepository
    {
        // General
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        // Instrument
        Task<Instrument[]> GetAllInstrumentsAsync();
        Task<Instrument> GetInstrumentAsync(string code);
        Task<Instrument> UpdateInstrumentAsync(int id, Instrument instrument);
        Task<Instrument> GetInstrumenByIdtAsync(int id);

        // Order
        Task<Order[]> GetOrdersAsync();
        Task<Order[]> GetOrdersByOrderNumberToSetStatusAsync(int orderNumber, string status);
        Task<Order[]> GetOrdersByOrderNumberAsync(int orderNumber);
    }
}
