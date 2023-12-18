using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeuristicAlgoApp_Backend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ISender _sender;
        public UploadController(ISender sender) =>  _sender = sender;
    

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile file)
        {
            try
            {
                string sciezkaFolderu = Path.Combine(Directory.GetCurrentDirectory(), "Files/Dlls");
                if (!Directory.Exists(sciezkaFolderu))
                {
                    Directory.CreateDirectory(sciezkaFolderu);
                }

                string sciezka = Path.Combine("Files/Dlls", file.FileName);

                using (var strumien = new FileStream(sciezka, FileMode.Create))
                {
                    file.CopyTo(strumien);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            return Ok($"File uploaded successfully: {file.FileName}");
            //make checks for getting the Types of Algos and FitFunctions
        }
    }
}
