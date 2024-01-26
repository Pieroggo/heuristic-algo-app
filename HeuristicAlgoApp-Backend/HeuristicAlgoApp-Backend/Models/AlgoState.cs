namespace HeuristicAlgoApp_Backend.Models
{
    public class AlgoState
    {
        public int I { get; set; }
        public int It { get; set; }
        public int N { get; set; }
        public double[] Lb { get; set; }
        public double[] Ub { get; set; }
        public int Dim { get; set; }
        public double[] ParameterValues { get; set; }
        public double[,] Agents { get; set; }
        public double[] FResults { get; set; }

        // Konstruktor klasy
        public AlgoState(int i, int it, int n, double[] lb, double[] ub, int dim, double[] parameterValues, double[,] agents, double[] fResults)
        {
            I = i;
            It = it;
            N = n;
            Lb = lb;
            Ub = ub;
            Dim = dim;
            ParameterValues = parameterValues;
            Agents = agents;
            FResults = fResults;
        }
    }
}
