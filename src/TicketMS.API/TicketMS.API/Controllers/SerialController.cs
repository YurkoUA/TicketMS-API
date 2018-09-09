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

namespace TicketMS.API.Controllers
{
    public class SerialController : ApplicationController
    {
        private readonly ISerialService serialService;

        public SerialController(IMappingService mappingService, ISerialService serialService) : base(mappingService)
        {
            this.serialService = serialService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(serialService.GetAllSeries());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(serialService.GetSerial(id));
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]SerialVM serial)
        {
            var id = serialService.CreateSerial(serial);
            return Identifier(id);
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Edit(int id, [FromBody]SerialVM serial)
        {
            serial.Id = id;
            serialService.EditSerial(serial);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            serialService.DeleteSerial(id);
            return Ok();
        }

        [HttpPut("SetDefault/{id?}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult SetDefault(int id)
        {
            serialService.SetAsDefault(id);
            return Ok();
        }
    }
}