using HeuristicAlgoApp_Backend.Models;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Services
{
    public class ReflectionExtractionService
    {
        public async static Task ExtractAlgosAndFunctions(DataCollection dataCollection, string fPath)
        {

            if (ReflectionValidationService.CheckAssemblyPath(fPath))
            {
                Assembly algoAssembly = Assembly.LoadFile(fPath);
                Type[] typesFromFile = algoAssembly.GetTypes(); //<- all types in dll
                List<Type> algoTypes = new List<Type>();//<- types that have necessary fields
                foreach (Type t in typesFromFile)
                {
                    if (ReflectionValidationService.IsCorrectAlgorithm(t))
                    {
                        dynamic algo=Activator.CreateInstance(t);
                        await dataCollection.AddAlgorithm(new Algorithm() { Name = t.GetProperty("Name").GetValue(algo),TypeName=t.Name,FileName=fPath });//for now, without Parameters
                    }
                    if (ReflectionValidationService.IsCorrectFitnessFunction(t)) {
                        //dynamic fitFunc=Activator.CreateInstance(t) //może być potrzebny przy założeniu składowej Name
                        await dataCollection.AddFitnessFunction(new FitnessFunction() {Name=t.Name,TypeName=t.Name,FileName=fPath }); //Name, Dimension i Domain będzie trzeba dorobić po naradzie

                    }
                }
                
            }

            // zmień dodawanie FitFunction - dodaj IsInfiniteDim

        }
    }
}
