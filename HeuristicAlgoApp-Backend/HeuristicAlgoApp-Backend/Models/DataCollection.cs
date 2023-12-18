using System.Data.Entity;

namespace HeuristicAlgoApp_Backend.Models
{
    public class DataCollection
    {
        IEnumerable<Algorithm> algorithms { get; set; }
        IEnumerable<FitnessFunction> fitnessFunctions { get; set; }
        IEnumerable<Parameter> parameters {get; set;}

    }
}
