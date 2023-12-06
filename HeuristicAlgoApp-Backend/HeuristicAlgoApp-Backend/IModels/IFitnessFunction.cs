namespace HeuristicAlgoApp_Backend.IModels
{
    public interface IFitnessFunction
    {
        double CalculateFitness(double[] position);
    }
}
