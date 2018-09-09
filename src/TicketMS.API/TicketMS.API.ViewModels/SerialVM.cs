using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels
{
    public class SerialVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required, SerialName]
        public string Name { get; set; }

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
