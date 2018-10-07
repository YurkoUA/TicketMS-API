using System.Collections.Generic;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.DTO.Statistics;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IStatisticsRepository
    {
        IEnumerable<StatisticsDTO> GetByFirstDigit(IDateRange dateRange);
        IEnumerable<StatisticsDTO> GetBySerial(IDateRange dateRange);

        IEnumerable<StatisticsDTO> GetHappyByFirstDigit(IDateRange dateRange);
        IEnumerable<StatisticsDTO> GetHappyBySerial(IDateRange dateRange);

        IEnumerable<ColorStatisticsDTO> GetByColor(IDateRange dateRange);
    }
}
