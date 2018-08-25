﻿using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Data.Entity.Secondary;
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
        public PackageRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<PackageEM> GetList(bool onlyOpened, bool onlySpecial, IPaging paging)
        {
            var param = ParametersHelper.CreateFromObject(paging, new { onlyOpened, onlySpecial });
            return ExecuteSP<PackageEM>("USP_Package_GetList", param);
        }

        public IEnumerable<PackageEM> GetBySerial(int serialId)
        {
            var param = ParametersHelper.CreateFromObject(new { serialId });
            return ExecuteSP<PackageEM>("USP_Package_GetBySerial", param);
        }

        public IEnumerable<PackageEM> GetByColor(int colorId)
        {
            var param = ParametersHelper.CreateFromObject(new { colorId });
            return ExecuteSP<PackageEM>("USP_Package_GetByColor", param);
        }

        public IEnumerable<PackageEM> GetByNominal(int nominalId)
        {
            var param = ParametersHelper.CreateFromObject(new { nominalId });
            return ExecuteSP<PackageEM>("USP_Package_Nominal", param);
        }

        public IEnumerable<PackageEM> GetAvailableForTicket(PackageFilterDTO filterDTO)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO);
            return ExecuteSP<PackageEM>("USP_Package_GetForTicket", param);
        }

        public IEnumerable<PackageEM> Filter(PackageFilterDTO filterDTO)
        {
            var param = ParametersHelper.CreateFromObject(filterDTO);
            return ExecuteSP<PackageEM>("USP_Package_Filter", param);
        }

        public PackagesTotalEM CountPackages()
        {
            return ExecuteQuerySingle<PackagesTotalEM>("SELECT * FROM [v_PackagesTotal]");
        }

        public IEnumerable<PackageEM> Find(string name)
        {
            var param = ParametersHelper.CreateFromObject(new { name });
            return ExecuteSP<PackageEM>("USP_Package_Find", param);
        }

        public PackageEM GetPackage(int id)
        {
            var param = ParametersHelper.CreateIdParameter(id);
            return ExecuteSPSingle<PackageEM>("USP_Package_Get", param);
        }

        public int CreateDefaultPackage(PackageDefaultDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeReturnedId();
            ExecuteSP("USP_Package_CreateDefault", param);
            return param.GetReturnedId();
        }

        public int CreateSpecialPackage(PackageSpecialDTO packageDTO)
        {
            var param = ParametersHelper.CreateFromObject(packageDTO).IncludeReturnedId();
            ExecuteSP("USP_Package_CreateSpecial", param);
            return param.GetReturnedId();
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