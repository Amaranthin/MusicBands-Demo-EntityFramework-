using MusicBands.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicBands.Models
{
    public class Person :IShortInfo
    {
        [Key]
        [Column("id")]
        public int ID { get; set; } //auto increment
        public string Name { get; set; }
        public string Family { get; set; }
        public int? Age { get; set; }    
        public string Gender { get; set; }  //"F" or "M"

        public Person() { }
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка

        public Person(string name, string family, int? age, string gender)
        {
            //id e auto increment и не се задава при създаване
            this.Name = name;
            this.Family = family;
            this.Age = age;
            this.Gender = gender;
        }

        //изисканите от интерфейса >>>
        public string ShortInfo()
        {
            return $"{this.Name} {this.Family}";
        }
        public string ChooseNotice()
        {
            return "човек";
        }

    }
}
