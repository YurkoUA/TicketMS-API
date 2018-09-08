using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels
{
    public class NominalVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Value { get; set; }

        [BindNever]
        public int PackagesCount { get; set; }
        [BindNever]
        public int TicketsCount { get; set; }
    }
}
