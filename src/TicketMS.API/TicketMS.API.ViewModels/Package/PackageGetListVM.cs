using TicketMS.API.Infrastructure.Common.Interfaces;

namespace TicketMS.API.ViewModels.Package
{
    public class PackageGetListVM : IPaging
    {
        public int Offset { get; set; } = 0;
        public int Take { get; set; } = 20;
        public bool OnlySpecial { get; set; }
        public bool OnlyOpened { get; set; }
    }
}
