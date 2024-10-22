using HeuristicAlgoApp_Backend.Commands;
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
            await _sender.Send(new AddFileCommand(file));
            return Ok();//maybe return info about added types
        }
    }
}
