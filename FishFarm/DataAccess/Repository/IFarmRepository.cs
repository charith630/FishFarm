using Common.Request;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IFarmRepository
    {
        Task<bool> AddFarm(FarmRequest farmRequest);

        Task<List<Farm>> GetAllFarms();
    }
}
