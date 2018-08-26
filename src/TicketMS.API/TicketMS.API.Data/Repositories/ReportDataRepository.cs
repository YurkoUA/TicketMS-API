using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Report;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class ReportDataRepository : DapperRepository, IReportDataRepository
    {
        public ReportDataRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public TicketsTotalEM GetTicketsTotal(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSPSingle<TicketsTotalEM>("USP_Report_TicketsTotal", param);
        }

        public PackagesTotalEM GetPackagesTotal(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSPSingle<PackagesTotalEM>("USP_Report_PackagesTotal", param);
        }

        public TicketsFromDefaultPackagesAndUnallocatedEM GetTicketsFromDefaultPackagesAndUnallocated()
        {
            return ExecuteSPSingle<TicketsFromDefaultPackagesAndUnallocatedEM>("USP_Report_TicketsFromDefaultAndUnallocatedPackages");
        }

        public IEnumerable<PackageSummaryEM> GetDefaultPackages(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<PackageSummaryEM>("USP_Report_DefaultPackages", param);
        }

        public IEnumerable<PackageSummaryEM> GetSpecialPackages(IDateRange dateRange)
        {
            var param = ParametersHelper.CreateFromObject(dateRange);
            return ExecuteSP<PackageSummaryEM>("USP_Report_SpecialPackages", param);
        }
    }
}
