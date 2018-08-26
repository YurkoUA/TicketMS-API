using System.Collections.Generic;
using System.Data;
using Dapper;
using TicketMS.API.Infrastructure.DTO.Report;
using TicketMS.API.Infrastructure.Extensions;

namespace TicketMS.API.Infrastructure.Helpers
{
    public class ParametersHelper
    {
        public static DynamicParameters CreateIdParameter(int id)
        {
            var param = new DynamicParameters();
            param.Add(Constants.ID_PARAMETER_NAME, id);
            return param;
        }

        public static DynamicParameters CreateFromObject(params object[] parameters)
        {
            var dynamicParameters = new DynamicParameters();

            foreach (var par in parameters)
            {
                var type = par.GetType();

                foreach (var prop in type.GetProperties())
                {
                    dynamic value = prop.GetValue(par);

                    if (prop.GetType() == typeof(IEnumerable<int>))
                    {
                        value = (value as IEnumerable<int>).AsDataTableParam().AsTableValuedParameter(Constants.IntArrayType);
                    }
                    else if (prop.GetType() == typeof(IEnumerable<ReportDocumentDTO>))
                    {
                        value = (value as IEnumerable<ReportDocumentDTO>).AsDataTableParam().AsTableValuedParameter(Constants.UDT_ReportDocument);
                    }
                    else if (prop.GetType() == typeof(byte[]))
                    {
                        dynamicParameters.Add($"@{prop.Name.FirstCharToLower()}", value, dbType: DbType.Binary);
                        continue;
                    }

                    dynamicParameters.Add($"@{prop.Name.FirstCharToLower()}", value);
                }
            }

            return dynamicParameters;
        }
    }
}
