using System.Collections.Generic;
using TicketMS.API.ViewModels;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IColorService
    {
        IEnumerable<ColorVM> GetAllColors();
        ColorVM GetColor(int id);

        int CreateColor(ColorVM color);
        void EditColor(int id, ColorVM color);
        void DeleteColor(int id);
    }
}
