using HeuristicAlgoApp_Backend.IModels;
namespace HeuristicAlgoApp_Backend.Models
{
    public class Algorithm:IOptimizationAlgorithm
    {
        public Algorithm() {
            this.Name = "Nameless Algorithm";
        }

        public Algorithm(string name) {
            this.Name = name;
        }

        public string Name { get; set; }

        public double Solve(double[] x)
        {
            Console.WriteLine("Executed Solve function");
            return -1.0;
        }
    }
}
