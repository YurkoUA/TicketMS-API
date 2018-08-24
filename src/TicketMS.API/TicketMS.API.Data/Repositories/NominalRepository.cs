using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
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

        public NominalEM GetNominal(int id)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id });
            return ExecuteQuerySingle<NominalEM>("SELECT * FROM [v_Nominals] WHERE [Id] = @id", param);
        }

        public int CreateNominal(double value)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { value }, true);
            ExecuteSP("USP_Nominal_Create", param);
            return param.Get<int>(Constants.ID_PARAMETER_NAME);
        }

        public void EditNominal(int id, double value)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id, value });
            ExecuteSP("USP_Nominal_Update", param);
        }

        public void DeleteNominal(int id)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id });
            ExecuteSP("USP_Nominal_Delete", param);
        }

        public void SetAsDefault(int id)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id });
            ExecuteSP("USP_Nominal_SetDefault", param);
        }
    }
}
