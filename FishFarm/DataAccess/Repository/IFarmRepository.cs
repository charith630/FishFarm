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
        Task<bool> AddFarm(Farm farm);

        Task<List<Farm>> GetAllFarms();
    }
}
