﻿using BankApp.Domain.DTOs;
using BankApp.Domain.Models;

namespace BankApp.Core.Interfaces
{
    public interface IUserService
    {
        public Task<string> VerifyLoginAsync(UserDTO userDto);
        public string GenerateJwtToken(User user);
    }
}
