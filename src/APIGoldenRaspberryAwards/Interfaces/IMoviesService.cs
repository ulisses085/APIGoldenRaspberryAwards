using APIGoldenRaspberryAwards.Entities;

namespace APIGoldenRaspberryAwards.Interfaces
{
    public interface IMoviesService
    {
        IntervaloPremios GetIntervaloPremios();
        void LoadDataToDB();
    }
}