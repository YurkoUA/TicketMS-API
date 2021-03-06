﻿using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Serial;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Serial;

namespace TicketMS.API.Business.Services
{
    public class SerialService : Service, ISerialService
    {
        private readonly ISerialRepository serialRepository;

        public SerialService(IMappingService mapper, ISerialRepository serialRepository) : base(mapper)
        {
            this.serialRepository = serialRepository;
        }

        public IEnumerable<NameValueVM<int>> GetSeriesNameValues()
        {
            var series = serialRepository.GetSeriesForSelectList();
            return mapper.ConvertCollectionTo<NameValueVM<int>>(series);
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

        public void EditSerial(SerialVM serial)
        {
            var serialDTO = mapper.ConvertTo<SerialDTO>(serial);
            serialRepository.EditSerial(serial.Id, serialDTO);
        }

        public void DeleteSerial(int id)
        {
            serialRepository.DeleteSerial(id);
        }
    }
}
