using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Interfaces
{
    public interface IBankAppDBContext
    {
        IDbConnection GetConnection();
    }
}
