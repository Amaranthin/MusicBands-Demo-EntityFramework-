using CustomPrint;
using MusicBands.Interfaces;


namespace MusicBands.View
{
    //ИДЕЯ за по-напредналите >>> Създаваме шаблонен клас чрез който да можем
    //да си показваме списъци от каквито си искаме обекти поддържащи метод ShortInfo
    //Ще съдържа метод в който изискваме избор на един обект а като резултат ще се
    //връща самия обект

    public class ChooseMenu<TDic, TClass> where TDic : Dictionary<int, TClass>, new() 
        where TClass : IShortInfo, new()
    {
        public static TClass Choose(TDic dictionary)
        {
            //като създаваме нов списък може да изпозваме параметър в конструктора ;)
            //този специално взема стойностите от речник и така си създаваме готов списък
            List<TClass> ourList = new List<TClass>(dictionary.Values);

            ourList.OrderBy(c => c.ShortInfo()).ToList(); //Сортираме азбучно

            TClass x = new TClass();
            MCP.PrintNL($"=== Моля изберете {x.ChooseNotice()} от списъка ===", "magenta");
            //принципно ChooseNotice() трябва да е статичен метод или даже поле
            //но все още версиите на C# имат проблеми с интерфейси указващи статични данни

            int br = 0;  //Отпечатваме списък 
            foreach (TClass element in ourList)
            {
                br++;
                Console.WriteLine($"{br}) {element.ShortInfo()}");
            }

            int choose = 0; //Изискваме въвеждане на номер от списъка
            while (choose < 1 || choose > br)
            {
                MCP.Print("Вашият избор (число):","magenta");
                choose = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(); //

            //Връщаме директно обекта съобразно текущата му позиция в списъка
            return ourList[choose - 1];
        }
    }
}
