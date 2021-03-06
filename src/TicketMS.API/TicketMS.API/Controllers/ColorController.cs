﻿using System;
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
using TicketMS.API.ViewModels.Color;

namespace TicketMS.API.Controllers
{
    public class ColorController : ApplicationController
    {
        private readonly IColorService colorService;

        public ColorController(IMappingService mappingService, IColorService colorService) : base(mappingService)
        {
            this.colorService = colorService;
        }

        [HttpGet("List")]
        public IActionResult GetAll()
        {
            var colors = colorService.GetAllColors();
            return Ok(colors);
        }

        [HttpGet("Get")]
        public IActionResult GetById(int id)
        {
            var color = colorService.GetColor(id);
            return Ok(color);
        }

        [HttpGet("NameValues")]
        public IActionResult NameValues()
        {
            var nameValues = colorService.GetColorsNameValues();
            return Ok(nameValues);
        }

        [HttpPost, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Create([FromBody]ColorVM color)
        {
            var id = colorService.CreateColor(color);
            return Identifier(id);
        }

        [HttpPut, ValidateModel]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Edit(int id, [FromBody]ColorVM color)
        {
            color.Id = id;
            colorService.EditColor(color);
            return Ok();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Delete(int id)
        {
            colorService.DeleteColor(id);
            return Ok();
        }
    }
}