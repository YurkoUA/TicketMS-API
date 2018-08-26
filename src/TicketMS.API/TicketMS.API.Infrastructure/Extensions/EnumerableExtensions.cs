using System.Collections.Generic;
using System.Data;
using TicketMS.API.Infrastructure.DTO.Report;

namespace TicketMS.API.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static DataTable AsDataTableParam<T>(this IEnumerable<T> data)
        {
            var tableAsParam = new DataTable();
            tableAsParam.Columns.Add("Item");

            if (data != null)
            {
                foreach (var item in data)
                {
                    tableAsParam.Rows.Add(item);
                }
            }

            return tableAsParam;
        }

        public static DataTable AsDataTableParam(this IEnumerable<ReportDocumentDTO> documents)
        {
            var table = new DataTable();
            table.Columns.Add(nameof(ReportDocumentDTO.TypeId));
            table.Columns.Add(nameof(ReportDocumentDTO.FileUrl));


            if (documents != null)
            {
                foreach (var item in documents)
                {
                    table.Rows.Add(item.TypeId, item.FileUrl);
                }
            }

            return table;
        }
    }
}
