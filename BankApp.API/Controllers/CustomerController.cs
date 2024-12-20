using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddCustomer(CustomerAndUserDTO customerAndUserDto)
        {
            _service.AddCustomer(customerAndUserDto.Customer, customerAndUserDto.User);

            return Ok("Customer created with a new user and account.");
        }
    }
}
