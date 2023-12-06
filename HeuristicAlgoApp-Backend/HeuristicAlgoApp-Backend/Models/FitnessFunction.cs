using HeuristicAlgoApp_Backend.IModels;

namespace HeuristicAlgoApp_Backend.Models
{
    public class FitnessFunction : IFitnessFunction
    {
        public FitnessFunction() { this.Name = "Nameless Fitness Function"; }
        public string Name { get; set; }
        public double CalculateFitness(double[] position)
        {
            Console.WriteLine("Executed CalculateFitness function");
            return -1.0;
        }
    }
}
