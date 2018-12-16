using System.Collections.Generic;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Color;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IColorService
    {
        IEnumerable<ColorVM> GetAllColors();
        IEnumerable<NameValueVM<int>> GetColorsNameValues();
        ColorVM GetColor(int id);

        int CreateColor(ColorVM color);
        void EditColor(ColorVM color);
        void DeleteColor(int id);
    }
}
