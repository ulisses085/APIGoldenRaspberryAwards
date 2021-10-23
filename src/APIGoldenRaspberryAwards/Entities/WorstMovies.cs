using System.ComponentModel.DataAnnotations;

namespace APIGoldenRaspberryAwards.Entities
{
    public class WorstMovies
    {
        [Key]
        public int PrimaryKey { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Producer { get; set; }
        public bool Winner { get; set; }
    }
}
