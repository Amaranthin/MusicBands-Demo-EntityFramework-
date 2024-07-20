using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicBands.Interfaces;

namespace MusicBands.Models
{
    public class City : IShortInfo
    {
        
        [Key]
        [Column("id")]
        public int ID { get; set; }
        public string Name { get; set; }

        [Column("country_id")]
        public int CountryID { get; set; }

        public City() { }
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка

        public City(string name, Country country)
        {
            this.Name = name;  
            this.CountryID = country.ID;
        }

        //изисканите от интерфейса >>>
        public string ShortInfo()
        {
            return this.Name;
        }
        public string ChooseNotice()
        {
            return "град";
        }


    }
}
