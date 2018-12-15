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

        [HttpGet("List")]
        public IActionResult GetAll([FromQuery]PackageGetListVM getListVM)
        {
            var packages = packageService.GetList(getListVM, out int total);
            return PagingResponse(packages, total);
        }

        [HttpGet("BySerial")]
        public IActionResult GetBySerial(int serialId)
        {
            var packages = packageService.GetBySerial(serialId);
            return Ok(packages);
        }

        [HttpGet("ByColor")]
        public IActionResult GetByColor(int colorId)
        {
            var packages = packageService.GetByColor(colorId);
            return Ok(packages);
        }

        [HttpGet("ByNominal")]
        public IActionResult GetByNominal(int nominalId)
        {
            var packages = packageService.GetByNominal(nominalId);
            return Ok(packages);
        }

        [HttpGet("Filter"), ValidateModel]
        public IActionResult Filter([FromQuery]PackageFilterVM filterVM)
        {
            var packages = packageService.Filter(filterVM);
            return Ok(packages);
        }

        [HttpGet("Available"), ValidateModel]
        public IActionResult GetAvailableForTicket([FromQuery]PackageFilterVM filterVM)
        {
            var packages = packageService.GetAvailableForTicket(filterVM);
            return Ok(packages);
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            var count = packageService.CountPackages();
            return Ok(count);
        }

        [HttpGet("Find"), ValidateModel]
        public IActionResult Find([FromQuery]SearchVM searchVM)
        {
            return Ok(packageService.Find(searchVM.Expression));
        }

        [HttpGet("Get")]
        public IActionResult GetPackage(int id)
        {
            var package = packageService.GetPackage(id);
            return Ok(package);
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]PackageCreateVM packageCreateVM)
        {
            var id = packageService.CreateDefaultPackage(packageCreateVM);
            return Identifier(id);
        }

        [HttpPost("Special"), ValidateModel]
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

        [HttpPut("Special"), ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult EditSpecial(int id, [FromBody]PackageSpecialCreateVM packageVM)
        {
            packageService.EditSpecialPackage(id, packageVM);
            return Ok();
        }

        [HttpPut("Open")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Open(int id)
        {
            packageService.SetPackageOpened(id, true);
            return Ok();
        }

        [HttpPut("Close")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Close(int id)
        {
            packageService.SetPackageOpened(id, false);
            return Ok();
        }

        [HttpPut("MakeDefault"), ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult MakeDefault(int id, [FromBody]PackageCreateVM packageVM)
        {
            packageService.MakePackageDefault(id, packageVM);
            return Ok();
        }

        [HttpPut("MakeSpecial"), ValidateModel]
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