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
        public IActionResult Add([FromBody] IFormFile file)
        {
            {
                if (file != null && file.Length > 0)
                {
                    //// Pobierz nazwę pliku
                    //string fileName = Path.GetFileName(file.FileName);

                    //// Ustaw ścieżkę docelową na serwerze
                    //string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileName);

                    //// Zapisz plik na serwerze
                    //using (var stream = new FileStream(uploadPath, FileMode.Create))
                    //{
                    //    file.CopyTo(stream);
                    //}

                    // Możesz wykonać dodatkowe operacje lub zapisać informacje o pliku w bazie danych

                    return Ok($"File uploaded successfully: {file.Name}");
                }

                return BadRequest("No file selected or file is empty");
            }
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
