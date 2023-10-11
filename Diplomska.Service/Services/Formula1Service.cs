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
    public class Formula1Service : IFormula1Service
    {
        private readonly IFromula1Repository _fromula1Repository;
        private readonly IMapper _mapper;

        public Formula1Service(IFromula1Repository fromula1Repo, IMapper mapper)
        {            
            _mapper = mapper;
            _fromula1Repository = fromula1Repo;
        }

        

        public async Task<List<ResultGetDto>> GetAllResults()
        {
            var results = await _fromula1Repository.GetAllResults();
            var resultGet = _mapper.Map<List<ResultGetDto>>(results);

            return resultGet;
        }

/*
        public async Task<DriverStandingGetDto> GetDriverStandingById(string driverStandingId)
        {
            var driverStanding = await _fromula1Repository.GetDriverStandingById(driverStandingId);


            if (driverStandingId == null)
            {
                return null;
            }

            var mapped = _mapper.Map<DriverStandingGetDto>(driverStanding);
            return mapped;
        }*/

        public async Task<ResultGetDto> GetResultById(int resultId)
        {
            var result = await _fromula1Repository.GetResultById(resultId);


            if (result == null)
            {
                return null;
            }

            var mapped = _mapper.Map<ResultGetDto>(result);
            return mapped;
        }
      
    }
}
