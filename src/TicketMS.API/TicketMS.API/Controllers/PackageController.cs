using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Filters;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;
using TicketMS.API.ViewModels.Package;

namespace TicketMS.API.Controllers
{
    public class PackageController : ApplicationController
    {
        private readonly IPackageService packageService;

        public PackageController(IMappingService mappingService, IPackageService packageService) : base(mappingService)
        {
            this.packageService = packageService;
        }

        [HttpGet]
        public IActionResult GetAll(PackageGetListVM getListVM)
        {
            return Ok(packageService.GetList(getListVM, out _));
        }

        [HttpGet]
        public IActionResult GetBySerial(int serialId)
        {
            return Ok(packageService.GetBySerial(serialId));
        }

        [HttpGet]
        public IActionResult GetByColor(int colorId)
        {
            return Ok(packageService.GetByColor(colorId));
        }

        [HttpGet]
        public IActionResult GetByNominal(int nominalId)
        {
            return Ok(packageService.GetByNominal(nominalId));
        }

        [HttpGet]
        public IActionResult Filter(PackageFilterVM filterVM)
        {
            return Ok(packageService.Filter(filterVM));
        }

        [HttpGet, ValidateModel]
        public IActionResult GetAvailableForTicket(PackageFilterVM filterVM)
        {
            return Ok(packageService.GetAvailableForTicket(filterVM));
        }

        [HttpGet]
        public IActionResult Count()
        {
            return Ok(packageService.CountPackages());
        }

        [HttpGet, ValidateModel]
        public IActionResult Find(SearchVM searchVM)
        {
            return Ok(packageService.Find(searchVM.Expression));
        }

        [HttpGet]
        public IActionResult GetPackage(int id)
        {
            return Ok(packageService.GetPackage(id));
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]PackageCreateVM packageCreateVM)
        {
            var id = packageService.CreateDefaultPackage(packageCreateVM);
            return Identifier(id);
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateSpecial([FromBody]PackageSpecialCreateVM packageCreateVM)
        {
            var id = packageService.CreateSpecialPackage(packageCreateVM);
            return Identifier(id);
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Edit(int id, [FromBody]PackageCreateVM packageVM)
        {
            packageService.EditDefaultPackage(id, packageVM);
            return Ok();
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult EditSpecial(int id, [FromBody]PackageSpecialCreateVM packageVM)
        {
            packageService.EditSpecialPackage(id, packageVM);
            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Open(int id)
        {
            packageService.SetPackageOpened(id, true);
            return Ok();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Close(int id)
        {
            packageService.SetPackageOpened(id, false);
            return Ok();
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MakeDefault(int id, [FromBody]PackageCreateVM packageVM)
        {
            packageService.MakePackageDefault(id, packageVM);
            return Ok();
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MakeSpecial(int id, [FromBody]PackageMakeSpecialVM packageVM)
        {
            packageService.MakePackageSpecial(id, packageVM);
            return Ok();
        }

        [HttpDelete, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            packageService.DeletePackage(id);
            return Ok();
        }
    }
}