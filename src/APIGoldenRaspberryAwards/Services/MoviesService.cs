using APIGoldenRaspberryAwards.Entities;
using APIGoldenRaspberryAwards.Interfaces;
using NLog.Fluent;
using System;
using System.IO;

namespace APIGoldenRaspberryAwards.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository moviesRepository;
        public MoviesService (IMoviesRepository movieRepo)
        {
            moviesRepository = movieRepo;
        }

        public IntervaloPremios GetIntervaloPremios()
        {
            return moviesRepository.Find();
        }

        public void LoadDataToDB()
        {
            try
            {
                var key = 1;
                var reader = new StreamReader(File.OpenRead(@"C:\movielist.csv"));
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (values.Length != 5 ||
                    !line.ToUpper().Equals("YEAR;TITLE;STUDIOS;PRODUCERS;WINNER"))
                {
                    throw new Exception("Os dados do arquivo são inválidos");
                }
                
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    values = line.Split(';');

                    if (int.TryParse(values[0], out int year))
                    {
                        var producers = values[3].Replace(" and ",",").Split(',');

                        foreach (var produce in producers)
                        {
                            moviesRepository.Insert(
                                new WorstMovies()
                                {
                                    PrimaryKey = key,
                                    Year = year,
                                    Title = values[1],
                                    Studio = values[2],
                                    Producer = produce.Trim(),
                                    Winner = !string.IsNullOrWhiteSpace(values[4])
                                });
                            key++;
                        }
                    }
                }
            }
            catch (FileNotFoundException exception)
            {
                Log.Error(exception.Message);
                throw new Exception("Arquivo movielist.cs não foi localizado na únidade no caminho C:\\ ");
            }
            catch (Exception exception)
            {
                Log.Error(exception.Message);
                throw;
            }
        }
    }
}