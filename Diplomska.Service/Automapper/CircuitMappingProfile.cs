using AutoMapper;
using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using FluentAssertions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Automapper
{
    public class CircuitMappingProfile :Profile 
    {
        public CircuitMappingProfile()
        {
            CreateMap<Circuit, CircuitGetDto>()
                .ReverseMap();
        }
    }

}
