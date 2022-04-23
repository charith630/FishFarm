using Common.Request;
using Common.Response;
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
        private readonly IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FarmRequest farmRequest)
        {
            bool result = await _farmService.RegisterFarm(farmRequest);
            if (result)
            {
                return Ok();
            }
            else
            {               
                return Conflict();
            }
            
        }
        [HttpGet]
        public async Task<ActionResult<List<FishFarm>>> Get()
        {
            return Ok(await _farmService.GetAllFarms());
        }
    }
}
