using System;
using System.Data;
using System.Data.SqlClient;
using TicketMS.API.Infrastructure.Database;

namespace TicketMS.API.Data
{
    public class DbContext : IDbContext
    {
        public DbContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }

        public void PerformDbRequest(Action<IDbConnection> action)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                action(db);
            }
        }

        public TResult PerformDbRequest<TResult>(Func<IDbConnection, TResult> func)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                return func(db);
            }
        }
    }
}
