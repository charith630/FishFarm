using Common.Request;
using Common.Response;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IWorkerService
    {
        Task<bool> RegisterWorker(WorkerRequest workerRequest);
        Task<List<FarmWorker>> GetWokersByFarmId(int farmId);
    }
}
