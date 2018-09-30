using System;
using System.Collections.Generic;
using System.Text;
using TicketMS.API.Infrastructure;
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

        public IEnumerable<PackageVM> GetList(bool onlyOpened, bool onlySpecial, IPaging paging, out int totalCount)
        {
            var packagesEM = packageRepository.GetList(onlyOpened, onlySpecial, paging, out totalCount);
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

        public IEnumerable<PackageVM> GetAvailableForTicket(PackageFilterDTO filterDTO)
        {
            var packagesEM = packageRepository.GetAvailableForTicket(filterDTO);
            return mapper.ConvertCollectionTo<PackageVM>(packagesEM);
        }

        public IEnumerable<PackageVM> Filter(PackageFilterDTO filterDTO)
        {
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

        public int CreateDefaultPackage(PackageDefaultDTO packageDTO)
        {
            throw new NotImplementedException();
        }

        public int CreateSpecialPackage(PackageSpecialDTO packageDTO)
        {
            throw new NotImplementedException();
        }

        public void EditDefaultPackage(int id, PackageDefaultDTO packageDTO)
        {
            throw new NotImplementedException();
        }

        public void EditSpecialPackage(int id, PackageSpecialDTO packageDTO)
        {
            throw new NotImplementedException();
        }

        public void SetPackageOpened(int id, bool isOpened)
        {
            packageRepository.SetPackageOpened(id, isOpened);
        }

        public void MakePackageDefault(int id, PackageDefaultDTO packageDTO)
        {
            throw new NotImplementedException();
        }

        public void MakePackageSpecial(int id, PackageMakeSpecialDTO packageDTO)
        {
            throw new NotImplementedException();
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
