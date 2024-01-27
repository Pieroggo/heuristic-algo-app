using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;
using Newtonsoft.Json;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class BreakMultiSolvingHandler : IRequestHandler<BreakMultiSolvingCommand, string>
    {
        private readonly DataCollection dataCollection;

        public BreakMultiSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task<string> Handle(BreakMultiSolvingCommand request, CancellationToken cancellationToken)
        {
            string stateFolderPath = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\MultiAlgo\\";
            await dataCollection.CancelMultiTask();
            System.IO.DirectoryInfo di;
            di = new DirectoryInfo(stateFolderPath);
            while (di.GetFiles().Length == 0) { Thread.Sleep(200); }
            FileInfo file = di.GetFiles().ElementAt(0);


            //string fileContents = File.ReadAllText(file.FullName);
            //Thread.Sleep(200);

            // Deserializacja JSONa do obiektu
            //var _data = JsonConvert.DeserializeObject<AlgoState>(fileContents);

            // Przykład użycia odczytanych danych
            return file.Name.Split(".")[0];
            //if breaking fails, delete SingleAlgo Folder in States
        }
    }
}
