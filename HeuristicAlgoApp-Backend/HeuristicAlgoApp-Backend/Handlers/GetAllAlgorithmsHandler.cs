using HeuristicAlgoApp_Backend.Models;
using HeuristicAlgoApp_Backend.Queries;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class GetAllAlgorithmsHandler : IRequestHandler<GetAllAlgorithmsQuery, IEnumerable<Algorithm>>
    {
        private readonly DataCollection dataCollection;

        public GetAllAlgorithmsHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }   

        public async Task<IEnumerable<Algorithm>> Handle(GetAllAlgorithmsQuery request, CancellationToken cancellationToken)
        {
            return await dataCollection.GetAllAlgorithms();
        }
    }
}
