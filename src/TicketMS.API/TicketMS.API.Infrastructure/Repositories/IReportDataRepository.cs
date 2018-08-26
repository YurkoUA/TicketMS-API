using System.Collections.Generic;
using TicketMS.API.Data.Entity.Secondary.Report;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IReportDataRepository
    {
        TicketsTotalEM GetTicketsTotal(IDateRange dateRange);
        PackagesTotalEM GetPackagesTotal(IDateRange dateRange);

        TicketsFromDefaultPackagesAndUnallocatedEM GetTicketsFromDefaultPackagesAndUnallocated();

        IEnumerable<PackageSummaryEM> GetDefaultPackages(IDateRange dateRange);
        IEnumerable<PackageSummaryEM> GetSpecialPackages(IDateRange dateRange);
    }
}
