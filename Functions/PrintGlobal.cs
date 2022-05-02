using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class PrintGlobal : IFunctions
    {
        public int Number
        {
            get
            {
                return 7;
            }
        }
        public string Name
        {
            get
            {
                return "Вывести на печать числа из глобального динамического массива";
            }
        }
        public GlobalCommand Command()
        {
            PrintGlobalFunc();
            return GlobalCommand.Continue;
        }
        static private void PrintGlobalFunc()
        {
            Console.Write($"\n\nВ глобальном массиве {Program.GlobalIntMassive.Count} элемента: \n");

            for (int i = 0; i < Program.GlobalIntMassive.Count; i += 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i + j >= Program.GlobalIntMassive.Count)
                        continue;
                    Console.Write($"{i + j + 1}. {Program.GlobalIntMassive[i + j]}\t");
                }
                Console.WriteLine();
            }
            Console.Write("\n\nНажмите любую кнопку, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }
}
