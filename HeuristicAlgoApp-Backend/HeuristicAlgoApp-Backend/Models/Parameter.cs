namespace HeuristicAlgoApp_Backend.Models
{
    public class Parameter
    {
        public int Id {get;set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public double UpperBoundary { get; set; }
        public double LowerBoundary { get; set; }
    }
}
