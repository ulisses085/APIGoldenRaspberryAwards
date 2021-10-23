using APIGoldenRaspberryAwards.Context;
using APIGoldenRaspberryAwards.Entities;
using System.Collections.Generic;
using System.Linq;

namespace APIGoldenRaspberryAwards.Interfaces
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly DatabaseContext context;
        public MoviesRepository (DatabaseContext ctx)
        {
            context = ctx;
        }

        public WorstMovies Insert(WorstMovies obj)
        {
            context.Add(obj);
            context.SaveChanges();
            return obj;
        }

        public IntervaloPremios Find()
        {
            var movies = from movie in context.Movies.ToList()
                        where movie.Winner
                      orderby movie.Year
                       select movie;

            var listDados = new List<Dados>();
            var max = int.MinValue;
            var min = int.MaxValue;

            foreach (var moviePrevious in movies)
            {
                foreach (var movieFollowing in movies)
                {
                    if (moviePrevious.Producer.ToUpper().Equals(movieFollowing.Producer.ToUpper()) && 
                        moviePrevious.Year < movieFollowing.Year)
                    {
                        var interval = movieFollowing.Year - moviePrevious.Year;

                        if (interval < min)
                        {
                            min = interval;
                        }
                        if (interval > max)
                        {
                            max = interval;
                        }

                        listDados.Add(
                            new Dados
                            {
                                Producer = moviePrevious.Producer,
                                Interval = interval,
                                PreviousWin = moviePrevious.Year,
                                FollowingWin = movieFollowing.Year
                            });
                    }
                }
            }

            return new ()
            {
                Max = listDados.Where(dado => dado.Interval == max).ToList(),
                Min = listDados.Where(dado => dado.Interval == min).ToList()
            };
        }
    }
}