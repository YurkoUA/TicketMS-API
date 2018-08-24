using System.Collections.Generic;
using System.Data;
using Dapper;
using TicketMS.API.Infrastructure.Extensions;

namespace TicketMS.API.Infrastructure.Helpers
{
    public class ParametersHelper
    {
        public static DynamicParameters CreateFromAnonymousObject(object parameters, bool includeReturnedId = false)
        {
            var dynamicParameters = new DynamicParameters();
            var type = parameters.GetType();

            foreach (var prop in type.GetProperties())
            {
                dynamic value = prop.GetValue(parameters);

                if (prop.GetType() == typeof(IEnumerable<int>))
                {
                    value = (value as IEnumerable<int>).AsDataTableParam().AsTableValuedParameter(Constants.IntArrayType);
                }

                dynamicParameters.Add($"@{prop.Name}", value);
            }

            dynamicParameters.Add(Constants.ID_PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return dynamicParameters;
        }
    }
}
