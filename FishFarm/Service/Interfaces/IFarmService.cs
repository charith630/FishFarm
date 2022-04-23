using Common.Request;

namespace Service.Interfaces
{
    public interface IFarmService
    {
        public bool RegisterFarm(FarmRequest farmRequest);

        public void GetAllFarms();
    }
}
