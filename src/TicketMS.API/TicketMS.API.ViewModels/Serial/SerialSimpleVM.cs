using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TicketMS.API.Infrastructure.Common.Attributes.Validation;

namespace TicketMS.API.ViewModels.Serial
{
    public class SerialSimpleVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required, SerialName]
        public string Name { get; set; }
    }
}
