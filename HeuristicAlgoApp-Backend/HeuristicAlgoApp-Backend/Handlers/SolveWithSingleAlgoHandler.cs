using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithSingleAlgoHandler : IRequestHandler<SolveWithSingleAlgoCommand,string?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithSingleAlgoHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<string?> Handle(SolveWithSingleAlgoCommand request, CancellationToken cancellationToken)
        {
            Algorithm algorithmDTO = await dataCollection.GetAlgorithmById(request.algoId);
            FitnessFunction fitnessFunctionDTO = await dataCollection.GetFitnessFunctionById(request.fitFuncId);
            Assembly algoAssembly = Assembly.LoadFile(algorithmDTO.FileName);
            Assembly fitFuncAssembly = Assembly.LoadFile(fitnessFunctionDTO.FileName);
            Type typePDF = algoAssembly.GetType("SalpSwarmAlgo.GeneratePDFReport");
            dynamic algorithm = Activator.CreateInstance(algoAssembly.GetType(algorithmDTO.TypeName));
            dynamic fitnessFunction = Activator.CreateInstance(fitFuncAssembly.GetType(fitnessFunctionDTO.TypeName));
            dynamic pdfInstance = Activator.CreateInstance(typePDF);
            //fitFunc, lb, ub, parameters
            if (algorithm!=null)
            {
                string reportPath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\HeuristicAlgoApp-Backend\\Files\\PDFReports\\";
                object solveParams = new object[] { fitnessFunction,fitnessFunctionDTO };
                double result=algorithm.GetType().GetMethod("Solve").Invoke(algorithm,solveParams,reportPath);
                string path = algorithm.GetType().GetField("pdfReportGenerator").Invoke(algorithm);
                PropertyInfo pdfProperty = typePDF.GetProperty("filePathPDF");
                object pdfValue = pdfProperty.GetValue(pdfInstance);
                Console.WriteLine(pdfValue);
                return path;
            }
            else { return null; }
            
            
        }
    }
}
