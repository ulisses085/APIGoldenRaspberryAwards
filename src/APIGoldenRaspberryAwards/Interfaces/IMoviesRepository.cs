using APIGoldenRaspberryAwards.Entities;

namespace APIGoldenRaspberryAwards.Interfaces
{
    public interface IMoviesRepository
    {
        public WorstMovies Insert(WorstMovies obj);
        public IntervaloPremios Find();
    }
}
