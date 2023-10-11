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
    public class CircuitService : ICircuitService
    {
        private readonly ICircuitRepository _circuitRepository;
        private readonly IMapper _mapper;

        public CircuitService(ICircuitRepository circuitRepository, IMapper mapper)
        {
            _circuitRepository = circuitRepository;
            _mapper = mapper;
        }

        public async Task<List<CircuitGetDto>> GetAllCircuits(int seasonId)
        {
            var circuits = await _circuitRepository.GetAllCircuits(seasonId);
            var circuitsGet = _mapper.Map<List<CircuitGetDto>>(circuits);

            return circuitsGet;
        }

        public async Task<CircuitGetDto> GetCircuitById(string circuitId)
        {
            var circuit = await _circuitRepository.GetCircuitById(circuitId);

            if (circuitId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<CircuitGetDto>(circuit);
            return mapped;
        }
    }
}
