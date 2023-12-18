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
            //make file here
            ReflectionExtractionService.ExtractAlgosAndFunctions(this.dataCollection,request.file.FileName);// change file.FileName for the path to file
        }
    }
}
