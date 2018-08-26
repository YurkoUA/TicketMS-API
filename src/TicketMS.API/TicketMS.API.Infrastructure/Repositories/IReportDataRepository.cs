using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Report;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IReportDataRepository
    {
        TicketsTotalDTO GetTicketsTotal(IDateRange dateRange);
        PackagesTotalDTO GetPackagesTotal(IDateRange dateRange);

        TicketsFromDefaultPackagesAndUnallocatedDTO GetTicketsFromDefaultPackagesAndUnallocated();

        IEnumerable<PackageSummaryDTO> GetDefaultPackages(IDateRange dateRange);
        IEnumerable<PackageSummaryDTO> GetSpecialPackages(IDateRange dateRange);
    }
}
