using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Queries;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class GetAlgorithmByIdHandler : IRequestHandler<GetAlgorithmByIdQuery, Algorithm>
    {
        private readonly DataCollection dataCollection;

        public GetAlgorithmByIdHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<Algorithm> Handle(GetAlgorithmByIdQuery request, CancellationToken cancellationToken)
        {
            return await dataCollection.GetAlgorithmById(request.id);
            
        }
    }
}
