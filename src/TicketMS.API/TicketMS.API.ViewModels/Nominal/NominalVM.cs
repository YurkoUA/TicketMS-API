using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Nominal
{
    public class NominalVM : NominalSimpleVM
    {
        [BindNever]
        public bool IsDefault { get; set; }

        [BindNever]
        public int PackagesCount { get; set; }
        [BindNever]
        public int TicketsCount { get; set; }
    }
}
