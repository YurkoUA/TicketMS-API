using System.Collections.Generic;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.Nominal;

namespace TicketMS.API.Business.Services
{
    public class NominalService : Service, INominalService
    {
        private readonly INominalRepository nominalRepository;

        public NominalService(IMappingService mapper, INominalRepository nominalRepository) : base(mapper)
        {
            this.nominalRepository = nominalRepository;
        }

        public IEnumerable<NominalVM> GetAllNominals()
        {
            var nominals = nominalRepository.GetAllNominals();
            return mapper.ConvertCollectionTo<NominalVM>(nominals);
        }

        public NominalVM GetNominal(int id)
        {
            var nominal = nominalRepository.GetNominal(id);
            return mapper.ConvertTo<NominalVM>(nominal);
        }

        public int CreateNominal(decimal value)
        {
            return nominalRepository.CreateNominal(value);
        }

        public void EditNominal(int id, decimal value)
        {
            nominalRepository.EditNominal(id, value);
        }

        public void DeleteNominal(int id)
        {
            nominalRepository.DeleteNominal(id);
        }

        public void SetAsDefault(int id)
        {
            nominalRepository.SetAsDefault(id);
        }
    }
}
