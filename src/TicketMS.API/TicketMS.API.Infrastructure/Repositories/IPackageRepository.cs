using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Data.Entity.Secondary;
using TicketMS.API.Infrastructure.DTO.Package;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface IPackageRepository : IRepository
    {
        IEnumerable<PackageEM> GetList(bool onlyOpened, bool onlySpecial, IPaging paging);

        IEnumerable<PackageEM> GetBySerial(int serialId);
        IEnumerable<PackageEM> GetByColor(int colorId);
        IEnumerable<PackageEM> GetByNominal(int nominalId);
        IEnumerable<PackageEM> GetAvailableForTicket(PackageFilterDTO filterDTO);

        IEnumerable<PackageEM> Filter(PackageFilterDTO filterDTO);

        PackagesTotalEM CountPackages();

        IEnumerable<PackageEM> Find(string name);

        PackageEM GetPackage(int id);

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
