using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Queries
{
    public record GetAlgorithmByIdQuery(int id): IRequest<Algorithm>;
    
}
