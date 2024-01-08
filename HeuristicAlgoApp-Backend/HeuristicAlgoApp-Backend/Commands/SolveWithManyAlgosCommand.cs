using MediatR;

namespace HeuristicAlgoApp_Backend.Commands
{
    public record SolveWithManyAlgosCommand(int[] algoIds, int fitFuncId) : IRequest<double[]?>
    {
    }
}
