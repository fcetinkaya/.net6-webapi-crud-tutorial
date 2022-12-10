using CustomersAPI.Data;
using CustomersAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomersAPIDbContext dbContext;

        public CustomersController(CustomersAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            var customer = new Customers()
            {
                Id = Guid.NewGuid(),
                FirstName = addCustomerRequest.FirstName,
                LastName = addCustomerRequest.LastName,
                Email = addCustomerRequest.Email,
                Phone = addCustomerRequest.Phone,
                City = addCustomerRequest.City,
                Address = addCustomerRequest.Address
            };
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequest updateCustomer)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                customer.FirstName = updateCustomer.FirstName;
                customer.LastName = updateCustomer.LastName;
                customer.Email = updateCustomer.Email;
                customer.Phone = updateCustomer.Phone;
                customer.City = updateCustomer.City;
                customer.Address = updateCustomer.Address;

                await dbContext.SaveChangesAsync();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();
        }
    }
}
