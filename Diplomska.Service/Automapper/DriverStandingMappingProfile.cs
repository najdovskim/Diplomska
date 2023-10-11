using AutoMapper;
using Diplomska.Dal.RootTable;
using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Automapper
{
    public class DriverStandingMappingProfile : Profile
    {
        public DriverStandingMappingProfile()
        {
            CreateMap<DriverStanding, DriverStandingGetDto>();
           
            // Add more mappings as needed
        }
    }
}
