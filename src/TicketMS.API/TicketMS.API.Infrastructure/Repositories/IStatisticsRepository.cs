using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Statistics;
using TicketMS.API.Infrastructure.DTO;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IStatisticsRepository
    {
        IEnumerable<StatisticsEM> GetByFirstDigit(DateRangeDTO rangeDTO);
        IEnumerable<StatisticsEM> GetBySerial(DateRangeDTO rangeDTO);

        IEnumerable<StatisticsEM> GetHappyByFirstDigit(DateRangeDTO rangeDTO);
        IEnumerable<StatisticsEM> GetHappyBySerial(DateRangeDTO rangeDTO);

        IEnumerable<ColorStatisticsEM> GetByColor(DateRangeDTO rangeDTO);
    }
}
