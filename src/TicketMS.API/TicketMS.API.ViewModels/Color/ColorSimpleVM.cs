using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Color
{
    public class ColorSimpleVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
