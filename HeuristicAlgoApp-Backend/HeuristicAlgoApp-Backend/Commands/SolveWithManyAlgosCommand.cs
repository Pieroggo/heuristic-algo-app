using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Commands
{
    public record SolveWithManyAlgosCommand(MultiTaskDTO multiTask) : IRequest<double?[]?>
    {
    }
}
