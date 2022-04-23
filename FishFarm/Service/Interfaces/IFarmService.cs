using Common.Request;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFarmService
    {
        public Task<bool> RegisterFarm(FarmRequest farmRequest);

        public Task GetAllFarms();
    }
}
