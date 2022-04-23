using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IWorkerRepository
    {
        Task<bool> AddWorker(Worker worker);
        Task<List<Worker>> GetAllWokersByFarm(int farmId);
    }
}
