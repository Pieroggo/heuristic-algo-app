using Microsoft.AspNetCore.Mvc;
using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Services;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;
using System.Web;
using MediatR;
using HeuristicAlgoApp_Backend.Queries;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlgorithmController : ControllerBase
    {
        private readonly ISender sender;

        public AlgorithmController(ISender sender)
        {
            this.sender = sender;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var algorithms = await sender.Send(new GetAllAlgorithmsQuery());
            return Ok(algorithms);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAlgorithmById(int id) //change other tasks in other controllers to ActionResult type
        {
            var algorithm = await sender.Send(new GetAlgorithmByIdQuery(id));
            return Ok(algorithm);
        }
    }
}
