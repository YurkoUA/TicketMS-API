using System.Collections.Generic;
using TicketMS.API.ViewModels;

namespace TicketMS.API.Infrastructure.Services
{
    public interface ISerialService
    {
        IEnumerable<SerialVM> GetAllSeries();
        SerialVM GetSerial(int id);

        int CreateSerial(SerialVM serial);
        void EditSerial(SerialVM serial);
        void DeleteSerial(int id);

        void SetAsDefault(int id);
    }
}
