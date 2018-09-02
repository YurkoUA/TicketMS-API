using TicketMS.API.Infrastructure.Interfaces;

namespace TicketMS.API.Business
{
    public abstract class Service
    {
        protected readonly IMappingService mapper;

        public Service(IMappingService mapper)
        {
            this.mapper = mapper;
        }
    }
}
