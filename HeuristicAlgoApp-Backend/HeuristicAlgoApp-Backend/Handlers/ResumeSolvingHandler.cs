﻿using HeuristicAlgoApp_Backend.Commands;
using HeuristicAlgoApp_Backend.Models;
using MediatR;

namespace HeuristicAlgoApp_Backend.Handlers
{
    public class ResumeSolvingHandler:IRequestHandler<ResumeSolvingCommand>
    {
        private readonly DataCollection dataCollection;

        public ResumeSolvingHandler(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        public async Task Handle(ResumeSolvingCommand request, CancellationToken cancellationToken)
        {
            //string path = Directory.GetCurrentDirectory() + "\\..\\HeuristicAlgoApp-Backend\\Files\\States\\PauseFolder\\";
            //string fileName = "PAUSEFILE.txt";
            //string fullPath = System.IO.Path.Combine(path, fileName);

            //try
            //{
            //    if (File.Exists(fullPath))
            //    {
            //        File.Delete(fullPath);
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Plik {fileName} nie istnieje w ścieżce {fullPath}.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Wystąpił błąd podczas usuwania pliku: {ex.Message}");
            //}
            await dataCollection.ResumeSingleTask();
            await Task.CompletedTask;
        }
    }
}
