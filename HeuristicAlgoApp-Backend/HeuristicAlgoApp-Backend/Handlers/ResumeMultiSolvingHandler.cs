using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class ResumeMultiSolvingHandler : IRequestHandler<ResumeMultiSolvingCommand>
    {
        private readonly DataCollection dataCollection;

        public ResumeMultiSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task Handle(ResumeMultiSolvingCommand request, CancellationToken cancellationToken)
        {
            await dataCollection.ResumeMultiTask();
            await Task.CompletedTask;
        }
    }
}
