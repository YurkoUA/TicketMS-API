using System;

namespace TicketMS.API.Infrastructure
{
    public interface IDateRange
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
    }
}
