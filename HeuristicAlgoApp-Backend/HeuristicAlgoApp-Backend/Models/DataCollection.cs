using System.Data.Entity;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

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

            algorithms.Add(new Algorithm(){
                Name = "Sample Algo",
                TypeName = "Sample Algo Type", 
                FileName = "Sample Algo File", 
                Parameters = new List<Parameter>(){
                    new Parameter {
                        Name = "Leaders",
                        Description = "Ilość salpów, za którymi podąża reszta",
                        LowerBoundary = 1,
                        UpperBoundary = 100
                    }
                }
            });
            algorithms.Add(new Algorithm() {
                Name = "Sample Extended Algorithm", 
                TypeName = "Sample Extended Algorithm Type", 
                FileName = "Sample Extended Algorithm File", 
                Parameters = new List<Parameter>() {
                    new Parameter { 
                        Name = "ParametrX",
                        Description = "Domyśl się, jakiś X",
                        LowerBoundary = -1, 
                        UpperBoundary = 1 
                    }, 
                    new Parameter { 
                        Name = "ParametrY",
                        Description = "Liczba odpowiadająca dniu Twoich urodzin w roku",
                        LowerBoundary = 0, 
                        UpperBoundary = 366 
                    },
                    new Parameter {
                        Name = "ParametrZ",
                        Description = "Wpisz ile możesz",
                        LowerBoundary = -17,
                        UpperBoundary = 999999
                    }
                } 
            });
            algorithms.Add(new Algorithm()
            {
                Name = "Super Simple Algo",
                TypeName = "Super Simple Algo Type",
                FileName = "Super Simple Algo File",
                Parameters = new List<Parameter>() {
                
                }
            });

            fitnessFunctions.Add(new FitnessFunction() { 
                Name = "Fitness Function", 
                TypeName = "Fitness Function Type", 
                FileName = "Fitness Function File" 
            });
            fitnessFunctions.Add(new FitnessFunction() { 
                Name = "Function 2Dim", 
                TypeName = "Function 2Dim Type", 
                FileName = "Function 2Dim File",
                IsDimensionInfinite = false,
                Dimension = 2
        });
            fitnessFunctions.Add(new FitnessFunction() { 
                Name = "Poczwórna Funkcja Higsa",
                TypeName = "Poczwórna Funkcja Higsa Type", 
                FileName = "Poczwórna Funkcja Higsa File",
                IsDimensionInfinite = false,
                Dimension = 4,
                LowerBoundaries = new double[] { -1, -1, -1, -1 },
                UpperBoundaries = new double[] { 1, 1, 1, 1 }
        });

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
