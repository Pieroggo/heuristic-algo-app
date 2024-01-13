namespace HeuristicAlgoApp_Backend.Models
{
    public class SingleTaskDTO
    {
        public int AlgoId { get; set; }
        public int[]? FitFuncIds { get; set; }
        public double?[]? AlgoParameters { get; set; }//may want to have N and I seperately
        
        public int[]? FitFuncDimensions { get; set; }
        public double?[]?[]? FitFuncLowerBoundaries { get; set; }
        public double?[]?[]? FitFuncUpperBoundaries { get; set; }
    }
}
