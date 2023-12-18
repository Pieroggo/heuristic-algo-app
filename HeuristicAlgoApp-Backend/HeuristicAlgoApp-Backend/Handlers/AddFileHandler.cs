using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class AddFileHandler : IRequestHandler<AddFileCommand>
    {
        private readonly DataCollection dataCollection;

        public AddFileHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task Handle(AddFileCommand request, CancellationToken cancellationToken)
        {
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Files/Dlls");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string path = Path.Combine("Files/Dlls", request.file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                request.file.CopyTo(stream);
            }
            await ReflectionExtractionService.ExtractAlgosAndFunctions(this.dataCollection,path);
        }
    }
}
