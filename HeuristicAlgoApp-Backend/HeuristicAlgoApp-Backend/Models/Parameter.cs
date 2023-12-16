namespace HeuristicAlgoApp_Backend.Models
{
    public class Parameter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double[] Domain { get; set; }
        public int AlgorithmId { get; set; }
    }
}
