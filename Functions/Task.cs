using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class Task : IFunctions
    {
        static private int a, c;
        public int Number
        {
            get
            {
                return 17;
            }
        }
        public string Name
        {
            get
            {
                return "Задачка F(x)";
            }
        }
        public GlobalCommand Command()
        {
            Console.Write("Введите число A: ");
            a = Utilities.ConvertStringToInt(Console.ReadLine());
            Console.Write("Введите число C: ");
            c = Utilities.ConvertStringToInt(Console.ReadLine());
            Console.Write("Введите число N: ");
            int n = Utilities.ConvertStringToInt(Console.ReadLine());

            Utilities.WriteMessage($"\nОперация завершена. Результирующее число последовательности: {ComputeFunc(n)}", MessageType.Success, Lab1.Command.WaitingKeyPress);

            return GlobalCommand.Continue;

        }
        static private int ComputeFunc(int n)
        {
            if(0<=n && n <= 9)
            {
                return n;
            }
            else
            {
                return G(n) * ComputeFunc(n - 1 - G(n));
            }
        }
        static private int G(int n)
        {
            return a * (n + c) % 10;
        }
    }
}
