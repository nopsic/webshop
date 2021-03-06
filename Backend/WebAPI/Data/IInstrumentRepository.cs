﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Entities;

namespace WebAPI.Data
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
        Task<Instrument[]> GetInstrumentsByTypeAsync(string type);

        // Register
        Task<UserData> GetRegisteredUserAsync(string email);

        // Order
        Task<Order[]> GetOrderByEmailAsync(string email);
        Task<Order> GetLastOrderAsync();
    }
}
