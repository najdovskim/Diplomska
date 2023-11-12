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

        public async Task<List<DriverStandingGetDto>> GetAllDriverStandings(int seasonId)
        {
            var driverStanding = await _driverStandingRepository.GetAllDriverStandings(seasonId);


            if (driverStanding.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<List<DriverStandingGetDto>>(driverStanding);

            return mapped;
        }

        public async Task<TransformedDataDto> GetDriverData(string driverId)
        {
            var Driver = await _driverStandingRepository.GetStandingsForDriver(driverId);
            var DriverGet = _mapper.Map<TransformedDataDto>(Driver);

            return DriverGet;
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
