﻿using Diplomska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska.Dal.Interfaces
{
    public interface IFromula1Repository
    {          

        Task<List<Result>> GetAllResults();
        Task<Result> GetResultById(int resultId);

    }
}
