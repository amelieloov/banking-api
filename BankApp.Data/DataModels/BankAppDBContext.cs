using BankApp.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BankApp.Data.DataModels
{
    public class BankAppDBContext : IBankAppDBContext
    {
        private readonly string _connString;

        public BankAppDBContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("BankApp");
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connString);
        }
    }
}
