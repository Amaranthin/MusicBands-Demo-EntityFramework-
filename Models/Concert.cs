using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class Concert
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("band_id")]
        public int BandID { get; set; }

        [Column("city_id")]
        public int CityID { get; set; }

        [Column("date_time")]
        public DateTime DateTime { get; set; }

        public Concert() { } 
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка

        public Concert(Band band, City city, DateTime date)
        {
            this.BandID = band.ID;
            this.CityID = city.ID;
            this.DateTime = date;
        }
    }
}
