using HeuristicAlgoApp_Backend.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FitnessFunctionController : ControllerBase
    {
        private readonly ISender _sender;
        public FitnessFunctionController(ISender sender)
        {
            _sender = sender;
        }
        //ContextModel
        // GET: api/<FitnessFunctionController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var fitnessFuncs = await _sender.Send(new GetAllFitnessFunctionsQuerry());
            return Ok(fitnessFuncs);
        }

        // GET api/<FitnessFunctionController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var fitnessFunc = await _sender.Send(new GetFitnessFunctionByIdQuery(id));
            return Ok(fitnessFunc);
        }
    }
}
