using Common.Request;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FarmController : ControllerBase
    {
        private readonly IFarmService farmService;

        public FarmController(IFarmService farmService)
        {
            this.farmService = farmService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FarmRequest farmRequest)
        {
            bool result = await farmService.RegisterFarm(farmRequest);
            return Conflict();
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new Exception();
        }
    }
}
