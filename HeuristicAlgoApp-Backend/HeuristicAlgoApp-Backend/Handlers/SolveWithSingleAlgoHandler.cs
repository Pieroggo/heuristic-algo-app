using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class SolveWithSingleAlgoHandler : IRequestHandler<SolveWithSingleAlgoCommand, double?[]?>
    {
        private readonly DataCollection dataCollection;

        public SolveWithSingleAlgoHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<double?[]?> Handle(SolveWithSingleAlgoCommand request, CancellationToken cancellationToken)
        {
            List<double?> results = new List<double?>();
            Algorithm algorithmDTO = await dataCollection.GetAlgorithmById(request.algoId);
            Assembly algoAssembly = Assembly.LoadFile(algorithmDTO.FileName);
            dynamic algorithm = Activator.CreateInstance(algoAssembly.GetType(algorithmDTO.TypeName));
            //fitFunc, lb, ub, parameters
            if (algorithm!=null)
            {
                foreach (int fitFuncId in request.fitFuncIds) {
                    FitnessFunction fitnessFunctionDTO = await dataCollection.GetFitnessFunctionById(fitFuncId);
                    Assembly fitFuncAssembly = Assembly.LoadFile(fitnessFunctionDTO.FileName);
                    dynamic fitnessFunction = Activator.CreateInstance(fitFuncAssembly.GetType(fitnessFunctionDTO.TypeName));
                    if (fitnessFunction != null)
                    {
                        object solveParams = new object[] { fitnessFunction }; //adjust so that you can use solve
                        await dataCollection.AssignReferenceSingleAlgo(algorithm);
                        double result = algorithm.GetType().GetMethod("Solve").Invoke(algorithm);
                        results.Add(result);
                        await dataCollection.AssignReferenceSingleAlgo(null); //reset of reference
                    }
                    else {
                        results.Add(null);
                    }
                }
                return results.ToArray();
            }
            else { return null; }
            
            
        }
    }
}
