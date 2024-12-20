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
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddLoan(LoanDTO loanDto)
        {
            _service.AddLoan(loanDto);

            return Ok(loanDto);
        }
    }
}
