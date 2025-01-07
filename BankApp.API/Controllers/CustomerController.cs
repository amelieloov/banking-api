using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerAndUserDTO customerAndUserDto)
        {
            var result = await _service.AddCustomerAsync(customerAndUserDto.Customer, customerAndUserDto.User);

            return Ok(result);
        }
    }
}
