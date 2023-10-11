﻿using AutoMapper;
using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
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
            CreateMap<Driver, DriverGetDto>()
                .ReverseMap();
        }
    }
}
