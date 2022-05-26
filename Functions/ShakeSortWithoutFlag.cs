using System.Diagnostics;
using System.Collections.Generic;

namespace Lab1.Functions
{
    class ShakeSortWithoutFlag : IFunctions
    {
        public int Number
        {
            get
            {
                return 12;
            }
        }
        public string Name
        {
            get
            {
                return "Сортировка глобального массива перемешиванием (без проверки)";
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

            int left = 0;
            int right = global.Count-1;

            while (left <= right)
            {
                for(int i=left; i<right; i++)
                {
                    if (global[i] > global[i + 1])
                    {
                        (global[i], global[i + 1]) = (global[i + 1], global[i]);
                    }
                }
                right--;
                for(int i = right; i >= left; i--)
                {
                    if (global[i] > global[i + 1])
                    {
                        (global[i], global[i + 1]) = (global[i + 1], global[i]);
                    }
                }
                left++;
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
            
        }
    }
}
