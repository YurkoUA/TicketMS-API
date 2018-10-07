using System.Collections.Generic;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Statistics;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class StatisticsRepository : DapperRepository, IStatisticsRepository
    {
        public StatisticsRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<StatisticsDTO> GetByFirstDigit(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsDTO>("USP_Statistics_FirstDigit", dateRange);
        }

        public IEnumerable<StatisticsDTO> GetBySerial(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsDTO>("USP_Statistics_Series", dateRange);
        }

        public IEnumerable<StatisticsDTO> GetHappyByFirstDigit(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsDTO>("USP_Statistics_HappyByFirstDigit", dateRange);
        }

        public IEnumerable<StatisticsDTO> GetHappyBySerial(IDateRange dateRange)
        {
            return _GetStatistics<StatisticsDTO>("USP_Statistics_HappyBySerial", dateRange);
        }

        public IEnumerable<ColorStatisticsDTO> GetByColor(IDateRange dateRange)
        {
            return _GetStatistics<ColorStatisticsDTO>("USP_Statistics_Colors", dateRange);
        }

        private IEnumerable<TStatistics> _GetStatistics<TStatistics>(string spName, IDateRange dateRange) where TStatistics : class
        {
            return ExecuteSP<TStatistics>(spName, ParametersHelper.CreateFromObject(dateRange));
        }
    }
}
