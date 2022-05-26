using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class FibonachiiInteger : IFunctions
    {
        public int Number
        {
            get
            {
                return 16;
            }
        }
        public string Name
        {
            get
            {
                return "Числа Фибоначчи";
            }
        }
        public GlobalCommand Command()
        {
            Console.Write("Введите порядковый номер числа из последовательности Фибоначчи: ");
            int n = Utilities.ConvertStringToInt(Console.ReadLine());

            Utilities.WriteMessage($"\nОперация завершена. Результирующее число последовательности: {ComputeFunc(n)}", MessageType.Success, Lab1.Command.WaitingKeyPress);

            return GlobalCommand.Continue;

        }
        static private int ComputeFunc(int n)
        {
            List<int> result = new List<int>() { 0, 1 };

            for(int i = 2; i < n+1; i++)
            {
                result.Add(result[i - 2] + result[i - 1]);
            }

            return result[n];

        }
    }
}
