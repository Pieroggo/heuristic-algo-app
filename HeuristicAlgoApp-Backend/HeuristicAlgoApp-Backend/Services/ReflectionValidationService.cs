namespace HeuristicAlgoApp_Backend.Services
{
    public class ReflectionValidationService
    {
        private readonly string[] propertiesNeededInAlgorithm = new string[] { "Name" };
        private readonly string[] methodsNeededInAlgorithm = new string[] { "Solve" };
        public static bool IsCorrectAlgorithm(Type checkedType)
        {
            Console.WriteLine("Executed IsCorrectAlgorithm function");
            return false;
        }
        public static bool IsCorrectFitnessFunction(Type checkedType) {
            Console.WriteLine("Executed IsCorrectFitnessFunction function");
            return false;
        }
    }
}
