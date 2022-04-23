using Common.Request;
using Common.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFarmService
    {
        public Task<bool> RegisterFarm(FarmRequest farmRequest);

        public Task<List<FishFarm>> GetAllFarms();
    }
}
