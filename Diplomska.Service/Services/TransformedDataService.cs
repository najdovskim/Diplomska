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
    public class TransformedDataService : ITransformedData
    {      
        private readonly IDriverRepository _driverRepository;
        private readonly IDriverStandingRepository _driverStandingRepository;
        private readonly IMapper _mapper;

        public TransformedDataService(IDriverRepository driverRepository, IDriverStandingRepository driverStandingRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _driverStandingRepository = driverStandingRepository;
            _mapper = mapper;
        }

        public async Task<List<TransformedDataDto>> GetAllDriversData(int seasonId)
        {
            
            List<String> drivers = new List<String>();
            var driversGet = await _driverRepository.GetAllDrivers(seasonId);

            foreach(var diver in driversGet)
            {
                drivers.Add(diver.DriverId);
            }

            var standings = new List<TransformedDataDto>();
            foreach(var driver in drivers)
            {
                var temp = await _driverStandingRepository.GetStandingsForDriver(driver);
                var tempDto = _mapper.Map<TransformedDataDto>(temp);
                standings.Add(tempDto);
            }

            return standings;
        }
    }
}
