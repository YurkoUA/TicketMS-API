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

        public static DynamicParameters IncludeOutputId(this DynamicParameters parameters)
        {
            parameters.Add(Constants.ID_PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.Output);
            return parameters;
        }

        public static DynamicParameters IncludeOutputTotal(this DynamicParameters parameters)
        {
            parameters.Add(Constants.TOTAL_PARAMETER_NAME, dbType: DbType.Int32, direction: ParameterDirection.Output);
            return parameters;
        }

        public static int GetOutputId(this DynamicParameters parameters)
        {
            return parameters.Get<int>(Constants.ID_PARAMETER_NAME);
        }

        public static int GetOutputTotal(this DynamicParameters parameters)
        {
            return parameters.Get<int>(Constants.TOTAL_PARAMETER_NAME);
        }
    }
}
