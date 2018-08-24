using System.Collections.Generic;
using Dapper;
using TicketMS.API.Infrastructure.Extensions;

namespace TicketMS.API.Infrastructure.Helpers
{
    public class ParametersHelper
    {
        public static DynamicParameters GetFromAnonymousObject(object parameters)
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

            return dynamicParameters;
        }
    }
}
