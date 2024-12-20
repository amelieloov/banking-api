using BankApp.Core.Interfaces;
using BankApp.Domain.DTOs;
using BankApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BankApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetAccountsForCustomer()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            List<AccountReadDTO> accounts = _service.GetAccountsForCustomer(userId);

            return Ok(accounts);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddAccount(AccountCreateDTO accountDto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            _service.AddAccount(userId, accountDto);

            return Ok();
        }
    }
}
