using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MusicBands.Models
{
    public class Musician
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("person_id")]
        public int PersonID { get; set; }

        [Column("band_id")]
        public int BandID { get; set; }

        [Column("date_joined")]
        public DateTime? DateJoined { get; set; }

        [Column("date_left")]
        public DateTime? DateLeft { get; set; }

        public Musician() { }
        //Трябва да оставите и празни конструктори
        //за да може да тръгне коректно фреймуорка

        public Musician(Person person, Band band)
        {
            //при липса на дата, да ги залага към днешна дата
            DateJoined = DateTime.Now;
            PersonID = person.ID;
            BandID = band.ID;
        }

        public Musician(Person person, Band band, DateTime dateTime)
        {
            DateJoined = dateTime;
            PersonID = person.ID;
            BandID = band.ID;
        }
    }
}
