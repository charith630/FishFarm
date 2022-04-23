using DataAccess.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class FarmRepository : IFarmRepository
    {
        private readonly Context _dbContext;
        private readonly ILogger<FarmRepository> _logger;
        public FarmRepository(Context dbContext,
           ILogger<FarmRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<bool> AddFarm(Farm farm)
        {
            _logger.LogInformation("'FarmRepository.AddFarm' method started");
            try
            {
                Farm farmObject = _dbContext.Farms.Where(f => f.Name.ToLower().Equals(farm.Name.ToLower())).FirstOrDefault();
                if (farmObject == null)
                {
                    await _dbContext.Farms.AddAsync(farm);
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

        public async Task<List<Farm>> GetAllFarms()
        {
            _logger.LogInformation("'FarmRepository.GetAllFarms' method started");

            List<Farm> farms = new List<Farm>();
            try
            {
                farms = _dbContext.Farms.ToList();
                return farms;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return farms;
            }
        }

    }
}
