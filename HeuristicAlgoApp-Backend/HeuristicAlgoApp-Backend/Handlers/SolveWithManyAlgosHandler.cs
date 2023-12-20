using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithManyAlgosHandler : IRequestHandler<SolveWithManyAlgosCommand,double?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithManyAlgosHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<double?> Handle(SolveWithManyAlgosCommand request, CancellationToken cancellationToken)
        {
            return 21.37 //to be implemented
        }
    }
}
