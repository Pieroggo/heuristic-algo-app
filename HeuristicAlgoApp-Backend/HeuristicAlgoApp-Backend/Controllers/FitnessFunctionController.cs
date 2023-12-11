using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessFunctionController : ControllerBase
    {
        // GET: api/<FitnessFunctionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "function1", "function2", "function3", "function4", "function5" };
        }

        // GET api/<FitnessFunctionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FitnessFunctionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FitnessFunctionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FitnessFunctionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
