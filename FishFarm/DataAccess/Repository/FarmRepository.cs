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

        public async Task<bool> AddFarm(FarmRequest farmRequest)
        {
            _logger.LogInformation("'FarmRepository.AddFarm' method started");
            try
            {
                Farm farmObject = _dbContext.Farms.Where(farm => farm.Name.ToLower().Equals(farmRequest.Name.ToLower())).FirstOrDefault();
                if (farmObject == null)
                {
                    Farm newFarmObject = MapFarmRequestToDbObject(farmRequest);

                    await _dbContext.Farms.AddAsync(newFarmObject);
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




        private static Farm MapFarmRequestToDbObject(FarmRequest farmRequest)
        {
            return new Farm()
            {
                Name = farmRequest.Name,
                Longitude = farmRequest.Longitude,
                Latitude = farmRequest.Latitude,
                NumberOfCages = farmRequest.NumberOfCages,
                IsBargeExist = farmRequest.IsBargeExist
            };
        }
    }
}
