using Common.Request;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DataAccess.Repository;

namespace Service.Implementation
{
    public class FarmService : IFarmService
    {
        private readonly ILogger<FarmService> _logger;
        private readonly IFarmRepository _farmRepository;
        public FarmService(ILogger<FarmService> logger,
            IFarmRepository farmRepository)
        {
            _logger = logger;
            _farmRepository = farmRepository;
        }
        public Task GetAllFarms()
        {
            _logger.LogInformation("'FarmService.GetAllFarms' method started");
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> RegisterFarm(FarmRequest farmRequest)
        {
            _logger.LogInformation("'FarmService.RegisterFarm' method started");
            try
            {
                bool result = await _farmRepository.AddFarm(farmRequest);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false; ;
            }
        }
    }
}
