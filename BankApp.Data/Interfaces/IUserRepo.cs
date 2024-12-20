using BankApp.Domain.Models;

namespace BankApp.Data.Interfaces
{
    public interface IUserRepo
    {
        public User GetLoginCreds(string username);
    }
}
