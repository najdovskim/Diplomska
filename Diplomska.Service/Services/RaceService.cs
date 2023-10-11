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
    public class RaceService : IRaceService
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IMapper _mapper;

        public RaceService(IRaceRepository raceRepository, IMapper mapper)
        {
            _raceRepository = raceRepository;
            _mapper = mapper;
        }

        public async Task<List<RaceGetDto>> GetAllRaces(int seasonId)
        {
            var races = await _raceRepository.GetAllRaces(seasonId);
            var racesGet = _mapper.Map<List<RaceGetDto>>(races);

            return racesGet;
        }

        public async Task<RaceGetDto> GetRaceById(int raceId)
        {
            var race = await _raceRepository.GetRaceById(raceId);


            if (race == null)
            {
                return null;
            }

            var mapped = _mapper.Map<RaceGetDto>(race);

            return mapped;

        }
    }
}
