using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;
using OsDsII.api.Repository;

namespace OsDsII.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceOrdersController : ControllerBase
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        public ServiceOrdersController(IServiceOrderRepository serviceOrderRepository)
        {
            _serviceOrderRepository = serviceOrderRepository;
        }
 


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetAllServiceOrderAsync()
        {
            try
            {
                List<ServiceOrder> serviceOrders = await _serviceOrderRepository.GetAllAsync();
                return Ok(serviceOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetServiceOrderById(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.ServiceOrders.FirstOrDefaultAsync(s => s.Id == id);
                if (serviceOrder is null)
                {
                   return NotFound("Service order not found");
                }
                return Ok(serviceOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> CreateServiceOrderAsync(ServiceOrder serviceOrder)
        {
            try
            {
                if (serviceOrder is null)
                {
                    return BadRequest("Service order cannot be null");
                }

                Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(c => serviceOrder.Customer.Id == c.Id);

                if (customer is null)
                {
                    return NotFound("Customer not found");
                }

                await _serviceOrderRepository.AddAsync(serviceOrder);
                return Created("CreateServiceOrderAsync", serviceOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}/status/finish")]
        public async Task<IActionResult> FinishServiceOrderAsync(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.GetByIdAsync(id);
                if (serviceOrder is null)
                {
                    return BadRequest("Service order cannot be null");
                }

                serviceOrder.FinishOS();
                _dataContext.ServiceOrders.Update(serviceOrder);
                await _dataContext.SaveChangesAsync();
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}/status/cancel")]
        public async Task<IActionResult> CancelServiceOrder(int id)
        {
            try
            {
                ServiceOrder serviceOrder = await _serviceOrderRepository.GetByIdAsync(id);
                if (serviceOrder is null)
                {
                    return BadRequest("Service order cannot be null");
                }

                serviceOrder.Cancel();
               _serviceOrderRepository.CancelAsync(serviceOrder);


                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}