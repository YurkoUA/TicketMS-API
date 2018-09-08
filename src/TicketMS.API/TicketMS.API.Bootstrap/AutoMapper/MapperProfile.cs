using AutoMapper;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.DTO.Color;
using TicketMS.API.Infrastructure.DTO.Serial;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Bootstrap.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ConfigureUserMapping();
            ConfigureColorMapping();
            ConfigureSerialMapping();
            ConfigureNominalMapping();
        }

        private void ConfigureUserMapping()
        {
            CreateMap<LoginEM, LoginVM>();
            CreateMap<LoginVM, LoginEM>();

            CreateMap<RoleEM, RoleVM>();

            CreateMap<UserEM, UserVM>();
        }

        private void ConfigureColorMapping()
        {
            CreateMap<ColorEM, ColorVM>();
            CreateMap<ColorVM, ColorEM>();
            CreateMap<ColorVM, ColorDTO>();
        }

        private void ConfigureSerialMapping()
        {
            CreateMap<SerialEM, SerialVM>();
            CreateMap<SerialVM, SerialEM>();
            CreateMap<SerialVM, SerialDTO>();
        }

        private void ConfigureNominalMapping()
        {
            CreateMap<NominalEM, NominalVM>();
            CreateMap<NominalVM, NominalEM>();
        }
    }
}
