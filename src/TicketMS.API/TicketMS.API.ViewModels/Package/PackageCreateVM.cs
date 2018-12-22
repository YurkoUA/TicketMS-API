using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageCreateVM
    {
        [BindNever]
        public int Id { get; set; }

        public int ColorId { get; set; }
        public int SerialId { get; set; }
        public int NominalId { get; set; }

        [Range(0, 9)]
        public int? FirstDigit { get; set; }

        [StringLength(128)]
        public string Note { get; set; }
    }
}
