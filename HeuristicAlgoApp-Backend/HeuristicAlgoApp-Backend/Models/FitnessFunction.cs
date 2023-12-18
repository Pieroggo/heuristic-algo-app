using HeuristicAlgoApp_Backend.IModels;

namespace HeuristicAlgoApp_Backend.Models
{
    public class FitnessFunction
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string FileName { get; set; }
        public int Dimension { get; set; } //if infinite, set to -1
        public double[,] Domain { get; set; }
    }
}
