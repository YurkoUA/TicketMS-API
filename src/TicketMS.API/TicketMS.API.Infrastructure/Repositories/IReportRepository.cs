using System;
using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.DTO.Report;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IReportRepository
    {
        IEnumerable<ReportEM> GetReports();
        ReportEM GetLastReport();
        int CreateReport(DateTime date, bool isAutomatic, IEnumerable<ReportDocumentDTO> documents);

        DateTime GetLastReportDate();
    }
}
