using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ISender _sender;
        public TaskController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> TaskForSingleAlgo(int algoId, int fitFuncId, [FromBody] double[] parameters) {

            string? result = await _sender.Send(new SolveWithSingleAlgoCommand(algoId, fitFuncId, parameters));
            if (result!=null) { return Ok(result); }
            else { return BadRequest(); }
        }
        [HttpGet]
        public async Task<ActionResult> TaskForMultiAlgo([FromForm] int[] algoIds, int fitFuncId)
        {
            double[]? results = await _sender.Send(new SolveWithManyAlgosCommand(algoIds, fitFuncId));
            if (results.Length != 0) { return Ok(results); }
            else { return BadRequest(); }
            //return Ok(await taskService.TaskForSingleAlgo(algoId,fitFuncId));
        }
        [HttpGet]
        public async void BreakSolving()
        {

            //return Ok(await taskService.TaskForSingleAlgo(algoId,fitFuncId));
        }
        [HttpGet]
        public async void ResumeSolving()
        {

            //return Ok(await taskService.TaskForSingleAlgo(algoId,fitFuncId));
        }
    }
}
