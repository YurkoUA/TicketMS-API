using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Color;
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

        public ColorEM GetColor(int id)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id });
            return ExecuteQuerySingle<ColorEM>("SELECT * FROM [v_Color] WHERE [Id] = @id", param);
        }

        public int CreateColor(ColorDTO colorDTO)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { name = colorDTO.Name, paletteName = colorDTO.PaletteName }, true);
            ExecuteSP("USP_Color_Create", param);
            return param.Get<int>(Constants.ID_PARAMETER_NAME);
        }

        public void EditColor(int id, ColorDTO colorDTO)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id, colorDTO.Name, colorDTO.PaletteName });
            ExecuteSP("USP_Color_Update", param);
        }

        public void DeleteColor(int id)
        {
            var param = ParametersHelper.CreateFromAnonymousObject(new { id });
            ExecuteSP("USP_Color_Delete", param);
        }
    }
}
