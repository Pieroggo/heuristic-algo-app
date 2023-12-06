namespace HeuristicAlgoApp_Backend.IModels
{
    public interface IOptimizationAlgorithm
    {
        public string Name { get; set; }
        public double Solve(double[] x);

    }
}
