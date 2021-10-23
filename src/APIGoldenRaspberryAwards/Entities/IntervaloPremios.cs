using System.Collections.Generic;

namespace APIGoldenRaspberryAwards.Entities
{
    public class Dados
    {
        public string Producer { get; set; }
        public int Interval { get; set; }
        public int PreviousWin { get; set; }
        public int FollowingWin { get; set; }
    }

    public class IntervaloPremios
    {
        public IntervaloPremios()
        {
            Min = new List<Dados>();
            Max = new List<Dados>();
        }
        public List<Dados> Min { get; set; }
        public List<Dados> Max { get; set; }
    }
}
