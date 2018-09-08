using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Color;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;

namespace TicketMS.API.Business.Services
{
    public class ColorService : Service, IColorService
    {
        private readonly IColorRepository colorRepository;

        public ColorService(IMappingService mapper, IColorRepository colorRepository) : base(mapper)
        {
            this.colorRepository = colorRepository;
        }

        public IEnumerable<ColorVM> GetAllColors()
        {
            var colors = colorRepository.GetAllColors();
            return mapper.ConvertCollectionTo<ColorVM>(colors);
        }

        public ColorVM GetColor(int id)
        {
            var color = colorRepository.GetColor(id);
            return mapper.ConvertTo<ColorVM>(color);
        }

        public int CreateColor(ColorVM color)
        {
            var colorDTO = mapper.ConvertTo<ColorDTO>(color);
            return colorRepository.CreateColor(colorDTO);
        }

        public void EditColor(int id, ColorVM color)
        {
            var colorDTO = mapper.ConvertTo<ColorDTO>(color);
            colorRepository.EditColor(id, colorDTO);
        }

        public void DeleteColor(int id)
        {
            colorRepository.DeleteColor(id);
        }
    }
}
