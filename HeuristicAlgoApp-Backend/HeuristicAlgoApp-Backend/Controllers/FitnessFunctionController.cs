using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FitnessFunctionController : ControllerBase
    {
        //ContextModel
        // GET: api/<FitnessFunctionController>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "function1", "function2", "function3", "function4", "function5" };
        }

        // GET api/<FitnessFunctionController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }
    }
}
