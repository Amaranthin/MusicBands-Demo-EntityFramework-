using MusicBands.Models;
using MusicBands.Data;

namespace MusicBands.Services
{
    internal class CashedDataServices
    {
        //Можеше да се изнесе като шаблонен клас, но така е по-четимо

        public static void RefreshCountriesDictionary()
        {
            //За да не четем постоянно страните, понеже използваме ID
            //ще си ги четем от речник, който прочитаме еднократно в началото
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Dictionary<int, Country> countries 
                    = db.Countries.ToDictionary(c => c.ID, c => c);
                CashedData.Countries = countries;
            }  
        }

        public static void RefreshCitiesDictionary()
        {
            //Аналогично и за градовете
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Dictionary<int, City> cities = db.Cities.ToDictionary(c => c.ID, c => c);
                CashedData.Cities = cities;
            }
        }

        public static void RefreshBandsDictionary()
        {
            //Аналогично и за музикалните банди
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Dictionary<int, Band> bands = db.Bands.ToDictionary(b => b.ID, b => b);
                CashedData.Bands = bands;
            }
        }

        public static void RefreshPeopleDictionary()
        {
            //Аналогично и за хората
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Dictionary<int, Person> people = db.People.ToDictionary(p => p.ID, p => p);
                CashedData.People = people;
            }
        }
    }
}
