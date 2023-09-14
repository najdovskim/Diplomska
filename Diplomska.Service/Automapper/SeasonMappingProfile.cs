using AutoMapper;
using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Automapper
{
    public class SeasonMappingProfile: Profile
    {
        public SeasonMappingProfile()
        {
            CreateMap<Season, SeasonMappingProfile>();
        }

    }
}
