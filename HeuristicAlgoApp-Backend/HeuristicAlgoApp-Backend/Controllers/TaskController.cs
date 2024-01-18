using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
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

        [HttpPost]
        public async Task<ActionResult> TaskForSingleAlgo([FromBody] SingleTaskDTO singleTask)// double[] parameters
        {
            Console.WriteLine("Starting TaskForSingleAlgo");
            double?[]? results = await _sender.Send(new SolveWithSingleAlgoCommand(singleTask));
            string reportPath = Directory.GetCurrentDirectory()+ "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\DummySingleAlgoPDF.pdf"; //need to test it, may need to backtrack 1 more folder
            if (results !=null) {
                Console.Write($"Result: [{results[0]}");
                for (int i = 1; i < results.Count(); i++)
                {
                    Console.Write($", {results[i]}");
                }
                Console.WriteLine("]");
                Console.WriteLine("Sending OK for Single Algo");
                return Ok(reportPath);
            }
           else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<ActionResult> TaskForMultiAlgo([FromBody] MultiTaskDTO multiTask)
        {
            Console.WriteLine("Starting TaskForMultiAlgo");
            double?[]? results = await _sender.Send(new SolveWithManyAlgosCommand(multiTask));
            string reportPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\DummySingleAlgoPDF.pdf"; //need to test it, may need to backtrack 1 more folder
            if (results != null)
            {
                Console.Write($"Result: [{results[0]}");
                for (int i = 1; i < results.Count(); i++)
                {
                    Console.Write($", {results[i]}");
                }
                Console.WriteLine("]");
                Console.WriteLine("Sending OK for Multi Algo");
                return Ok(reportPath);
            }
            else { return BadRequest(); }
        }
        [HttpGet]
        public async Task<ActionResult> GetSolvingSingleAlgo()
        {
            //to be implemented
            return Ok("soon :)");

        }
        [HttpGet]
        public async Task<ActionResult> GetSolvingMultiAlgo()
        {
            //to be implemented
            return Ok("soon :)");
        }
        [HttpPost]
        public async Task<ActionResult> BreakSolving()
        {
            await _sender.Send(new BreakSolvingCommand());
            return Ok();
        }
        [HttpPost]
        public async Task<ActionResult> ResumeSolving()
        {
            await _sender.Send(new ResumeSolvingCommand());
            return Ok();
            //to be implemented
        }
    }
}
