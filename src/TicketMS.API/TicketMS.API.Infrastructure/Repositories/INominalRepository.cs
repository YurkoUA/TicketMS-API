using System.Collections.Generic;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface INominalRepository : IRepository
    {
        IEnumerable<NominalEM> GetAllNominals();
        IEnumerable<NominalEM> GetNominalsForSelectList();
        NominalEM GetNominal(int id);

        int CreateNominal(decimal value);
        void EditNominal(int id, decimal value);
        void DeleteNominal(int id);

        void SetAsDefault(int id);
    }
}
