using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Queries;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class GetAllFitnessFunctionsHandler : IRequestHandler<GetAllFitnessFunctionsQuerry,IEnumerable<FitnessFunction>>
    {
        private readonly DataCollection _dataCollection;

        public GetAllFitnessFunctionsHandler(DataCollection dataCollection)
        {
            _dataCollection = dataCollection;
        }
        public async Task<IEnumerable<FitnessFunction>> Handle(GetAllFitnessFunctionsQuerry request, CancellationToken cancellationToken)
        {
            return await _dataCollection.GetAllFitnessFunctions();
        }
    }
}
