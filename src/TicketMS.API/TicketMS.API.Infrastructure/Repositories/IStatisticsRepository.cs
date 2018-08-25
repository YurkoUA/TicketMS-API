using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Statistics;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IStatisticsRepository
    {
        IEnumerable<StatisticsEM> GetByFirstDigit(IDateRange dateRange);
        IEnumerable<StatisticsEM> GetBySerial(IDateRange dateRange);

        IEnumerable<StatisticsEM> GetHappyByFirstDigit(IDateRange dateRange);
        IEnumerable<StatisticsEM> GetHappyBySerial(IDateRange dateRange);

        IEnumerable<ColorStatisticsEM> GetByColor(IDateRange dateRange);
    }
}
