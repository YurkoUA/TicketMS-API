using System;
using System.Data;

namespace TicketMS.API.Infrastructure.Database
{
    public interface IDbContext
    {
        string ConnectionString { get; }

        void PerformDbRequest(Action<IDbConnection> action);
        TResult PerformDbRequest<TResult>(Func<IDbConnection, TResult> func);
    }
}
