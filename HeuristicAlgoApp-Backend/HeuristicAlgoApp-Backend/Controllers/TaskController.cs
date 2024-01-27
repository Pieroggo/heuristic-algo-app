using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly ISender _sender;
        public TaskController(ISender sender) => _sender = sender;

        [HttpPost]
        public async Task<ActionResult> TaskForSingleAlgo([FromBody] SingleTaskDTO singleTask)// double[] parameters
        {
            Console.WriteLine("Starting TaskForSingleAlgo");
            string?[]? reports = await _sender.Send(new SolveWithSingleAlgoCommand(singleTask));
            if (reports !=null) {
                string reportPath = reports[0];
                Console.WriteLine($"First report: {reportPath}");
                Console.WriteLine("Sending OK for Single Algo");
                return Ok(reports);
            }
           else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<ActionResult> TaskForMultiAlgo([FromBody] MultiTaskDTO multiTask)
        {
            Console.WriteLine("Starting TaskForMultiAlgo");
            string?[]? reports = await _sender.Send(new SolveWithManyAlgosCommand(multiTask));
            if (reports != null)
            {
                string reportPath = reports[0];
                Console.WriteLine($"First report: {reportPath}");
                Console.WriteLine("Sending OK for Multi Algo");
                return Ok(reports);
            }
            else { return StatusCode(500,"No reports"); }
        }
        [HttpGet]
        public async Task<ActionResult> BreakSolving()
        {
            string algoState=await _sender.Send(new BreakSolvingCommand());
            return Ok(algoState);
        }
        [HttpGet]
        public async Task<ActionResult> ResumeSolving()
        {
            await _sender.Send(new ResumeSolvingCommand());
            return Ok("Resume");
            //to be implemented
        }
        [HttpGet]
        public async Task<ActionResult> BreakMultiSolving()
        {
            string algoState = await _sender.Send(new BreakMultiSolvingCommand());
            return Ok(algoState);
        }
        [HttpGet]
        public async Task<ActionResult> ResumeMutliSolving()
        {
            await _sender.Send(new ResumeMultiSolvingCommand());
            return Ok("Resume");
            //to be implemented
        }
    }
}
