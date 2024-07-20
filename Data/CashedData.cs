using MusicBands.Models;

namespace MusicBands.Data
{
    public class CashedData
    {
        //РЕЧНИЦИ с КЕШИРАНИ ДАННИ
        //можеше и да го направим със списъци, ръководил съм се от факта, че когато ми трябва
        //дадена инстанция по ID мога директно да я взема по ключа на речника

        //статичен речник с държавите (не само имената а целите обекти)
        public static Dictionary<int, Country> Countries
            = new Dictionary<int, Country>();

        //статичен речник с градовете (не само имената а целите обекти)
        public static Dictionary<int, City> Cities
           = new Dictionary<int, City>();

        //статичен речник с Групите (не само имената а целите обекти)
        public static Dictionary<int, Band> Bands
            = new Dictionary<int, Band>();

        //статичен речник с Хората (не само имената а целите обекти)
        public static Dictionary<int, Person> People
            = new Dictionary<int, Person>();

        public static string[] Мonths = { "0", "яну", "фев", "март", "апр", "май", "юни", "юли", "авг", "сеп", "окт", "ное", "дек" }; 
    }
}
