using HeuristicAlgoApp_Backend.Repositories;

namespace HeuristicAlgoApp_Backend.Services
{
    public class AlgorithmService
    {
        private readonly AlgorithmRepository algorithmRepository;
        public AlgorithmService(AlgorithmRepository algorithmRepository) {
            this.algorithmRepository=algorithmRepository;
        }
    }
}
