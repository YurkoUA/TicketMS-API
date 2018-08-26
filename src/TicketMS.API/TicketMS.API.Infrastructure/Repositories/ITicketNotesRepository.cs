using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ITicketNotesRepository
    {
        IEnumerable<TicketNoteDTO> GetAllNotes();
        IEnumerable<string> FindNotes(string text);
    }
}
