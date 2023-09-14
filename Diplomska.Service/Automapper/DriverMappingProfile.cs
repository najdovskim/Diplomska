using AutoMapper;
using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Automapper
{
    public class DriverMappingProfile :Profile
    {
        public DriverMappingProfile()
        {
            CreateMap<Driver, DriverMappingProfile>();
        }
    }
}
