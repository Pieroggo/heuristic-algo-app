using HeuristicAlgoApp_Backend.IModels;
using System;

namespace HeuristicAlgoApp_Backend.Models
{
    public class FitnessFunction
    {
        public static int UUID = 0;
        public int Id {get;set;}
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string FileName { get; set; }
        public bool IsDimensionInfinite { get; set; }
        public int Dimension { get; set; } //if infinite, set to -1
        public double[] LowerBoundaries { get; set; }
        public double[] UpperBoundaries { get; set; }
        public FitnessFunction() { 
            GenerateId();
            IsDimensionInfinite = true;
            Dimension = 2;
            LowerBoundaries = new double[] { -1, -1 };
            UpperBoundaries = new double[] { 1, 1 };
        }
        public void GenerateId()
        {
            Id = Interlocked.Increment(ref UUID);
        }
    }
}
