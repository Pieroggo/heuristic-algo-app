﻿using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class BreakSolvingHandler : IRequestHandler<BreakSolvingCommand>
    {
        private readonly DataCollection dataCollection;

        public BreakSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public Task Handle(BreakSolvingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}