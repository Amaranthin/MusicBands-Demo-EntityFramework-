using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicBands.Interfaces;

namespace MusicBands.Models
{
    public class Band : IShortInfo
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        public string Name { get; set; }

        [Column ("formed_year")]
        public int FormedYear { get; set; }

        [Column("country_id")]
        public int CountryID { get; set; }

        public Band() { }
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка

        public Band(string name, int formedYear, Country country)
        {
            this.Name = name;
            this.FormedYear = formedYear;
            this.CountryID = country.ID;
        }

        //изисканите от интерфейса >>>
        public string ShortInfo()
        {
            return this.Name;
        }

        public string ChooseNotice()
        {
            return "банда"; 
        }
    }
}
