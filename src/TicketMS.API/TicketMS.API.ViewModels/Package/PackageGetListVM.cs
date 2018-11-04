using TicketMS.API.Infrastructure.Common.Interfaces;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageGetListVM : IPaging
    {
        public int Offset { get; set; }
        public int Take { get; set; }
        public bool OnlySpecial { get; set; }
        public bool OnlyOpened { get; set; }
    }
}
