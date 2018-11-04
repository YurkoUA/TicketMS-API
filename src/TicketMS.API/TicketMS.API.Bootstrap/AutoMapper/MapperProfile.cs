using AutoMapper;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.DTO.Color;
using TicketMS.API.Infrastructure.DTO.Package;
using TicketMS.API.Infrastructure.DTO.Serial;
using TicketMS.API.Infrastructure.DTO.Ticket;
using TicketMS.API.ViewModels.Color;
using TicketMS.API.ViewModels.Nominal;
using TicketMS.API.ViewModels.Package;
using TicketMS.API.ViewModels.Serial;
using TicketMS.API.ViewModels.Ticket;
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
            CreateMap<ColorEM, ColorSimpleVM>();
            CreateMap<ColorVM, ColorEM>();
            CreateMap<ColorVM, ColorDTO>();
        }

        private void ConfigureSerialMapping()
        {
            CreateMap<SerialEM, SerialVM>();
            CreateMap<SerialEM, SerialSimpleVM>();
            CreateMap<SerialVM, SerialEM>();
            CreateMap<SerialVM, SerialDTO>();
        }

        private void ConfigureNominalMapping()
        {
            CreateMap<NominalEM, NominalVM>();
            CreateMap<NominalEM, NominalSimpleVM>();
            CreateMap<NominalVM, NominalEM>();
        }

        private void ConfigurePackageMapping()
        {
            CreateMap<PackageEM, PackageVM>();
            CreateMap<PackageEM, PackageSimpleVM>();

            CreateMap<PackageCreateVM, PackageDefaultDTO>();
            CreateMap<PackageSpecialCreateVM, PackageSpecialDTO>();
            CreateMap<PackageMakeSpecialVM, PackageMakeSpecialDTO>();

            CreateMap<PackageFilterVM, PackageFilterDTO>();
        }

        private void ConfigureTicketMapping()
        {
            CreateMap<TicketEM, TicketVM>();

            CreateMap<TicketCreateVM, TicketCreateDTO>();
            CreateMap<TicketEditVM, TicketDTO>();
        }
    }
}
