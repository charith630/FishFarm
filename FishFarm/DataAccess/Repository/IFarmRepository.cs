using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IFarmRepository
    {
        Task<bool> AddFarm(Farm farm);

        Task<List<Farm>> GetAllFarms();
    }
}
