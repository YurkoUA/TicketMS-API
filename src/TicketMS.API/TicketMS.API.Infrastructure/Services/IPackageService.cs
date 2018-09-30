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

        int CreateDefaultPackage(PackageDefaultDTO packageDTO);
        int CreateSpecialPackage(PackageSpecialDTO packageDTO);

        void EditDefaultPackage(int id, PackageDefaultDTO packageDTO);
        void EditSpecialPackage(int id, PackageSpecialDTO packageDTO);

        void SetPackageOpened(int id, bool isOpened);
        void MakePackageDefault(int id, PackageDefaultDTO packageDTO);
        void MakePackageSpecial(int id, PackageMakeSpecialDTO packageDTO);

        void DeletePackage(int id);

        bool Exists(string name);
        bool Exists(string name, int id);
    }
}
