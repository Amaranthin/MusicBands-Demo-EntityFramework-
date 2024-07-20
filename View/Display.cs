using CustomPrint;
using MusicBands.Services;

namespace MusicBands.View
{
    public class Display
    {
        public static void MainMenu()
        {
            PrintBlueLine();
            MCP.SetConsoleColor("white");
            Console.WriteLine("1) Покажи списък на хората");
            Console.WriteLine("2) Покажи списък на бандите");
            Console.WriteLine("3) Покажи списък на концертите");
            Console.WriteLine("4) Добави нов човек");
            Console.WriteLine("5) Добави нова банда");
            Console.WriteLine("6) Добави нов концерт");
            Console.WriteLine("7) Нека човек да премине в банда");
            Console.WriteLine("8) Изтрий човек");
            Console.WriteLine("9) Изтрий банда");
            Console.WriteLine("10) Редактирай име на банда");
            Console.WriteLine("друго > Изход");
            PrintBlueLine();

            MCP.SetConsoleColor("magenta");
            Console.Write("Изберете вашето действие: ");
            MCP.SetConsoleColor("white");
            int choice = int.Parse(Console.ReadLine());
            PrintBlueLine();

            switch (choice)
            {
                case 1: PeopleServices.ShowPeople(); break;
                case 2: BandServices.ShowFullBandsInfo(); break;
                case 3: ConcertServices.ShowConcerts(); break;
                case 4: PeopleServices.AddNewPerson(); break;
                case 5: BandServices.AddNewBand(); break;
                case 6: ConcertServices.AddNewConcert(); break;
                case 7: PeopleServices.PersonBecomeAMusician(); break;
                case 8: PeopleServices.DeletePerson(); break;
                case 9: BandServices.DeleteBand(); break;
                case 10: BandServices.EditBandName(); break;
                default: Environment.Exit(0); break; 
            }

            MainMenu();
        }

        private static void PrintBlueLine()
        {
            string row = new string('=', 72);
            MCP.PrintNL(row, "blue");
        }
    }
}
