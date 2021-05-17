using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task<Instrument> UpdateInstrumentAsync(string code, Instrument instrument);

        // Order
        Task<Order[]> GetOrdersAsync();
        Task<Order[]> GetOrdersByOrderNumberToSetStatusAsync(int orderNumber, string status);
        Task<Order[]> GetOrdersByOrderNumberAsync(int orderNumber);
    }
}
