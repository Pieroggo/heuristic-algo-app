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
                            string reportFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\";
                            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\";
                            List<double> up = new List<double> { };
                            List<double> jump = new List<double> { };
                            List<double> solutions = new List<double> { };
                            List<string> report = new List<string> { };
                            if (algorithmDTO.Parameters.Count != 0)
                            {
                                foreach (dynamic algoParameter in algorithmDTO.Parameters)
                                {
                                    doubleParams.Add(algoParameter.LowerBoundary);
                                    up.Add(algoParameter.UpperBoundary);
                                    jump.Add(algoParameter.IterationInterval);
                                }
                                for (int p = 0; p < algorithmDTO.Parameters.Count; p++)
                                {
                                    double q = doubleParams[p + 3];
                                    while (q <= up[p])
                                    {
                                        solveParams = new List<dynamic> { fitnessFunction, request.multiTask.FitFuncLowerBoundaries, request.multiTask.FitFuncUpperBoundaries };
                                        doubleParams[p + 3] = q;
                                        solveParams.Add(doubleParams.ToArray());
                                        solveParams.Add(reportFolderPath);
                                        solveParams.Add(stateFolderPath);
                                        solveParams.Add(dataCollection.ctsSingle.Token);
                                        await dataCollection.AssignReferenceMultiAlgo(algorithm);
                                        List<dynamic> res1 = algorithm.GetType().GetMethod("Solve").Invoke(algorithm, solveParams.ToArray());
                                        solutions.Add(res1[0]);
                                        report.Add(res1[1]);
                                        q += jump[p];
                                    }
                                }
                            }
                            else
                            {
                                solveParams.Add(doubleParams.ToArray());
                                solveParams.Add(reportFolderPath);
                                solveParams.Add(stateFolderPath);
                                solveParams.Add(dataCollection.ctsSingle.Token);
                                await dataCollection.AssignReferenceMultiAlgo(algorithm);
                                List<dynamic> result = algorithm.GetType().GetMethod("Solve").Invoke(algorithm, solveParams.ToArray());
                                report.Add(result[1]);
                                solutions.Add(result[0]);
                            }
                            for(int z = 0; z < solutions.Count; z++)
                            {
                                Console.WriteLine("solutions:" + solutions[z]);
                            }
                            int index = solutions.IndexOf(solutions.Min());
                            Console.WriteLine(index);
                            string frontReportPath = ReportFrontFolderPath + Path.GetFileName(report[index]);
                            if (report[index] != null) { 
                                Console.WriteLine($"Solve on algorithm worked.");
                                File.Copy(report[index], ReportFrontFolderPath + Path.GetFileName(report[index]));
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
