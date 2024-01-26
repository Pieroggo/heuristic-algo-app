using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class BreakSolvingHandler : IRequestHandler<BreakSolvingCommand,AlgoStateDTO>
    {
        private readonly DataCollection dataCollection;

        public BreakSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<AlgoStateDTO> Handle(BreakSolvingCommand request, CancellationToken cancellationToken)
        {
            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\SingleAlgo\\";
            await dataCollection.CancelSingleTask();
            System.IO.DirectoryInfo di = new DirectoryInfo(stateFolderPath);
            FileInfo file = di.GetFiles().ElementAt(0);
            string fileContents = File.ReadAllText(file.FullName);
            //Thread.Sleep(200);
            

                // Deserializacja JSONa do obiektu
                var _data = JsonConvert.DeserializeObject<AlgoState>(fileContents);

                // Przykład użycia odczytanych danych
                return new AlgoStateDTO(_data.I, _data.It, file.Name.Split(".")[0]);
            //if breaking fails, delete SingleAlgo Folder in States
        }
    }
}
