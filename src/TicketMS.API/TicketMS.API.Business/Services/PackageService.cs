using System.Collections.Generic;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Common.Interfaces;
using TicketMS.API.Infrastructure.DTO.Package;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Repositories;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels.Package;

namespace TicketMS.API.Business.Services
{
    public class PackageService : Service, IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IMappingService mapper, IPackageRepository packageRepository) : base(mapper)
        {
            this.packageRepository = packageRepository;
        }

        public IEnumerable<PackageVM> GetList(PackageGetListVM getListVM, out int totalCount)
        {
            var packagesEM = packageRepository.GetList(getListVM.OnlyOpened, getListVM.OnlySpecial, getListVM, out totalCount);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> GetBySerial(int serialId)
        {
            var packagesEM = packageRepository.GetBySerial(serialId);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> GetByColor(int colorId)
        {
            var packagesEM = packageRepository.GetByColor(colorId);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> GetByNominal(int nominalId)
        {
            var packagesEM = packageRepository.GetByNominal(nominalId);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> GetAvailableForTicket(PackageFilterVM filterVM)
        {
            var filterDTO = mapper.ConvertTo<PackageFilterDTO>(filterVM);
            var packagesEM = packageRepository.GetAvailableForTicket(filterDTO);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> Filter(PackageFilterVM filterVM)
        {
            var filterDTO = mapper.ConvertTo<PackageFilterDTO>(filterVM);
            var packagesEM = packageRepository.Filter(filterDTO);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public PackagesTotalDTO CountPackages()
        {
            return packageRepository.CountPackages();
        }

        public IEnumerable<PackageVM> Find(string name)
        {
            var packagesEM = packageRepository.Find(name);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public PackageVM GetPackage(int id)
        {
            var packageEM = packageRepository.GetPackage(id);
            return mapper.ConvertTo<PackageVM>(packageEM);
        }

        public int CreateDefaultPackage(PackageCreateVM package)
        {
            var dto = mapper.ConvertTo<PackageDefaultDTO>(package);
            return packageRepository.CreateDefaultPackage(dto);
        }

        public int CreateSpecialPackage(PackageSpecialCreateVM package)
        {
            var dto = mapper.ConvertTo<PackageSpecialDTO>(package);
            return packageRepository.CreateSpecialPackage(dto);
        }

        public void EditDefaultPackage(int id, PackageCreateVM package)
        {
            var dto = mapper.ConvertTo<PackageDefaultDTO>(package);
            packageRepository.EditDefaultPackage(id, dto);
        }

        public void EditSpecialPackage(int id, PackageSpecialCreateVM package)
        {
            var dto = mapper.ConvertTo<PackageSpecialDTO>(package);
            packageRepository.EditSpecialPackage(id, dto);
        }

        public void SetPackageOpened(int id, bool isOpened)
        {
            packageRepository.SetPackageOpened(id, isOpened);
        }

        public void MakePackageDefault(int id, PackageCreateVM package)
        {
            var dto = mapper.ConvertTo<PackageDefaultDTO>(package);
            packageRepository.MakePackageDefault(id, dto);
        }

        public void MakePackageSpecial(int id, PackageMakeSpecialVM package)
        {
            var dto = mapper.ConvertTo<PackageMakeSpecialDTO>(package);
            packageRepository.MakePackageSpecial(id, dto);
        }

        public void DeletePackage(int id)
        {
            packageRepository.DeletePackage(id);
        }

        public bool Exists(string name)
        {
            return packageRepository.Exists(name);
        }

        public bool Exists(string name, int id)
        {
            return packageRepository.Exists(name, id);
        }
    }
}
