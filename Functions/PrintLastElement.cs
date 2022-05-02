using System;
using System.Linq;

namespace Lab1.Functions
{
    class PrintLastElement : IFunctions
    {
        public int Number
        {
            get
            {
                return 4;
            }
        }
        public string Name
        {
            get
            {
                return "Распечатать последний элемент файла";
            }
        }
        public GlobalCommand Command()
        {
            PrintLastElementFunc();
            return GlobalCommand.Continue;
        }
        static private void PrintLastElementFunc()
        {
            Console.WriteLine($"\n\nПоследний элемент файла: {Utilities.ReadFileInt().Last()}" + "\n\nНажмите любую кнопку, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}
