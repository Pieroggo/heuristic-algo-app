using HeuristicAlgoApp_Backend.Models;
using MediatR;
namespace HeuristicAlgoApp_Backend.Queries
{
    public record GetAllFitnessFunctionsQuery : IRequest<IEnumerable<FitnessFunction>>;
}
