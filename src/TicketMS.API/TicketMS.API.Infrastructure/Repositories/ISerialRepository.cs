using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure.DTO.Serial;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ISerialRepository : IRepository
    {
        IEnumerable<SerialEM> GetAllSeries();
        IEnumerable<SerialEM> GetSeriesForSelectList();
        SerialEM GetSerial(int id);

        int CreateSerial(SerialDTO serialDTO);
        void EditSerial(int id, SerialDTO serialDTO);
        void DeleteSerial(int id);
    }
}
