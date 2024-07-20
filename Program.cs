using MusicBands.View;
using MusicBands.Services;

namespace MusicBands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Зареждане на речниците за бърз достъп в кеша
            CashedDataServices.RefreshCountriesDictionary();
            CashedDataServices.RefreshCitiesDictionary();
            CashedDataServices.RefreshBandsDictionary();
            CashedDataServices.RefreshPeopleDictionary();

            Display.MainMenu();
        }
    }
}
