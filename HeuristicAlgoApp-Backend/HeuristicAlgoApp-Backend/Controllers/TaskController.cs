using HeuristicAlgoApp_Backend.Services;
using HeuristicAlgoApp_Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //ContextModel
        private readonly TaskRepository taskRepository;
        private readonly TaskService? taskService;

        [HttpGet]
        public async void TaskForSingleAlgo([FromForm] int algoId, int fitFuncId) {

            //return Ok(await taskService.TaskForSingleAlgo(algoId,fitFuncId));
        }
        [HttpGet]
        public async void TaskForMultiAlgo([FromForm] int[] algoIds, int fitFuncId)
        {

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
