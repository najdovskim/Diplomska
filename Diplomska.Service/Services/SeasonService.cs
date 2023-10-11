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
    public class SeasonService :ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public SeasonService(ISeasonRepository seasonRepository, IMapper mapper)
        {
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<List<SeasonGetDto>> GetAllSeasons()
        {
            var seasons = await _seasonRepository.GetAllSeasons();
            var seasonsGet = _mapper.Map<List<SeasonGetDto>>(seasons);

            return seasonsGet;
        }

        public async Task<SeasonGetDto> GetSeasonById(int seasonId)
        {
            var season = await _seasonRepository.GetSeasonById(seasonId);


            if (season == null)
            {
                return null;
            }

            var mapped = _mapper.Map<SeasonGetDto>(season);
            return mapped;
        }
    }
}
