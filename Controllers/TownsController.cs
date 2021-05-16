using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCountriesMap.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class TownsController : ControllerBase
    {
        public TownsController(LocationDB context)
        {
            _context = context;
        }

        public LocationDB _context { get; }

        [HttpGet("{countryId}")]
        public IActionResult GetTownsById(int countryId)
        {
            //return all towns
            if (countryId <= 0)
                return BadRequest();

            var towns = _context.Towns.Where(x => x.CountryId == countryId).ToList();
          
            if (towns == null)
                return Ok(new { Error = "Empty town list" });
            
            return Ok(towns);
        }
    }
}
