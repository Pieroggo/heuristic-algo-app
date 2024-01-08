using System.Reflection;

namespace HeuristicAlgoApp_Backend.Services
{
    public class ReflectionValidationService
    {
        private readonly static string[] propertiesNeededInAlgorithm = new string[] { "Name", "ParamsInfo","writer","reader","stringReportGenerator","pdfReportGenerator" }; //maybe later, if necessary, add Cancelation Token field name to this list
        //private readonly static string[] classPropertiesNeededInAlgorithm = new string[] {  }; //optional to check if the properties have correct fields
        private readonly static string[] methodsNeededInAlgorithm = new string[] { "Solve" };
        
        public static bool CheckAssemblyPath(string fPath)
        {
            bool isPathOk = true;
            try
            {
                Assembly algoAssembly = Assembly.LoadFile(fPath);
            }
            catch (System.ArgumentException e)
            {
                Console.WriteLine(e.ToString());
                isPathOk = false;
            }
            return isPathOk;

        }
        public static bool IsCorrectAlgorithm(Type checkedType)
        {
                    bool isOk = true;
                    foreach (string fieldName in propertiesNeededInAlgorithm)
                    {
                        PropertyInfo propertyInfo = checkedType.GetProperty(fieldName);
                        if (propertyInfo == null)
                        {
                            isOk = false;
                        }
                    }
                    foreach (string methodName in methodsNeededInAlgorithm)
                    {
                        MethodInfo methodInfo = checkedType.GetMethod(methodName);
                        if (methodInfo == null)
                        {
                            isOk = false;
                        }
                    }
                    return isOk;
                }
        public static bool IsCorrectFitnessFunction(Type checkedType) {
            
            return checkedType.GetMethod("CalculateFitness")!=null;
        }
    }
}
