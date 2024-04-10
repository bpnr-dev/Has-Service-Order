using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public class CustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _dataContext.Customers.AddAsync(customer); 
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id, Customer customer)
        {
            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();
        }
    }
}
