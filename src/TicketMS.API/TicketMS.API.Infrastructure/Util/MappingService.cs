using System.Collections.Generic;
using AutoMapper;
using TicketMS.API.Infrastructure.Interfaces;

namespace TicketMS.API.Infrastructure.Util
{
    public class MappingService : IMappingService
    {
        private readonly IMapper mapper;

        public MappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination ConvertTo<TDestination>(object source)
        {
            return mapper.Map<TDestination>(source);
        }

        public IEnumerable<TDestination> ConvertCollectionTo<TDestination>(object source)
        {
            return mapper.Map<IEnumerable<TDestination>>(source);
        }
    }
}
