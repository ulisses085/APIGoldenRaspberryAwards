using APIGoldenRaspberryAwards.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIGoldenRaspberryAwards.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<WorstMovies> Movies { get; set; }
    }
}