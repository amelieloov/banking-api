using BankApp.Data.Interfaces;
using BankApp.Domain.Models;
using Dapper;
using System.Data;

namespace BankApp.Data.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly IBankAppDBContext _dbContext;

        public UserRepo(IBankAppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetLoginCredsAsync(string username)
        {
            var param = new DynamicParameters();
            param.Add("Username", username);

            using (IDbConnection db = _dbContext.GetConnection())
            {
                var user = await db.QueryAsync<User, Role, User>("GetLoginCreds", (u, r) =>
                {
                    u.Role = r;
                    return u;

                }, param, splitOn: "RoleId", commandType: CommandType.StoredProcedure);

                return user.SingleOrDefault();
            }
        }
    }
}
