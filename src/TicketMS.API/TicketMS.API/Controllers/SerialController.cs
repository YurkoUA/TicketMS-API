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
using TicketMS.API.ViewModels.Serial;

namespace TicketMS.API.Controllers
{
    public class SerialController : ApplicationController
    {
        private readonly ISerialService serialService;

        public SerialController(IMappingService mappingService, ISerialService serialService) : base(mappingService)
        {
            this.serialService = serialService;
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var series = serialService.GetAllSeries();
            return Ok(series);
        }

        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var serial = serialService.GetSerial(id);
            return Ok();
        }

        [HttpGet("NameValues")]
        public IActionResult NameValues()
        {
            var nameValues = serialService.GetSeriesNameValues();
            return Ok(nameValues);
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
    }
}