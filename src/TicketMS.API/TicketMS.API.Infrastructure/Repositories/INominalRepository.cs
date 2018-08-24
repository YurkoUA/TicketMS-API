using System.Collections.Generic;
using TicketMS.API.Data.Entity;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface INominalRepository : IRepository
    {
        IEnumerable<NominalEM> GetAllNominals();
        NominalEM GetNominal(int id);

        int CreateNominal(double value);
        void EditNominal(int id, double value);
        void DeleteNominal(int id);

        void SetAsDefault(int id);
    }
}
