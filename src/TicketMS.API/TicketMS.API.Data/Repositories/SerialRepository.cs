using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Serial;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class SerialRepository : DapperRepository, ISerialRepository
    {
        public SerialRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<SerialEM> GetAllSeries()
        {
            return ExecuteQuery<SerialEM>("SELECT * FROM [v_Series]");
        }

        public IEnumerable<SerialEM> GetSeriesForSelectList()
        {
            return ExecuteQuery<SerialEM>("SELECT [Id], [Name], [IsDefault] FROM [Serial] ORDER BY [Name]");
        }

        public SerialEM GetSerial(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteQuerySingle<SerialEM>("SELECT * FROM [v_Series] WHERE [Id] = @id", param);
        }

        public int CreateSerial(SerialDTO serialDTO)
        {
            var param = ParametersHelper.CreateFromObject(serialDTO).IncludeOutputId();
            ExecuteSP("USP_Serial_Create", param);
            return param.GetOutputId();
        }

        public void EditSerial(int id, SerialDTO serialDTO)
        {
            var param = ParametersHelper.CreateFromObject(serialDTO).IncludeId(id);
            ExecuteSP("USP_Serial_Update", param);
        }

        public void DeleteSerial(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Serial_Delete", param);
        }

        public void SetAsDefault(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Serial_SetDefault", param);
        }
    }
}
