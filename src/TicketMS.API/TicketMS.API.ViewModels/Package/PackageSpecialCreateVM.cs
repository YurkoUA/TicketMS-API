using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageSpecialCreateVM
    {
        [BindNever]
        public int Id { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public int? ColorId { get; set; }
        public int? SerialId { get; set; }
        public int NominalId { get; set; }

        [StringLength(128)]
        public string Note { get; set; }
    }
}
