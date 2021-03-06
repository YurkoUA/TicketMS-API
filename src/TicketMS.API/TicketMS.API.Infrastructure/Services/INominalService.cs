﻿using System.Collections.Generic;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Nominal;

namespace TicketMS.API.Infrastructure.Services
{
    public interface INominalService
    {
        IEnumerable<NominalVM> GetAllNominals();
        IEnumerable<NameValueVM<decimal>> GetNominalsNameValues();
        NominalVM GetNominal(int id);

        int CreateNominal(decimal value);
        void EditNominal(int id, decimal value);
        void DeleteNominal(int id);

        void SetAsDefault(int id);
    }
}
