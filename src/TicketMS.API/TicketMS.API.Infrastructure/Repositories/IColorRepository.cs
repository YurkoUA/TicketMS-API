using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.DTO.Color;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IColorRepository : IRepository
    {
        IEnumerable<ColorEM> GetAllColors();
        IEnumerable<ColorEM> GetColorsForSelectList();
        ColorEM GetColor(int id);

        int CreateColor(ColorDTO colorDTO);
        void EditColor(int id, ColorDTO colorDTO);
        void DeleteColor(int id);
    }
}
