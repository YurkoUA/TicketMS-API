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
            return Ok(packageService.GetList(getListVM, out _));
        }

        [HttpGet("BySerial/{serialId?}")]
        public IActionResult GetBySerial(int serialId)
        {
            return Ok(packageService.GetBySerial(serialId));
        }

        [HttpGet("ByColor/{colorId?}")]
        public IActionResult GetByColor(int colorId)
        {
            return Ok(packageService.GetByColor(colorId));
        }

        [HttpGet("ByNominal/{nominalId?}")]
        public IActionResult GetByNominal(int nominalId)
        {
            return Ok(packageService.GetByNominal(nominalId));
        }

        [HttpGet("Filter"), ValidateModel]
        public IActionResult Filter([FromQuery]PackageFilterVM filterVM)
        {
            return Ok(packageService.Filter(filterVM));
        }

        [HttpGet("Available"), ValidateModel]
        public IActionResult GetAvailableForTicket([FromQuery]PackageFilterVM filterVM)
        {
            return Ok(packageService.GetAvailableForTicket(filterVM));
        }

        [HttpGet("Count")]
        public IActionResult Count()
        {
            return Ok(packageService.CountPackages());
        }

        [HttpGet("Find"), ValidateModel]
        public IActionResult Find([FromQuery]SearchVM searchVM)
        {
            return Ok(packageService.Find(searchVM.Expression));
        }

        [HttpGet("Get")]
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

        [HttpPost("Special"), ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult CreateSpecial([FromBody]PackageSpecialCreateVM packageCreateVM)
        {
            var id = packageService.CreateSpecialPackage(packageCreateVM);
            return Identifier(id);
        }

        [HttpPut("{id?}"), ValidateModel]
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

        [HttpDelete("{id?}"), ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            packageService.DeletePackage(id);
            return Ok();
        }
    }
}