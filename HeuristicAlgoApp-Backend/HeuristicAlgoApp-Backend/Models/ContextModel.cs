using System.Data.Entity;

namespace HeuristicAlgoApp_Backend.Models
{
    public class ContextModel:DbContext
    {
        DbSet<Algorithm> algorithms { get; set; }
        DbSet<FitnessFunction> fitnessFunctions { get; set; }

    }
}
