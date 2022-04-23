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
    public class WorkerController :  ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WorkerRequest workerRequest)
        {
            bool result = await _workerService.RegisterWorker(workerRequest);
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
        public async Task<ActionResult<List<FarmWorker>>> Get(int farmId)
        {
            return Ok(await _workerService.GetWokersByFarmId(farmId));
        }
    }
}
