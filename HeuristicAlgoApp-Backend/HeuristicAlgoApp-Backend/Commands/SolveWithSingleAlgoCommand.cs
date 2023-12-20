using MediatR;

namespace HeuristicAlgoApp_Backend.Commands
{
    public record SolveWithSingleAlgoCommand(int algoId,int fitFuncId, double[] parameters):IRequest<double?>;

}
