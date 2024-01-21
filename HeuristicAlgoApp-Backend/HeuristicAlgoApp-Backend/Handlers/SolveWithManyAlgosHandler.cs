using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithManyAlgosHandler : IRequestHandler<SolveWithManyAlgosCommand, string?[]?>
    {
        private readonly DataCollection dataCollection;
        private readonly string ReportFrontFolderPath = Directory.GetCurrentDirectory() + "\\..\\..\\HeuristicAlgoApp-Frontend\\system-frontend\\public\\pdf\\";

        public SolveWithManyAlgosHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<string?[]?> Handle(SolveWithManyAlgosCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Handler Beginning");
            List<string?> reports = new List<string?>(); 
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
                            if (algorithmDTO.Parameters != null)
                            {
                                foreach (dynamic algoParameter in algorithmDTO.Parameters)
                                {
                                    doubleParams.Add((algoParameter.UpperBoundary + algoParameter.LowerBoundary) /2);
                                }
                            }
                            solveParams.Add(doubleParams.ToArray());
                            string reportFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\";
                            solveParams.Add(reportFolderPath);
                            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\";
                            solveParams.Add(stateFolderPath);
                            await dataCollection.AssignReferenceMultiAlgo(algorithm);
                            Console.WriteLine(algorithm);
                            Console.WriteLine(solveParams.ToArray());
                            List<dynamic> result = algorithm.GetType().GetMethod("Solve").Invoke(algorithm, solveParams.ToArray());
                            string? reportPath = result[1];
                            Console.WriteLine(result[0]);
                            string frontReportPath = ReportFrontFolderPath + Path.GetFileName(reportPath);
                            if (reportPath != null) { 
                                Console.WriteLine($"Solve on algorithm worked.");
                                File.Copy(reportPath, ReportFrontFolderPath + Path.GetFileName(reportPath));
                            }
                            //reports.Add(frontReportPath);
                            reports.Add(Path.GetFileName(frontReportPath));
                            await dataCollection.AssignReferenceMultiAlgo(null); //reset of reference
                        }
                        else
                        {
                            reports.Add(null);
                        }
                        i++;
                    }
                    
                    return reports.ToArray();
                }
                else { return null; }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); if (ex.InnerException != null) { Console.WriteLine(ex.InnerException.ToString()); }
                                                                     return null; }
        }
    }
}
