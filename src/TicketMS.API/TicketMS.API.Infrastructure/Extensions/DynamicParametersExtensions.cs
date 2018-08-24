using System.Data;
using Dapper;

namespace TicketMS.API.Infrastructure.Extensions
{
    public static class DynamicParametersExtensions
    {
        public static DynamicParameters IncludeId(this DynamicParameters parameters, int id)
        {
            parameters.Add(Constants.ID_PARAMETER_NAME, id);
            return parameters;
        }

        public static DynamicParameters IncludeReturnedId(this DynamicParameters parameters)
        {
            parameters.Add(Constants.ID_PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            return parameters;
        }

        public static int GetReturnedId(this DynamicParameters parameters)
        {
            return parameters.Get<int>(Constants.ID_PARAMETER_NAME);
        }
    }
}
