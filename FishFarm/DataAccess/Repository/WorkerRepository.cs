using Common.Request;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly Context _dbContext;
        private readonly ILogger<WorkerRepository> _logger;
        public WorkerRepository(Context dbContext,
           ILogger<WorkerRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddWorker(Worker worker)
        {
            _logger.LogInformation("'WorkerRepository.AddWorker' method started");
            try
            {
                Worker workerObject = _dbContext.Workers.Where(w => w.Email.ToLower().Equals(worker.Email.ToLower())).FirstOrDefault();
                if (workerObject == null)
                {
                    await _dbContext.Workers.AddAsync(workerObject);
                    int result = await _dbContext.SaveChangesAsync();

                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
           
        }

        public async Task<List<Worker>> GetAllWokersByFarm(int farmId)
        {
            _logger.LogInformation("'WorkerRepository.GetAllWokersByFarm' method started");

            List<Worker> Workers = new List<Worker>();           
            try
            {
                Workers =  _dbContext.Workers.Where(w => w.FarmId == farmId).ToList();
                return Workers;             
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Workers;
            }
        }
     
    }
}
