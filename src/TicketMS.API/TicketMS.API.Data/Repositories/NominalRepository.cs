using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class NominalRepository : DapperRepository, INominalRepository
    {
        public NominalRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<NominalEM> GetAllNominals()
        {
            return ExecuteQuery<NominalEM>("SELECT * FROM [v_Nominals]");
        }

        public IEnumerable<NominalEM> GetNominalsForSelectList()
        {
            return ExecuteQuery<NominalEM>("SELECT [Id], [Value], [IsDefault] FROM [Nominal] ORDER BY [Value]");
        }

        public NominalEM GetNominal(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteQuerySingle<NominalEM>("SELECT * FROM [v_Nominals] WHERE [Id] = @id", param);
        }

        public int CreateNominal(decimal value)
        {
            var param = ParametersHelper.CreateFromObject(new { value }).IncludeOutputId();
            ExecuteSP("USP_Nominal_Create", param);
            return param.GetOutputId();
        }

        public void EditNominal(int id, decimal value)
        {
            var param = ParametersHelper.CreateFromObject(new { value }).IncludeId(id);
            ExecuteSP("USP_Nominal_Update", param);
        }

        public void DeleteNominal(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Nominal_Delete", param);
        }

        public void SetAsDefault(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Nominal_SetDefault", param);
        }
    }
}
