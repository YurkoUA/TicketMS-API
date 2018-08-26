using System.Collections.Generic;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Report;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class ReportDataRepository : DapperRepository, IReportDataRepository
    {
        public ReportDataRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public TicketsTotalDTO GetTicketsTotal(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSPSingle<TicketsTotalDTO>("USP_Report_TicketsTotal", param);
        }

        public PackagesTotalDTO GetPackagesTotal(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSPSingle<PackagesTotalDTO>("USP_Report_PackagesTotal", param);
        }

        public TicketsFromDefaultPackagesAndUnallocatedDTO GetTicketsFromDefaultPackagesAndUnallocated()
        {
            return ExecuteSPSingle<TicketsFromDefaultPackagesAndUnallocatedDTO>("USP_Report_TicketsFromDefaultAndUnallocatedPackages");
        }

        public IEnumerable<PackageSummaryDTO> GetDefaultPackages(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<PackageSummaryDTO>("USP_Report_DefaultPackages", param);
        }

        public IEnumerable<PackageSummaryDTO> GetSpecialPackages(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<PackageSummaryDTO>("USP_Report_SpecialPackages", param);
        }
    }
}
