﻿using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithSingleAlgoHandler : IRequestHandler<SolveWithSingleAlgoCommand, string?[]>
    {
        private readonly DataCollection dataCollection;

        private readonly string ReportFrontFolderPath=Directory.GetCurrentDirectory() + "\\..\\..\\HeuristicAlgoApp-Frontend\\system-frontend\\public\\pdf\\";
        public SolveWithSingleAlgoHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<string?[]> Handle(SolveWithSingleAlgoCommand request, CancellationToken cancellationToken)
        {
            //need to get rid of the State Directory here
            Console.WriteLine("Handler Beginning");
            List<string?> reports = new List<string?>();
            Algorithm algorithmDTO = await dataCollection.GetAlgorithmById(request.singleTask.AlgoId);
            try
            {
                Assembly algoAssembly = Assembly.LoadFile(algorithmDTO.FileName);
                
                dynamic algorithm = Activator.CreateInstance(algoAssembly.GetType(algorithmDTO.TypeName));
                Console.WriteLine($"Algorithm of type {algorithmDTO.TypeName} created.");
                //fitFunc, lb, ub, parameters
                if (algorithm != null)
                {
                    int i = 0;
                    foreach (int fitFuncId in request.singleTask.FitFuncIds) { 
                        FitnessFunction fitnessFunctionDTO = await dataCollection.GetFitnessFunctionById(fitFuncId);
                        Assembly fitFuncAssembly = Assembly.LoadFile(fitnessFunctionDTO.FileName);
                        dynamic fitnessFunction = Activator.CreateInstance(fitFuncAssembly.GetType(fitnessFunctionDTO.TypeName));
                        Console.WriteLine($"Function of type {fitnessFunctionDTO.TypeName} created.");
                        if (fitnessFunction != null)
                        {

                            List<dynamic> solveParams = new List<dynamic> { fitnessFunction, request.singleTask.FitFuncLowerBoundaries[i], request.singleTask.FitFuncUpperBoundaries[i] }; //adjust so that you can use solve
                            List<double> doubleParams = new List<double> { request.singleTask.NumOfAgents, request.singleTask.NumOfIterations, request.singleTask.FitFuncDimensions[i] };//list without additional parameters
                            if (request.singleTask.AlgoParameters != null)
                            {
                                foreach (double algoParameter in request.singleTask.AlgoParameters)
                                {
                                    doubleParams.Add(algoParameter);
                                }
                            }
                            solveParams.Add(doubleParams.ToArray());
                            string reportFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\";
                            solveParams.Add(reportFolderPath);
                            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\SingleAlgo\\";
                            solveParams.Add(stateFolderPath);
                            solveParams.Add(dataCollection.ctsSingle.Token);
                            await dataCollection.AssignReferenceSingleAlgo(algorithm);
                            List<dynamic> solveResults=new List<dynamic>();
                            bool isCompleted = false;
                            while (!isCompleted)
                            {
                                solveResults = algorithm.GetType().GetMethod("Solve").Invoke(algorithm, solveParams.ToArray());
                                if (solveResults[1] == null)
                                {
                                    //break was activated
                                    while (dataCollection.ctsSingle.IsCancellationRequested)
                                    {
                                        Console.WriteLine("Algorithm was stopped.");
                                        Thread.Sleep(1000);
                                    }
                                    solveParams.RemoveAt(solveParams.Count - 1);
                                    solveParams.Add(dataCollection.ctsSingle.Token);
                                }
                                else { isCompleted = true; }
                            }
                            Console.WriteLine(solveResults[0]);
                            string reportPath= solveResults[1];
                            string frontReportPath = ReportFrontFolderPath + Path.GetFileName(reportPath);
                            if (reportPath != null) { 
                                Console.WriteLine($"Solve on algorithm worked.");

                                File.Copy(reportPath, ReportFrontFolderPath + Path.GetFileName(reportPath));
                            }
                            //reports.Add(frontReportPath);
                            reports.Add(Path.GetFileName(frontReportPath));
                            await dataCollection.AssignReferenceSingleAlgo(null); //reset of reference
                            System.IO.DirectoryInfo di = new DirectoryInfo(stateFolderPath);
                            if(di.Exists&&di.GetFiles().Length>0)
                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }
                        }
                        else {
                            reports.Add(null);
                        }
                        i++;
                    }
                    return reports.ToArray();
                }
                else { return null; }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); if (ex.InnerException != null) { Console.WriteLine(ex.InnerException.ToString()); } return null; }
        }
    }
}
