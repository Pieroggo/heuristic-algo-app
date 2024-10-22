using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Queries;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class GetFitnessFunctionByIdHandler : IRequestHandler<GetFitnessFunctionByIdQuery,FitnessFunction>
    {
        private readonly DataCollection _dataCollection;

        public GetFitnessFunctionByIdHandler(DataCollection dataCollection)
        {
            _dataCollection = dataCollection;
        }
        public async Task<FitnessFunction> Handle(GetFitnessFunctionByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataCollection.GetFitnessFunctionById(request.id);
        }
    }
}
