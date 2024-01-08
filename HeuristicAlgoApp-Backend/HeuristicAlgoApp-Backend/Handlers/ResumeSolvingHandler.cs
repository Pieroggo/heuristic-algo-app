﻿using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class ResumeSolvingHandler : IRequestHandler<ResumeSolvingCommand>
    {
        private readonly DataCollection _dataCollection;

        public ResumeSolvingHandler(DataCollection dataCollection)
        {
            _dataCollection = dataCollection;
        }

        public Task Handle(ResumeSolvingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
