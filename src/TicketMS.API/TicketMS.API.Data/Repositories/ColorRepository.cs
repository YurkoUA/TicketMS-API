using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Color;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class ColorRepository : DapperRepository, IColorRepository
    {
        public ColorRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<ColorEM> GetAllColors()
        {
            return ExecuteQuery<ColorEM>("SELECT * FROM [v_Colors]");
        }

        public IEnumerable<ColorEM> GetColorsForSelectList()
        {
            return ExecuteQuery<ColorEM>("SELECT [Id], [Name] FROM [Color] ORDER BY [Name]");
        }

        public ColorEM GetColor(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteQuerySingle<ColorEM>("SELECT * FROM [v_Colors] WHERE [Id] = @id", param);
        }

        public int CreateColor(ColorDTO colorDTO)
        {
            var param = ParametersHelper.CreateFromObject(colorDTO).IncludeOutputId();
            ExecuteSP("USP_Color_Create", param);
            return param.GetOutputId();
        }

        public void EditColor(int id, ColorDTO colorDTO)
        {
            var param = ParametersHelper.CreateFromObject(colorDTO).IncludeId(id);
            ExecuteSP("USP_Color_Update", param);
        }

        public void DeleteColor(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Color_Delete", param);
        }
    }
}
