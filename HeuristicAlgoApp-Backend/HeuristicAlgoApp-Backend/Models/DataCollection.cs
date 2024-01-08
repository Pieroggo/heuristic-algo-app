using System.Data.Entity;
using System.Security.Cryptography.Xml;

namespace HeuristicAlgoApp_Backend.Models
{
    public class DataCollection
    {
        List<Algorithm> algorithms { get; set; }
        List<FitnessFunction> fitnessFunctions { get; set; }

        dynamic? solvingSingleAlgo { get; set; }
        dynamic? solvingMultiAlgo { get; set; }
        public DataCollection() {
            algorithms = new List<Algorithm>();
            fitnessFunctions = new List<FitnessFunction>();
            algorithms.Add(new Algorithm(){Name="Sample Algo",TypeName="Sample Algo Type", FileName="Sample Algo File", Parameters=new List<Parameter>() });
            algorithms.Add(new Algorithm() {Name = "Sample Algo 2", TypeName = "Sample Algo 2 Type", FileName = "Sample Algo 2 File", Parameters = new List<Parameter>() });
            fitnessFunctions.Add(new FitnessFunction() { Name = "Fitness Function", TypeName = "Fitness Function Type", FileName = "Fitness Function File", Dimension = -1, LowerBoundaries=new double[] {-5.12 },UpperBoundaries=new double[] {5.12 } });
            fitnessFunctions.Add(new FitnessFunction() { Name = "Fitness Function 2", TypeName = "Fitness Function 2 Type", FileName = "Fitness Function 2 File", Dimension = -1, LowerBoundaries = new double[] {}, UpperBoundaries = new double[] { } });
            fitnessFunctions.Add(new FitnessFunction() { Name = "Fitness Function 2D", TypeName = "Fitness Function 2D Type", FileName = "Fitness Function 2D File", Dimension = 2, LowerBoundaries = new double[] { -10,-5 }, UpperBoundaries = new double[] { 10,5 } });
            solvingSingleAlgo = null;
            solvingMultiAlgo = null;
        }
        public DataCollection(List<Algorithm> algorithms, List<FitnessFunction> fitnessFunctions, List<Parameter> parameters)
        {
            this.algorithms = algorithms;
            this.fitnessFunctions = fitnessFunctions;
        }

        public async Task AddAlgorithm(Algorithm algorithm) {
            algorithms.Add(algorithm);
            await Task.CompletedTask;
        }
        public async Task AddFitnessFunction(FitnessFunction fitnessFunction)
        {
            fitnessFunctions.Add(fitnessFunction);
            await Task.CompletedTask;
        }
        public async Task AssignReferenceSingleAlgo(dynamic algo) {
            solvingSingleAlgo = algo;
            await Task.CompletedTask;
        }
        public async Task AssignReferenceMultiAlgo(dynamic algo)
        {
            solvingMultiAlgo = algo;
            await Task.CompletedTask;
        }
        public async Task<List<Algorithm>> GetAllAlgorithms() => await Task.FromResult(algorithms);
        public async Task<List<FitnessFunction>> GetAllFitnessFunctions() => await Task.FromResult(fitnessFunctions);
        public async Task<Algorithm> GetAlgorithmById(int id) => await Task.FromResult(algorithms.Single(a => a.Id == id));
        public async Task<FitnessFunction> GetFitnessFunctionById(int id) => await Task.FromResult(fitnessFunctions.Single(f => f.Id == id));
        public async Task<string> GetSolvingSingleAlgoName() => await Task.FromResult(solvingSingleAlgo!=null ? solvingSingleAlgo.GetType().Name: null);
        public async Task<string> GetSolvingMultiAlgoName() => await Task.FromResult(solvingMultiAlgo != null ? solvingMultiAlgo.GetType().Name : null);
    }
}
