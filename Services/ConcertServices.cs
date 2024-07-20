using CustomPrint;
using MusicBands.Data;
using MusicBands.Models;
using MusicBands.View;

namespace MusicBands.Services
{
    public class ConcertServices
    {
        public static void ShowConcerts()
        {
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                var concerts = db.Concerts.OrderBy(e => e.DateTime).ToList();
                concerts.ForEach(e => ShowConcertInfo(e));
            }
        }

        private static void ShowConcertInfo(Concert c)
        {
            MCP bandStyle = new MCP("cyan", 32, "left", "| ", "");
            MCP cityStyle = new MCP("white", 14, "center", "| ", "");
            MCP dateStyle = new MCP("green", 12, "left", "| ", " |");

            bandStyle.Print(CashedData.Bands[c.BandID].Name);
            cityStyle.Print(CashedData.Cities[c.CityID].Name);

            string year = c.DateTime.Year.ToString();
            string month = CashedData.Мonths[c.DateTime.Month];
            string date = c.DateTime.Day.ToString();
            string hour = c.DateTime.Hour.ToString();
            string minute = c.DateTime.Minute.ToString();

            if (date.Length < 2) date = "0" + date;
            if (hour.Length < 2) hour = "0" + hour; 
            if (minute.Length < 2) minute = "0" + minute;

            string fullDateInfo = $"{year}  {date}-{month} {hour}:{minute}";
            dateStyle.PrintNL(fullDateInfo);
        }

        public static void AddNewConcert()
        {
            //Показваме един по един списъците от къде какво искаме да се добави

            Band choosenBand = ChooseMenu<Dictionary<int, Band>, Band>.Choose(CashedData.Bands);

            Country choosenCountry = ChooseMenu<Dictionary<int, Country>, Country>.Choose(CashedData.Countries);

            //За градовете искаме само градовете от конкретната страна
            //И това може да се направи шаблонен клас в един по-голям проект
            //но то използваме само тук затова ще го имплементираме на място

            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                var cities = db.Cities.Where(c => c.CountryID == choosenCountry.ID).ToList();
                                      
                if (cities.Count == 0)
                {
                    Console.WriteLine("В тази държава липсва информация за градовете");
                    return;
                }

                MCP.PrintNL($"=== Моля изберете град от списъка ===", "magenta");
 
                int br = 0;  //Отпечатваме списък 
                foreach (City element in cities)
                {
                    br++;
                    Console.WriteLine($"{br}) {element.ShortInfo()}");
                }

                int choose = 0; //Изискваме въвеждане на номер от списъка
                while (choose < 1 || choose > br)
                {
                    MCP.Print("Вашият избор (число):", "magenta");
                    choose = int.Parse(Console.ReadLine());
                }

                City choosenCity = cities[choose - 1];

                MCP.Print("Въведете датата на концерта във формат YYYY-MM-DD ","green");
                string date = Console.ReadLine();
                string[] info = date.Split('-');

                int year = int.Parse(info[0]);
                int month = int.Parse(info[1]); 
                int day = int.Parse(info[2]);

                MCP.Print("Въведете часът на концерта във формат HH:MM ", "green");
                string time = Console.ReadLine();
                string[] info2 = time.Split(':');

                int hour = int.Parse(info2[0]);
                int min = int.Parse(info2[1]);

                DateTime chosenDate = new DateTime(year,month,day, hour, min, 0);

                Concert newConcert = new Concert(choosenBand, choosenCity, chosenDate);

                db.Concerts.Add(newConcert);
                db.SaveChanges();
            }
        }
    }
}
