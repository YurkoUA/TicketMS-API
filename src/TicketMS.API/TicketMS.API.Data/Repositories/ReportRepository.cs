using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Report;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class ReportRepository : DapperRepository, IReportRepository
    {
        const string SPLIT_ON = "DocumentId,TypeId";

        public ReportRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ReportEM> GetReports()
        {
            var sql = "SELECT * FROM [v_Reports]";
            return _Get(sql);
        }

        public ReportEM GetLastReport()
        {
            var sql = "SELECT TOP 1 * FROM [v_Reports] ORDER BY [Id] DESC";
            return _Get(sql).FirstOrDefault();
        }

        public int CreateReport(DateTime date, bool isAutomatic, IEnumerable<ReportDocumentDTO> documents)
        {
            var param = ParametersHelper.CreateFromObject(new { date, isAutomatic, documents }).IncludeReturnedId();
            ExecuteSP("USP_Report_Create", param);
            return param.GetReturnedId();
        }

        public DateTime GetLastReportDate()
        {
            var sql = "SELECT [dbo].[fn_Report_GetLastDate]()";
            return ExecuteAggregateQuery<DateTime>(sql);
        }

        #region Private methods.

        private IEnumerable<ReportEM> _Get(string sql)
        {
            var reportDictionary = new Dictionary<int, ReportEM>();

            return ExecuteQuery<ReportEM, ReportDocumentEM, ReportTypeEM, ReportEM>(sql, (report, document, type) =>
            {
                if (!reportDictionary.TryGetValue(report.Id, out ReportEM reportEntry))
                {
                    reportEntry = report;
                    reportEntry.Documents = new List<ReportDocumentEM>();
                    reportDictionary.Add(report.Id, reportEntry);
                }

                document.Type = type;
                reportEntry.Documents.AsList().Add(document);
                return reportEntry;
            }, SPLIT_ON).Distinct();
        }

        #endregion
    }
}
