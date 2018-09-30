using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Nominal
{
    public class NominalSimpleVM
    {
        [BindNever]
        public int Id { get; set; }

        [Required, Range(0.01, double.MaxValue)]
        public decimal Value { get; set; }
    }
}
