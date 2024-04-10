using Microsoft.AspNetCore.Mvc;
using OsDsII.api.Controllers;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface ICustomerRepository
    {
        public Task<IActionResult> GetAllAsync();

        public Task<IActionResult> GetByIdAsync(int id);

        public Task<IActionResult> CreateCustomerAsync(Customer customer);

        public Task<IActionResult> DeleteCustomerAsync(int id);

        public Task<IActionResult> UpdateCustomerAsync(Customer customer);
       
    }
}
