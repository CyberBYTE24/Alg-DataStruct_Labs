using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Lab1.Functions
{
    class BubbleSortWithoutFlag : IFunctions
    {
        public int Number
        {
            get
            {
                return 10;
            }
        }
        public string Name
        {
            get
            {
                return "Сортировка глобального массива пузырьком (без проверки)";
            }
        }
        public GlobalCommand Command()
        {
            long time = SortFunc();

            Utilities.WriteMessage($"\nОперация завершена. Затраченное время: {time}мс.", MessageType.Success, Lab1.Command.WaitingKeyPress);
            
            return GlobalCommand.Continue;

        }
        static private long SortFunc()
        {
            Stopwatch sw = Stopwatch.StartNew();

            ref List<int> global = ref Program.GlobalIntMassive;

            
            for(int i = 1; i<global.Count; i++)
            {
                while (global[i] < global[i - 1])
                {
                    (global[i], global[i - 1]) = (global[i - 1], global[i]);
                    i--;
                    if (i == 0) break;
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
            
        }
    }
}
