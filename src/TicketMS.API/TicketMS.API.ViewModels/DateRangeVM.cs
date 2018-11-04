using System;
using TicketMS.API.Infrastructure.Common.Interfaces;

namespace TicketMS.API.ViewModels
{
    public class DateRangeVM : IDateRange
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
