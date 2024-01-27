using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class BreakSolvingHandler : IRequestHandler<BreakSolvingCommand,string>
    {
        private readonly DataCollection dataCollection;

        public BreakSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<string> Handle(BreakSolvingCommand request, CancellationToken cancellationToken)
        {
            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\SingleAlgo\\";
            await dataCollection.CancelSingleTask();
            System.IO.DirectoryInfo di;
            di = new DirectoryInfo(stateFolderPath);
            while (di.GetFiles().Length == 0) { Thread.Sleep(200); }
            FileInfo file = di.GetFiles().ElementAt(0);


            string fileContents = File.ReadAllText(file.FullName);
            //Thread.Sleep(200);

                // Deserializacja JSONa do obiektu
                //var _data = JsonConvert.DeserializeObject<AlgoState>(fileContents);
                //Works only on SSA
                // Przykład użycia odczytanych danych
                return file.Name.Split(".")[0];
            //if breaking fails, delete SingleAlgo Folder in States
        }
    }
}
