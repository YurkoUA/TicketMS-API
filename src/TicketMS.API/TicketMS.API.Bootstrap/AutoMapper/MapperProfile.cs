using AutoMapper;
using TicketMS.API.Data.Entity;
using TicketMS.API.ViewModels.User;

namespace TicketMS.API.Bootstrap.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            ConfigureUserMapping();
        }

        private void ConfigureUserMapping()
        {
            CreateMap<LoginEM, LoginVM>();
            CreateMap<LoginVM, LoginEM>();

            CreateMap<RoleEM, RoleVM>();

            CreateMap<UserEM, UserVM>();
        }
    }
}
