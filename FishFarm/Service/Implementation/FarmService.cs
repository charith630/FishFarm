using Common.Request;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Service.Implementation
{
    public class FarmService : IFarmService
    {
        private readonly ILogger<FarmService> _logger;

        public FarmService(ILogger<FarmService> logger)
        {
            _logger = logger;
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

        public Task<bool> RegisterFarm(FarmRequest farmRequest)
        {
            _logger.LogInformation("'FarmService.RegisterFarm' method started");
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
    }
}
