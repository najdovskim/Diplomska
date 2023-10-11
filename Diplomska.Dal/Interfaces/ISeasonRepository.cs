using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface ISeasonRepository
    {
        Task<List<Season>> GetAllSeasons();
        Task<Season> GetSeasonById(int seasonId);
    }
}
