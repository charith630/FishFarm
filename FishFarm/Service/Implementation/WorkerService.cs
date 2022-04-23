using Common.Request;
using Common.Response;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class WorkerService : IWorkerService
    {
        private readonly ILogger<WorkerService> _logger;
        private readonly IWorkerRepository _workerRepository;
        public WorkerService(ILogger<WorkerService> logger,
            IWorkerRepository workerRepository)
        {
            _logger = logger;
            _workerRepository = workerRepository;

        }

        public async Task<List<FarmWorker>> GetWokersByFarmId(int farmId)
        {
            _logger.LogInformation("'WorkerService.GetWokersByFarmId' method started");

            try
            {
                List<Worker> workerList = await _workerRepository.GetAllWokersByFarm(farmId);
                List<FarmWorker>  farmWorkerList = MapToFarmWokerList(workerList);
                return farmWorkerList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return new List<FarmWorker>();
            }
           
        }
         
        public async Task<bool> RegisterWorker(WorkerRequest workerRequest)
        {
            _logger.LogInformation("'WorkerService.RegisterWorker' method started");
            try
            {
                Worker workerObject = MapWorkRequestToDbObject(workerRequest);
                return  await _workerRepository.AddWorker(workerObject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        private static Worker MapWorkRequestToDbObject(WorkerRequest workerRequest)
        {
            return new Worker()
            {
                Name = workerRequest.Name,
                Age = workerRequest.Age,
                Email = workerRequest.Email,
                CertifiedUntil = workerRequest.CertifiedUntil,
                Position = workerRequest.Workerposition,
                FarmId = workerRequest.FarmId
            };
        }

        private static List<FarmWorker> MapToFarmWokerList(List<Worker> workerList)
        {
            List<FarmWorker> farmWorkerList = new List<FarmWorker>();

            foreach (Worker worker in workerList)
            {
                FarmWorker farmWorker = new FarmWorker()
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Age = worker.Age,
                    Position = worker.Position,
                    Email = worker.Email,
                    CertifiedUntil = worker.CertifiedUntil
                };

                farmWorkerList.Add(farmWorker);
            }
            return farmWorkerList;
        }
    }
}
