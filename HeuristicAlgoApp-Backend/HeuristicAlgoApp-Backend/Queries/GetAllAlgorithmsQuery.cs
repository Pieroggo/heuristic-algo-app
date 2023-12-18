using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Queries
{
    public record GetAllAlgorithmsQuery: IRequest<IEnumerable<Algorithm>>;
}
