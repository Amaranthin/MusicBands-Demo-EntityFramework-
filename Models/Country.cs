using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MusicBands.Interfaces;

namespace MusicBands.Models
{
    public class Country :IShortInfo
    { 
        [Key]
        [Column("id")]
        public int ID { get; set; }
        public string Name { get; set; }

        public Country() { }
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка
        public Country(string name)
        {
            this.Name = name;
        }

        //изисканите от интерфейса >>>
        public string ShortInfo()
        {
            return this.Name;
        }
        public string ChooseNotice()
        {
            return "страна";
        }
    }
}
