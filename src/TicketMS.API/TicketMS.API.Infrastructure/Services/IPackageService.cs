using System.Collections.Generic;
using TicketMS.API.Infrastructure.DTO.Package;
using TicketMS.API.ViewModels.Package;

namespace TicketMS.API.Infrastructure.Services
{
    public interface IPackageService
    {
        IEnumerable<PackageVM> GetList(bool onlyOpened, bool onlySpecial, IPaging paging, out int totalCount);

        IEnumerable<PackageVM> GetBySerial(int serialId);
        IEnumerable<PackageVM> GetByColor(int colorId);
        IEnumerable<PackageVM> GetByNominal(int nominalId);
        IEnumerable<PackageVM> GetAvailableForTicket(PackageFilterDTO filterDTO);

        IEnumerable<PackageVM> Filter(PackageFilterDTO filterDTO);

        PackagesTotalDTO CountPackages();

        IEnumerable<PackageVM> Find(string name);

        PackageVM GetPackage(int id);

        int CreateDefaultPackage(PackageCreateVM package);
        int CreateSpecialPackage(PackageSpecialCreateVM package);

        void EditDefaultPackage(int id, PackageCreateVM package);
        void EditSpecialPackage(int id, PackageSpecialCreateVM package);

        void SetPackageOpened(int id, bool isOpened);
        void MakePackageDefault(int id, PackageCreateVM package);
        void MakePackageSpecial(int id, PackageMakeSpecialVM package);

        void DeletePackage(int id);

        bool Exists(string name);
        bool Exists(string name, int id);
    }
}
