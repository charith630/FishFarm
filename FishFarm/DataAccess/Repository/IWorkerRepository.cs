using DataAccess.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IWorkerRepository
    {
        Task<bool> AddWorker(Worker worker);
        Task<List<Worker>> GetAllWokersByFarmId(int farmId);
    }
}
