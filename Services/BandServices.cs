using System;
using MusicBands.Data;
using MusicBands.Models;
using CustomPrint;
using MusicBands.View;

namespace MusicBands.Services
{
    public class BandServices
    {
        private static InputData IO = new InputData();

        public static void ShowFullBandsInfo()
        {
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.Bands.ToList()
                    .ForEach(
                     b =>
                     {
                         ShowSingleBandInfo(b); //първо показваме инфото на бандата
                         PrintBandMembers(b);   //после отпечатваме членовете ѝ
                     }
                    );
            }
        }

        private static void ShowSingleBandInfo(Band band)
        {
            string row = new string('-', 72);

            MCP bandName = new MCP("magenta", 32, "center");
            MCP bandCountry = new MCP("white", 12);
            MCP bandFounded = new MCP("green");

            MCP.PrintNL(row, "white");
            bandName.Print(band.Name);
            bandCountry.Print(CashedData.Countries[band.CountryID].Name);
            bandFounded.PrintNL(band.FormedYear.ToString());
            MCP.PrintNL(row, "white");
        }


        private static void PrintBandMembers(Band band)
        {
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                List<Musician> membersList = db.Musicians.Where(m => m.BandID == band.ID).ToList();
                foreach (Musician m in membersList)
                {
                    string[] fullName = GetPersonName(m);
                    MCP.Print(fullName[0], "cyan", 15);
                    MCP.Print(fullName[1], "cyan", 15);
                    MCP.Print(JoinInfo(m), "white", 12);
                    MCP.PrintNL(LeftInfo(m), "white");
                }
            }
        }

        private static string[] GetPersonName(Musician musician)
        {
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Person person = db.People.Where(p => p.ID == musician.PersonID).FirstOrDefault();

                string[] fullName = new string[2];
                fullName[0] = person.Name;
                fullName[1] = person.Family;

                return fullName;
            }
        }

        private static string JoinInfo(Musician m)
        {
            DateTime? d = m.DateJoined;
            if (d != null) return "join:" + ((DateTime)d).Year.ToString();
            return "";
        }

        private static string LeftInfo(Musician m)
        {
            DateTime? d = m.DateLeft;
            if (d != null) return "left:" + ((DateTime)d).Year.ToString();
            return "";
        }

        public static void AddNewBand()
        {
            string name = IO.Input("Въведете име на бандата", 32);
            string formed = IO.Input("Година на създаване", 4);
            int formedYear = int.Parse(formed);

            //==============================================================
            //Кодът по-долу е опростена версия на шаблонния клас ChooseMenu.cs
            //==============================================================
            //--- тук е описан в конкретната ситуация за да го разберете
            //--- и да може да разберете обобщената в шаблонния клас

            //като създаваме нов списък може да изпозваме параметър в конструктора ;)
            //този специално взема стойностите от речник и така си създаваме готов списък
            List<Country> countries = new List<Country>(CashedData.Countries.Values);

            countries.OrderBy(c => c.Name).ToList();

            int br = 0;  //Отпечатваме списък на страните
            foreach (Country country in countries)
            {
                br++;
                Console.WriteLine($"{br}) {country.Name}");
            }

            int choose = 0; //Изискваме въвеждане на страна
            while (choose < 1 || choose > br)
            {
                Console.WriteLine("Въведете страната (числото от списъка)");
                choose = int.Parse(Console.ReadLine());
            }

            //Вземаме конкретната страна в нова променлива за да е по-четимо като я подадем 
            //към конструктора за създаването на новата банда
            Country choosenCountry = countries[choose - 1];

            //======================================================================
            //============ край на кода за избор от ChooseMenu.cs ==================

            Band newBand = new Band(name, formedYear, choosenCountry);

            //Запис на новия обект/банда в базата с данни
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.Bands.Add(newBand);
                db.SaveChanges();
            }

            CashedDataServices.RefreshBandsDictionary(); //Опресни кеша с бандите
        }

        static public void DeleteBand()
        {
            //избери коя през шаблонния клас
            Band band = ChooseMenu<Dictionary<int, Band>, Band>.Choose(CashedData.Bands);
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();
            }
            CashedDataServices.RefreshBandsDictionary(); //рефрешваме кеша
        }

        static public void EditBandName()
        {
            //нека да имаме и последната CRUD операция  - Update
            Band band = ChooseMenu<Dictionary<int, Band>, Band>.Choose(CashedData.Bands);

            MCP.Print("Моля изберете ново име на бандата:", "green");
            string newName = Console.ReadLine();

            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                Band targetBand = db.Bands.Where(b => b.ID == band.ID).FirstOrDefault();
                if (targetBand != null) targetBand.Name = newName;
                db.SaveChanges();
            }
            CashedDataServices.RefreshBandsDictionary(); //рефрешваме кеша
        }
    }
}
