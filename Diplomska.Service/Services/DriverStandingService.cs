using AutoMapper;
using Diplomska.Dal.Interfaces;
using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using Diplomska.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Services
{
    public class DriverStandingService : IDriverStandingService
    {
        private readonly IDriverStandingRepository _driverStandingRepository;
        private readonly IMapper _mapper;

        public DriverStandingService(IDriverStandingRepository driverStandingRepository, IMapper mapper)
        {
            _driverStandingRepository = driverStandingRepository;
            _mapper = mapper;
        }

        public async Task<List<DriverStandingGetDto>> GetDriverStandingByRound(int seasonId, int round)
        {
            var driverStanding = await _driverStandingRepository.GetDriverStandingByRound(seasonId, round);


            if (driverStanding.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<List<DriverStandingGetDto>>(driverStanding);

            return mapped;
        }
    }

}
