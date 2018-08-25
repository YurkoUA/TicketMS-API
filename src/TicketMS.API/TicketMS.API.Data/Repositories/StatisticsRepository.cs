using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Statistics;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class StatisticsRepository : DapperRepository, IStatisticsRepository
    {
        public StatisticsRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<StatisticsEM> GetByFirstDigit(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_FirstDigit", dateRange);
        }

        public IEnumerable<StatisticsEM> GetBySerial(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_Series", dateRange);
        }

        public IEnumerable<StatisticsEM> GetHappyByFirstDigit(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_HappyByFirstDigit", dateRange);
        }

        public IEnumerable<StatisticsEM> GetHappyBySerial(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_HappyBySerial", dateRange);
        }

        public IEnumerable<ColorStatisticsEM> GetByColor(IDateRange dateRange)
        {
            return _GetStatistics<ColorStatisticsEM>("USP_Statistics_Colors", dateRange);
        }

        private IEnumerable<TStatistics> _GetStatistics<TStatistics>(string spName, IDateRange dateRange) where TStatistics : class
        {
            return ExecuteSP<TStatistics>(spName, ParametersHelper.CreateFromObject(dateRange));
        }
    }
}
