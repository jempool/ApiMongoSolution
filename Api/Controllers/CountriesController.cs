using System;
using System.Collections.Generic;
using Api.Models;
using Api.Services;
using Api.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly IUsersService _usersService;

        public CountriesController(ILogger<CountriesController> logger, IUsersService service)
        {
            _logger = logger;
            _logger.LogInformation("Users Controller was created!");
            _usersService = service;
        }

        [HttpGet("{countryName}/Users")]
        public ActionResult GetUsersByCountry(string countryName)
        {
            try
            {
                return Ok(_usersService.GetUsersByCountry(countryName));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }

        [HttpGet("")]
        public ActionResult GetAllUniqueCountries()
        {
            try
            {
                return Ok(_usersService.GetAllUniqueCountries());
            }
            catch (NotFoundException ex)
            {
                return NotFound(new AppError(ex.Message));
            }
        }
    }
}
