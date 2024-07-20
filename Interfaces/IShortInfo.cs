namespace MusicBands.Interfaces
{
    public interface IShortInfo
    {
        public string ShortInfo();
        //да връща текст на 1 ред с информация за обекта
        //който ще се показва в списъка за избор чрез число

        public string ChooseNotice(); 
        //думата която ще се показва в надпис от рода на "Моля изберете {ОБЕКТ} от списъка"
       
    }
}
