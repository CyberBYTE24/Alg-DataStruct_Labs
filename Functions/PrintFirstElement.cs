using System;
using System.Linq;

namespace Lab1.Functions
{
    class PrintFirstElement : IFunctions
    {
        public int Number
        {
            get
            {
                return 3;
            }
        }
        public string Name
        {
            get
            {
                return "Распечатать первый элемент файла";
            }
        }
        public GlobalCommand Command()
        {
            PrintFirstElementFunc();
            return GlobalCommand.Continue;
        }
        static private void PrintFirstElementFunc()
        {
            Console.WriteLine($"\n\nПервый элемент файла: {Utilities.ReadFileInt().First()}" + "\n\nНажмите любую кнопку, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}