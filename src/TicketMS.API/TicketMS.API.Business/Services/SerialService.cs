using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Serial;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;

namespace TicketMS.API.Business.Services
{
    public class SerialService : Service, ISerialService
    {
        private readonly ISerialRepository serialRepository;

        public SerialService(IMappingService mapper, ISerialRepository serialRepository) : base(mapper)
        {
            this.serialRepository = serialRepository;
        }

        public IEnumerable<SerialVM> GetAllSeries()
        {
            var series = serialRepository.GetAllSeries();
            return mapper.ConvertCollectionTo<SerialVM>(series);
        }

        public SerialVM GetSerial(int id)
        {
            var serial = serialRepository.GetSerial(id);
            return mapper.ConvertTo<SerialVM>(serial);
        }

        public int CreateSerial(SerialVM serial)
        {
            var serialDTO = mapper.ConvertTo<SerialDTO>(serial);
            return serialRepository.CreateSerial(serialDTO);
        }

        public void EditSerial(int id, SerialVM serial)
        {
            var serialDTO = mapper.ConvertTo<SerialDTO>(serial);
            serialRepository.EditSerial(id, serialDTO);
        }

        public void DeleteSerial(int id)
        {
            serialRepository.DeleteSerial(id);
        }

        public void SetAsDefault(int id)
        {
            serialRepository.SetAsDefault(id);
        }
    }
}
