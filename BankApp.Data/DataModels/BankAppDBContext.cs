using BankApp.Data.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace BankApp.Data.DataModels
{
    public class BankAppDBContext : IBankAppDBContext
    {
        private readonly string _connString;

        public BankAppDBContext(IConfiguration config)
        {
            _connString = config.GetConnectionString("BankApp");
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connString);
        }
    }
}
