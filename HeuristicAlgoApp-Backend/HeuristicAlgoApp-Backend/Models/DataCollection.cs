using System.Data.Entity;
using System.Security.Cryptography.Xml;

namespace HeuristicAlgoApp_Backend.Models
{
    public class DataCollection
    {
        List<Algorithm> algorithms { get; set; }
        List<FitnessFunction> fitnessFunctions { get; set; }
        List<Parameter> parameters { get; set; }
        public DataCollection() {
            algorithms = new List<Algorithm>();
            fitnessFunctions = new List<FitnessFunction>();
            parameters = new List<Parameter>();
            List<double[]> d1 = new List<double[]>();
            List<double[]> d2 = new List<double[]>();
            List<double[]> d3 = new List<double[]>();
            d1.Add(new double[] { -5.12, 5.12 });
            d2.Add(new double[] { });
            d3.Add(new double[] { -10, 10 } );
            d3.Add(new double[] { -5, 5 });
            algorithms.Add(new Algorithm(){Name="Sample Algo",TypeName="Sample Algo Type", FileName="Sample Algo File", Parameters=new List<Parameter>() });
            algorithms.Add(new Algorithm() {Name = "Sample Algo 2", TypeName = "Sample Algo 2 Type", FileName = "Sample Algo 2 File", Parameters = new List<Parameter>() });
            fitnessFunctions.Add(new FitnessFunction() { Id = 1, Name = "Fitness Function", TypeName = "Fitness Function Type", FileName = "Fitness Function File", Dimension = -1, Domain = d1 });
            fitnessFunctions.Add(new FitnessFunction() { Id = 2, Name = "Fitness Function 2", TypeName = "Fitness Function 2 Type", FileName = "Fitness Function 2 File", Dimension = -1, Domain = d2 });
            fitnessFunctions.Add(new FitnessFunction() { Id = 3, Name = "Fitness Function 2D", TypeName = "Fitness Function 2D Type", FileName = "Fitness Function 2D File", Dimension = 2, Domain = d3 });
        }
        public DataCollection(List<Algorithm> algorithms, List<FitnessFunction> fitnessFunctions, List<Parameter> parameters)
        {
            this.algorithms = algorithms;
            this.fitnessFunctions = fitnessFunctions;
            this.parameters = parameters;
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
        public async Task AddParameter(Parameter parameter)
        {
            parameters.Add(parameter);
            await Task.CompletedTask;
        }
        public async Task<List<Algorithm>> GetAllAlgorithms() => await Task.FromResult(algorithms);
        public async Task<List<FitnessFunction>> GetAllFitnessFunctions() => await Task.FromResult(fitnessFunctions);
        public async Task<List<Parameter>> GetAllParameters() => await Task.FromResult(parameters);
        public async Task<Algorithm> GetAlgorithmById(int id) => await Task.FromResult(algorithms.Single(a => a.Id == id));
        public async Task<FitnessFunction> GetFitnessFunctionById(int id) => await Task.FromResult(fitnessFunctions.Single(f => f.Id == id));
        public async Task<Parameter> GetParameterById(int id) => await Task.FromResult(parameters.Single(p => p.Id == id));
    }
}
