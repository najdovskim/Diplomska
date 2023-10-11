using Diplomska.Domain.Models;
using Diplomska.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Service.Interfaces
{
    public interface ICircuitService
    {
        Task<List<CircuitGetDto>> GetAllCircuits(int seasonId);
        Task<CircuitGetDto> GetCircuitById(string circuitId);
    }
}
