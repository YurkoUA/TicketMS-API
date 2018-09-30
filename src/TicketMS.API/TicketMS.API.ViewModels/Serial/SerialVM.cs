using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Serial
{
    public class SerialVM : SerialSimpleVM
    {
        [StringLength(128)]
        public string Note { get; set; }

        [BindNever]
        public bool IsDefault { get; set; }

        [BindNever]
        public int PackagesCount { get; set; }
        [BindNever]
        public int TicketsCount { get; set; }
    }
}
