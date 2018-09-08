using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels.Color
{
    public class ColorVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, PaletteColor]
        public string PaletteName { get; set; }

        [BindNever]
        public int PackagesCount { get; set; }
        [BindNever]
        public int TicketsCount { get; set; }
    }
}
