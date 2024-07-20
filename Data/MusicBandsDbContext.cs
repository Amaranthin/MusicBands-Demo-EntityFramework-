using Microsoft.EntityFrameworkCore;
using MusicBands.Models;

namespace MusicBands.Data
{
    public class MusicBandsDbContext : DbContext //Важно!!! Трябва да наследява
    {                                            //DbContext за да овъррайднете 
                                                 //Метода OnConfiguring
        public DbSet<Band> Bands { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost; database=music_bands; user=root; password=",
              new MySqlServerVersion(new Version(8, 0, 21)));
        }
    }
}
