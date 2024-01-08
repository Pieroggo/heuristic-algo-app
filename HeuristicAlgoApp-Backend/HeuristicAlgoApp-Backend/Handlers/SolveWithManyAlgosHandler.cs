using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithManyAlgosHandler : IRequestHandler<SolveWithManyAlgosCommand, double[]?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithManyAlgosHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<double[]?> Handle(SolveWithManyAlgosCommand request, CancellationToken cancellationToken)
        {
<<<<<<< Updated upstream
            return new double[] {21.43}; //to be implemented
=======
            return new double[] { }; //to be implemented
>>>>>>> Stashed changes
        }
    }
}
