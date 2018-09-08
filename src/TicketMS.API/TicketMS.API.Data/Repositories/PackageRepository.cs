using System.Collections.Generic;
using System.Linq;
using TicketMS.API.Data.Entity;
using TicketMS.API.Infrastructure;
using TicketMS.API.Infrastructure.Database;
using TicketMS.API.Infrastructure.DTO.Package;
using TicketMS.API.Infrastructure.Extensions;
using TicketMS.API.Infrastructure.Helpers;
using TicketMS.API.Infrastructure.Repositories;

namespace TicketMS.API.Data.Repositories
{
    public class PackageRepository : DapperRepository, IPackageRepository
    {
        const string SPLIT_ON = "SerialId,ColorId,NominalId";
        const string SPLIT_ON_SHORT = "Id,Id,Id";

        public PackageRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<PackageEM> GetList(bool onlyOpened, bool onlySpecial, IPaging paging, out int totalCount)
        {
            var param = ParametersHelper.CreateFromObject(paging, new { onlyOpened, onlySpecial }).IncludeOutputTotal();

            var packages = ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_GetList", PackageEM.MapPackage, SPLIT_ON, param);
            totalCount = param.GetOutputTotal();
            return packages;
        }

        public IEnumerable<PackageEM> GetBySerial(int serialId)
        {
            var param = ParametersHelper.CreateFromObject(new { serialId });
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_GetBySerial", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public IEnumerable<PackageEM> GetByColor(int colorId)
        {
            var param = ParametersHelper.CreateFromObject(new { colorId });
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_GetByColor", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public IEnumerable<PackageEM> GetByNominal(int nominalId)
        {
            var param = ParametersHelper.CreateFromObject(new { nominalId });
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_Nominal", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public IEnumerable<PackageEM> GetAvailableForTicket(PackageFilterDTO filterDTO)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO);
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_GetForTicket", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public IEnumerable<PackageEM> Filter(PackageFilterDTO filterDTO)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO);
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_Filter", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public PackagesTotalDTO CountPackages()
        {
            return ExecuteQuerySingle<PackagesTotalDTO>("SELECT * FROM [v_PackagesTotal]");
        }

        public IEnumerable<PackageEM> Find(string name)
        {
            var param = ParametersHelper.CreateFromObject(new { name });
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_Find", PackageEM.MapPackage, SPLIT_ON, param);
        }

        public PackageEM GetPackage(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSP<PackageEM, SerialEM, ColorEM, NominalEM, PackageEM>("USP_Package_Get", PackageEM.MapPackage, SPLIT_ON_SHORT, param).FirstOrDefault();
        }

        public int CreateDefaultPackage(PackageDefaultDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeOutputId();
            ExecuteSP("USP_Package_CreateDefault", param);
            return param.GetOutputId();
        }

        public int CreateSpecialPackage(PackageSpecialDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeOutputId();
            ExecuteSP("USP_Package_CreateSpecial", param);
            return param.GetOutputId();
        }

        public void EditDefaultPackage(int id, PackageDefaultDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeId(id);
            ExecuteSP("USP_Package_EditDefault", param);
        }

        public void EditSpecialPackage(int id, PackageSpecialDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeId(id);
            ExecuteSP("USP_Package_EditSpecial", param);
        }

        public void SetPackageOpened(int id, bool isOpened)
        {
            var param = ParametersHelper.CreateFromObject(new { isOpened }).IncludeId(id);
            ExecuteSP("USP_Package_SetOpened", param);
        }

        public void MakePackageDefault(int id, PackageDefaultDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeId(id);
            ExecuteSP("USP_Package_MakeDefault", param);
        }

        public void MakePackageSpecial(int id, PackageMakeSpecialDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeId(id);
            ExecuteSP("USP_Package_MakeSpecial", param);
        }

        public void DeletePackage(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            ExecuteSP("USP_Package_Delete", param);
        }

        public bool Exists(string name)
        {
            var param = ParametersHelper.CreateFromObject(new { name });
            var sql = "SELECT [dbo].[fn_Package_Exists](@name)";
            return ExecuteAggregateQuery<bool>(sql, param);
        }

        public bool Exists(string name, int id)
        {
            var param = ParametersHelper.CreateFromObject(new { name }).IncludeId(id);
            var sql = "SELECT [dbo].[fn_Package_Exists](@name, @id)";
            return ExecuteAggregateQuery<bool>(sql, param);
        }
    }
}
