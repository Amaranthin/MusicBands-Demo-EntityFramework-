using CustomPrint;
using MusicBands.Data;
using MusicBands.Models;
using MusicBands.View;

namespace MusicBands.Services
{
    public class PeopleServices
    {
        static InputData IO = new InputData(); //IO = InputOutput

        static MCP numStyle = new MCP("magenta", 4, "right", "", ") ");
        static MCP nameStyle = new MCP("cyan", 12);
        static MCP ageStyle = new MCP("red", 4, "right");
        static MCP genderStyle = new MCP("white", 8, "center");
        static MCP bandStyle = new MCP("green", 16, "left");

        public static void ShowPeople()
        {
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                var people = db.People.ToList();

                int br = 0;
                foreach (Person p in people)
                {
                    br++;
                    ShowPerson(p, br);
                }
            }
        }

        //Следващите 2 метода може и да не са статични, но е малко по-четимо и кратко 
        //ако използваме p вместо this (ако ги направим нестатични)

        static private void ShowPerson(Person p, int numberInList)
        {
            numStyle.Print(numberInList.ToString());
            nameStyle.Print(p.Name);
            nameStyle.Print(p.Family);
            ageStyle.Print(p.Age.ToString());
            genderStyle.Print(p.Gender == "м" ? "мъж" : "жена");

            string band = GetBandName(p);
            bandStyle.PrintNL(band);
        }

        static private string GetBandName(Person p)
        {
            List<int> listBands; //ако не е записан в никаква банда ще остане NULL
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                listBands = db.Musicians.Where(m => m.PersonID == p.ID).Select(m => m.BandID).ToList();
            }

            string bands = ""; int br = 0;
            foreach (var i in listBands)
            {
                br++; //за да добавим запетайки зад тях без последната
                bands += CashedData.Bands[i].Name;
                if (br < listBands.Count) bands += ", ";
            }

            return bands;
        }

        static public void AddNewPerson()
        {
            string name = IO.Input("Въведете име", 12);
            string family = IO.Input("Въведете фамилия", 12);
            int? age = int.Parse(IO.Input("Въведете години (или 0 за null) ", 3));
            if (age == 0) age = null;

            string gender = IO.Input("Въведете пол (м/ж)", 1);
            while (gender != "м" && gender != "ж")
            {
                Console.WriteLine("Некоректен пол. Въведете отново!");
                gender = IO.Input("Въведете пол (м/ж)", 1);
            }

            Person newGuy = new Person(name, family, age, gender);

            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.People.Add(newGuy);
                db.SaveChanges();
            }

            CashedDataServices.RefreshPeopleDictionary(); //рефрешваме кеша
        }

        public static void PersonBecomeAMusician()
        {
            Person person = ChooseMenu<Dictionary<int, Person>, Person>.Choose(CashedData.People);
            Band band = ChooseMenu<Dictionary<int, Band>, Band>.Choose(CashedData.Bands);

            Musician musician = new Musician(person, band);

            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.Musicians.Add(musician);
                db.SaveChanges();
            }

            //музикантите нямат кеш речник, понеже не ни се налага да ги показваме в меню за избор
            //затова и няма речник който да рефрешваме след промяната
        }

        static public void DeletePerson()
        {
            //избери кой през шаблонния клас
            Person person = ChooseMenu<Dictionary<int, Person>, Person>.Choose(CashedData.People);
            using (MusicBandsDbContext db = new MusicBandsDbContext())
            {
                db.People.Remove(person);
                db.SaveChanges();
            }
            CashedDataServices.RefreshPeopleDictionary(); //рефрешваме кеша
        }
    }
}
