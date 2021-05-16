using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCountriesMap.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllCities()
        {
            //Return all countries and their cities
            return Ok();
        }
    }
}
