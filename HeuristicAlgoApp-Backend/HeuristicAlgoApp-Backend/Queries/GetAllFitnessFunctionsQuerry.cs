using HeuristicAlgoApp_Backend.Models;
using MediatR;
namespace HeuristicAlgoApp_Backend.Queries
{
    public record GetAllFitnessFunctionsQuerry : IRequest<IEnumerable<FitnessFunction>>;
}
