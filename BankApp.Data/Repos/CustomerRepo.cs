using BankApp.Data.Interfaces;
using BankApp.Domain.Models;
using Dapper;
using System.Data;

namespace BankApp.Data.Repos
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly IBankAppDBContext _dbContext;

        public CustomerRepo(IBankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddCustomerAsync(Customer customer, User user)
        {
            var param = new DynamicParameters();
            param.Add("@GivenName", customer.GivenName);
            param.Add("@Surname", customer.Surname);
            param.Add("@Gender", customer.Gender);
            param.Add("@StreetAddress", customer.StreetAddress);
            param.Add("@City", customer.City);
            param.Add("@ZipCode", customer.ZipCode);
            param.Add("@Country", customer.Country);
            param.Add("@CountryCode", customer.CountryCode);
            param.Add("@Birthday", customer.Birthday);
            param.Add("@TelephoneCountryCode", customer.TelephoneCountryCode);
            param.Add("@TelephoneNumber", customer.TelephoneNumber);
            param.Add("@EmailAddress", customer.EmailAddress);

            param.Add("@Username", user.Username);
            param.Add("@PasswordHash", user.PasswordHash);

            param.Add("@CustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);
            param.Add("@AccountId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                await db.ExecuteAsync("CreateCustomerWithUserAndAccount", param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
