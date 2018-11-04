namespace TicketMS.API.ViewModels.Package
{
    public class PackageFilterVM : FilterVM
    {
        public bool OnlyOpened { get; set; }
        public bool HideSpecial { get; set; }
    }
}
