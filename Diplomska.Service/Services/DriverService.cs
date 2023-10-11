using AutoMapper;
using Diplomska.Dal.Interfaces;
using Diplomska.Service.Dtos;
using Diplomska.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Services
{
    public class DriverService : IDriverService
    {

        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _mapper = mapper;
            _driverRepository = driverRepository;
        }

        public async Task<List<DriverGetDto>> GetAllDrivers(int seasonId)
        {
            var drivers = await _driverRepository.GetAllDrivers(seasonId);
            var driversGet = _mapper.Map<List<DriverGetDto>>(drivers);

            return driversGet;
        }

        public async Task<DriverGetDto> GetDriverById(string driverId)
        {
            var driver = await _driverRepository.GetDriverById(driverId);


            if (driverId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<DriverGetDto>(driver);
            return mapped;
        }
    }
}
