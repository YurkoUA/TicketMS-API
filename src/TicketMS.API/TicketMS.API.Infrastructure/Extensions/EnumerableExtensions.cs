using System.Collections.Generic;
using System.Data;

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
    }
}
