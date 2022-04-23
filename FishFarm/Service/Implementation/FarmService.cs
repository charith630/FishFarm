using Common.Request;
using Common.Response;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<FishFarm>> GetAllFarms()
        {
            _logger.LogInformation("'FarmService.GetAllFarms' method started");

            List<FishFarm> fishFarmList = new List<FishFarm>();
            try
            {
                List<Farm> farmList = await _farmRepository.GetAllFarms();
                fishFarmList = MapToFishFarmObjectList(farmList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return fishFarmList;
        }

        public async Task<bool> RegisterFarm(FarmRequest farmRequest)
        {
            _logger.LogInformation("'FarmService.RegisterFarm' method started");
            try
            {
                Farm farmObject = MapFarmRequestToDbObject(farmRequest);
                bool result = await _farmRepository.AddFarm(farmObject);
                return result;
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

        private static List<FishFarm> MapToFishFarmObjectList(List<Farm> farmList)
        {
            List<FishFarm> fishFarmList = new List<FishFarm>();

            foreach (Farm farm in farmList)
            {
                FishFarm fishFarm = new FishFarm()
                {
                    Id = farm.Id,
                    Longitude = farm.Longitude,
                    Latitude = farm.Latitude,
                    NumberOfCages = farm.NumberOfCages,
                    IsBargeExist = farm.IsBargeExist,
                };

                fishFarmList.Add(fishFarm);
            }

            return fishFarmList;


        }

    }
}
