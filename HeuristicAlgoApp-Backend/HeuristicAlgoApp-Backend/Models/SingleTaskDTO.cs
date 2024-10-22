namespace HeuristicAlgoApp_Backend.Models
{
    public class SingleTaskDTO
    {
        public int AlgoId { get; set; }
        public int[]? FitFuncIds { get; set; }
        public int NumOfAgents { get; set; }
        public int NumOfIterations { get; set; }
        public double?[]? AlgoParameters { get; set; }// not N and not I
        public int[]? FitFuncDimensions { get; set; }
        public double[][] FitFuncLowerBoundaries { get; set; }
        public double[][] FitFuncUpperBoundaries { get; set; }
    }
}
