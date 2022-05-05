using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab1.Functions
{
    class BubbleSortWithFlag : IFunctions
    {
        public int Number
        {
            get
            {
                return 9;
            }
        }
        public string Name
        {
            get
            {
                return "Сортировка глобального массива пузырьком (с проверкой)";
            }
        }
        public GlobalCommand Command()
        {
            long time = PrintFileFunc();

            Utilities.WriteMessage($"\nОперация завершена. Затраченное время: {time}мс.", MessageType.Success, Lab1.Command.WaitingKeyPress);
            
            return GlobalCommand.Continue;

        }
        static private long PrintFileFunc()
        {
            Stopwatch sw = Stopwatch.StartNew();

            ref List<int> global = ref Program.GlobalIntMassive;

            bool flag = false;
            do
            {
                flag = false;
                for (int i = 0; i<global.Count-1; i++)
                {
                    if (global[i] > global[i + 1])
                    {
                        (global[i], global[i + 1]) = (global[i+1], global[i]);
                        flag = true;
                    }
                }
            } while (flag);

            sw.Stop();
            return sw.ElapsedMilliseconds;
            
        }
    }
}
