using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithSingleAlgoHandler : IRequestHandler<SolveWithSingleAlgoCommand,double?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithSingleAlgoHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<double?> Handle(SolveWithSingleAlgoCommand request, CancellationToken cancellationToken)
        {
            Algorithm algorithmDTO = await dataCollection.GetAlgorithmById(request.algoId);
            FitnessFunction fitnessFunctionDTO = await dataCollection.GetFitnessFunctionById(request.fitFuncId);
            Assembly algoAssembly = Assembly.LoadFile(algorithmDTO.FileName);
            Assembly fitFuncAssembly = Assembly.LoadFile(fitnessFunctionDTO.FileName);
            dynamic algorithm = Activator.CreateInstance(algoAssembly.GetType(algorithmDTO.TypeName));
            dynamic fitnessFunction = Activator.CreateInstance(fitFuncAssembly.GetType(fitnessFunctionDTO.TypeName));
            //fitFunc, lb, ub, parameters
            if (algorithm!=null)
            {
                object solveParams = new object[] { fitnessFunction,fitnessFunctionDTO };
                double result=algorithm.GetType().GetMethod("Solve").Invoke(algorithm);
                return result;
            }
            else { return null; }
            
            
        }
    }
}
