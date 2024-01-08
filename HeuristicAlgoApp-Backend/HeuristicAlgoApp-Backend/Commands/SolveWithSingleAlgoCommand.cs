using MediatR;

namespace HeuristicAlgoApp_Backend.Commands
{
    public record SolveWithSingleAlgoCommand(int algoId,int[] fitFuncIds, double[] parameters) : IRequest<double?[]?>;

}
