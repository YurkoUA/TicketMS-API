using System;

namespace TicketMS.API.Infrastructure.Common.Interfaces
{
    public interface IDateRange
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
