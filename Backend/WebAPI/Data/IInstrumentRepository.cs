using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public interface IInstrumentRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        Task<Instrument[]> GetAllInstrumentsAsync();
        Task<Instrument> GetInstrumentAsync(string code);
        Task<Instrument[]> GetInstrumentsByTypeAsync(string type);
    }
}
