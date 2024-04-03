using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface IServiceOrderRepository
    {
        public Task<List<ServiceOrder>> GetAllAsync();

        public Task<ServiceOrder> GetByIdAsync(int id);

        public Task AddAsync(ServiceOrder serviceOrder);

        public Task FinishAsync(ServiceOrder serviceOrder);

        public Task CancelAsync(ServiceOrder serviceOrder);

    }
}
