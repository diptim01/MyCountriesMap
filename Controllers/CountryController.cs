using AutoMapper;
using CoreLayer.DTO;
using DataStore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCountriesMap.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CountryController : Controller
    {
        private readonly LocationDB locationDB;
        private readonly IMapper mapper;

        public CountryController(LocationDB locationDB, IMapper mapper)
        {
            this.locationDB = locationDB;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCountries()
        {
            var countries = locationDB.Countries.Include(c => c.Cities).ThenInclude(t => t.Towns).ToList();

            if (countries == null)
                return Ok(new { Error = "County Object is empty" });

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            if (id <= 0)
                return BadRequest(new { Error = "OOpsy, Id cannot be equal or less to zero"});

            var country = locationDB.Countries.Include(c => c.Cities).ThenInclude(t => t.Towns).FirstOrDefault(x => x.CountryId == id);

            if (country == null)
                return Ok(new { Error = "Country not found" });

            return Ok(country);
        }
    }
}
