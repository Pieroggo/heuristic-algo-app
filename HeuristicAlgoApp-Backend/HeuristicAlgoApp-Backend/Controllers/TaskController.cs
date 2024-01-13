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
        //should also have dimensions and bounds for fitFunc
        {

            //double?[]? result = await _sender.Send(new SolveWithSingleAlgoCommand(algoId, fitFuncIds, new double[] { }));
            string reportPath = Directory.GetCurrentDirectory()+ "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\DummySingleAlgoPDF.pdf"; //need to test it, may need to backtrack 1 more folder
            //if (result!=null) {
            return Ok(reportPath); //}
           // else { return BadRequest(); }
        }
        [HttpPost]
        public async Task<ActionResult> TaskForMultiAlgo([FromBody] MultiTaskDTO multiTask)
        //should also have dimensions and bounds for fitFunc
        {
            //double?[]? results = await _sender.Send(new SolveWithManyAlgosCommand(algoIds,fitFuncId));
            string reportPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\DummyMultiAlgoPDF.pdf";
           // if (results!= null) {
           return Ok(reportPath); //}
           // else { return BadRequest(); }
            //return Ok(await taskService.TaskForSingleAlgo(algoId,fitFuncId));
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
