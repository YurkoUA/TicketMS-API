namespace TicketMS.API.Infrastructure.DTO.Package
{
    public class PackageFilterDTO : FilterDTO
    {
        public bool OnlyOpened { get; set; }
        public bool HideSpecial { get; set; }
    }
}
