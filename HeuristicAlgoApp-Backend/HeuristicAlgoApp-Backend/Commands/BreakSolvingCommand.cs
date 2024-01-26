using MediatR;
using HeuristicAlgoApp_Backend.Models;
namespace HeuristicAlgoApp_Backend.Commands
{
    public record BreakSolvingCommand() : IRequest<AlgoStateDTO>;
    
}

