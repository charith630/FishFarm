using Common.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Farm : ControllerBase
    {
       

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FarmRequest farmRequest)
        {
            
            return Conflict();
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            throw new Exception();
        }
    }
}
