using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Statistics;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class StatisticsRepository : DapperRepository, IStatisticsRepository
    {
        public StatisticsRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<StatisticsEM> GetByFirstDigit(DateRangeDTO rangeDTO)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_FirstDigit", rangeDTO);
        }

        public IEnumerable<StatisticsEM> GetBySerial(DateRangeDTO rangeDTO)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_Series", rangeDTO);
        }

        public IEnumerable<StatisticsEM> GetHappyByFirstDigit(DateRangeDTO rangeDTO)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_HappyByFirstDigit", rangeDTO);
        }

        public IEnumerable<StatisticsEM> GetHappyBySerial(DateRangeDTO rangeDTO)
        {
            return _GetStatistics<StatisticsEM>("USP_Statistics_HappyBySerial", rangeDTO);
        }

        public IEnumerable<ColorStatisticsEM> GetByColor(DateRangeDTO rangeDTO)
        {
            return _GetStatistics<ColorStatisticsEM>("USP_Statistics_Colors", rangeDTO);
        }

        private IEnumerable<TStatistics> _GetStatistics<TStatistics>(string spName, DateRangeDTO rangeDTO) where TStatistics : class
        {
            return ExecuteSP<TStatistics>(spName, ParametersHelper.CreateFromObject(rangeDTO));
        }
    }
}
