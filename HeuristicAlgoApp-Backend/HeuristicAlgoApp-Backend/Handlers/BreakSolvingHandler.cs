using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class BreakSolvingHandler : IRequestHandler<BreakSolvingCommand>
    {
        private readonly DataCollection dataCollection;

        public BreakSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public Task Handle(BreakSolvingCommand request, CancellationToken cancellationToken)
        {
            string path = Directory.GetCurrentDirectory() + "\\PauseFolder\\";
            string fileName = "PAUSEFILE.txt";
            string fullPath = Path.Combine(path, fileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            try
            {
                using (StreamWriter sw = File.CreateText(fullPath))
                {
                    sw.WriteLine("PAUSEFILE to pause program");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas tworzenia pliku: {ex.Message}");
            }

            return Task.CompletedTask;
        }
    }
}
