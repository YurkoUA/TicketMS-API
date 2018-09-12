using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketMS.API.Filters;
using TicketMS.API.Infrastructure.Interfaces;
using TicketMS.API.Infrastructure.Services;
using TicketMS.API.ViewModels;

namespace TicketMS.API.Controllers
{
    public class NominalController : ApplicationController
    {
        private readonly INominalService nominalService;

        public NominalController(IMappingService mappingService, INominalService nominalService) : base(mappingService)
        {
            this.nominalService = nominalService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(nominalService.GetAllNominals());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(nominalService.GetNominal(id));
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]NominalVM nominal)
        {
            var id = nominalService.CreateNominal(nominal.Value);
            return Identifier(id);
        }

        [HttpPut("{id}"), ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Edit(int id, [FromBody]NominalVM nominal)
        {
            nominalService.EditNominal(id, nominal.Value);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            nominalService.DeleteNominal(id);
            return Ok();
        }
    }
}
