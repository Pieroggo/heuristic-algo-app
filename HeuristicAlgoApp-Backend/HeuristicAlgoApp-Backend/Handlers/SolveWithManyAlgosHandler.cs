using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithManyAlgosHandler : IRequestHandler<SolveWithManyAlgosCommand, double?[]?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithManyAlgosHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<double?[]?> Handle(SolveWithManyAlgosCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handler Beginning");
            List<double?> results = new List<double?>(); 
            try
            {
                Console.WriteLine(request.multiTask.FitFuncId);
                FitnessFunction fitnessFunctionDTO = await dataCollection.GetFitnessFunctionById(request.multiTask.FitFuncId);
                Assembly fitFuncAssembly = Assembly.LoadFile(fitnessFunctionDTO.FileName);
                dynamic fitnessFunction = Activator.CreateInstance(fitFuncAssembly.GetType(fitnessFunctionDTO.TypeName));
                Console.WriteLine($"Function of type {fitnessFunctionDTO.TypeName} created.");
                //fitFunc, lb, ub, parameters
                if (fitnessFunction != null)
                {
                    int i = 0;
                    foreach (int algoId in request.multiTask.AlgoIds)
                    {
                        Algorithm algorithmDTO = await dataCollection.GetAlgorithmById(algoId);
                        Assembly algoAssembly = Assembly.LoadFile(algorithmDTO.FileName);
                        dynamic algorithm = Activator.CreateInstance(algoAssembly.GetType(algorithmDTO.TypeName));
                        Console.WriteLine($"Algorithm of type {algorithmDTO.TypeName} created.");
                        if (algorithm != null)
                        {

                            List<dynamic> solveParams = new List<dynamic> { fitnessFunction, request.multiTask.FitFuncLowerBoundaries, request.multiTask.FitFuncUpperBoundaries }; //adjust so that you can use solve
                            List<double> doubleParams = new List<double> { request.multiTask.NumOfAgents, request.multiTask.NumOfIterations, request.multiTask.FitFuncDimension };//list without additional parameters
                            
                            solveParams.Add(doubleParams.ToArray());
                            await dataCollection.AssignReferenceMultiAlgo(algorithm);
                            Console.WriteLine(algorithm.ToString());
                            double result =algorithm.GetType().GetMethod("Solve").Invoke(algorithm, solveParams.ToArray());
                            if (result != null) { Console.WriteLine($"Solve on algorithm worked."); }
                            results.Add(result);
                            await dataCollection.AssignReferenceMultiAlgo(null); //reset of reference
                        }
                        else
                        {
                            results.Add(null);
                        }
                        i++;
                    }
                    
                    return results.ToArray();
                }
                else { return null; }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); if (ex.InnerException != null) { Console.WriteLine(ex.InnerException.ToString()); }
                                                                     return null; }
        }
    }
}
