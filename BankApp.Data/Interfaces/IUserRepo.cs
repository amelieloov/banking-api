﻿using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface IUserRepo
    {
        public Task<User> GetUserInfoAsync(string username);
    }
}
