namespace HeuristicAlgoApp_Backend.Models
{
    public class MultiTaskDTO
    {
        public int[]? AlgoIds { get; set; }
        public int FitFuncId { get; set; }
        public int FitFuncDimension { get; set; }
        public double?[]? FitFuncLowerBoundaries { get; set; }
        public double?[]? FitFuncUpperBoundaries { get; set; }
    }
}
