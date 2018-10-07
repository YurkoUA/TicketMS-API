using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;

namespace TicketMS.API.Controllers
{
    public class PackageController : ApplicationController
    {
        private readonly IPackageService packageService;

        public PackageController(IMappingService mappingService, IPackageService packageService) : base(mappingService)
        {
            this.packageService = packageService;
        }
    }
}