namespace HeuristicAlgoApp_Backend.Models
{
    public class AlgoStateDTO
    {
            public int I { get; set; }
            public int It { get; set; }
            public string Name { get; set; }   



        // Konstruktor klasy
        public AlgoStateDTO(int i, int it,string name)
            {
                I = i;
                It = it;
                Name = name;
            }
     }
    
}
