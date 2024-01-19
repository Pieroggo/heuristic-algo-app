using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Commands
{
    public record SolveWithSingleAlgoCommand(SingleTaskDTO singleTask) : IRequest<string?[]>;

}
