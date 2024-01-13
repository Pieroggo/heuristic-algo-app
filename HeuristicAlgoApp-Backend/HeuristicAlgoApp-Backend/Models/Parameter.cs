using System;

namespace HeuristicAlgoApp_Backend.Models
{
    public class Parameter
    {
        public static int UUID = 0;
        public int Id {get;set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public double UpperBoundary { get; set; }
        public double LowerBoundary { get; set; }
        public Parameter() {
            GenerateId();

        }
        public void GenerateId()
        {
            Id = Interlocked.Increment(ref UUID);
        }
    }
}
