using HeuristicAlgoApp_Backend.IModels;
namespace HeuristicAlgoApp_Backend.Models
{
    public class Algorithm
    {
        public static int UUID = 0;
        public int Id {get;set;}
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string FileName { get; set; }
        public List<Parameter> Parameters { get; set; }

        public Algorithm() { GenerateId(); }
        public void GenerateId() {
            Id= Interlocked.Increment(ref UUID);
        }
    }
}
