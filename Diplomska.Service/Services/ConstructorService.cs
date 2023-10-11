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
    public class ConstructorService : IConstructorService 
    {
        private readonly IConstructorRepository _constructorRepository;
        private readonly IMapper _mapper;

        public ConstructorService(IConstructorRepository constructorRepository, IMapper mapper)
        {
            _constructorRepository = constructorRepository;
            _mapper = mapper;
        }

        public async Task<List<ConstructorGetDto>> GetAllConstructors(int seasonId)
        {
            var constructors = await _constructorRepository.GetAllConstructors(seasonId);
            var constructorsGet = _mapper.Map<List<ConstructorGetDto>>(constructors);

            return constructorsGet;
        }

        public async Task<ConstructorGetDto> GetConstructorById(string constructorId)
        {
            var constructor = await _constructorRepository.GetConstructorById(constructorId);

            if (constructorId.Equals(null))
            {
                return null;
            }

            var mapped = _mapper.Map<ConstructorGetDto>(constructor);
            return mapped;
        }



    }
}
