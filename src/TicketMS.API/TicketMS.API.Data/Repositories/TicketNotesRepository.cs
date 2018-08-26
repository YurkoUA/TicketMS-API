using System.Collections.Generic;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class TicketNotesRepository : DapperRepository, ITicketNotesRepository
    {
        public TicketNotesRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<TicketNoteDTO> GetAllNotes()
        {
            return ExecuteQuery<TicketNoteDTO>("SELECT * FROM [v_Notes]");
        }

        public IEnumerable<string> FindNotes(string text)
        {
            var param = ParametersHelper.CreateFromObject(new { text });
            return ExecuteSP<string>("USP_Notes_Find", param);
        }
    }
}
