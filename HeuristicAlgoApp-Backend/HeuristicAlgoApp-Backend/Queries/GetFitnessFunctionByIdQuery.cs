using HeuristicAlgoApp_Backend.Models;
using MediatR;
namespace HeuristicAlgoApp_Backend.Queries
{
    public record GetFitnessFunctionByIdQuery(int id) : IRequest<FitnessFunction>;
}
