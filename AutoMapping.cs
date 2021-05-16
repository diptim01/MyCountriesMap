using AutoMapper;
using CoreLayer.DTO;
using CoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCountriesMap
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Countries, CountriesDTO>();
        }
    }
}
