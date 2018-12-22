using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Color
{
    public class ColorSimpleVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required, StringLength(32)]
        public string Name { get; set; }
    }
}
