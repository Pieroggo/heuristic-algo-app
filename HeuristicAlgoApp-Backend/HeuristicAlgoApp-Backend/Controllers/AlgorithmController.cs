using Microsoft.AspNetCore.Mvc;
using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Repositories;
using HeuristicAlgoApp_Backend.Services;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;
using System.Web;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlgorithmController : ControllerBase
    {
        //ContextModel
        private readonly AlgorithmRepository? algorithmRepository;
        private readonly AlgorithmService? algorithmService;


        public AlgorithmController() {
            this.algorithmRepository = new AlgorithmRepository();
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "algorithm1", "algorithm2", "algorithm3" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Add(IFormFile file)
        {
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
