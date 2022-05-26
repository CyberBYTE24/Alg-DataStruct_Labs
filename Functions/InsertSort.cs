using System.Diagnostics;
using System.Collections.Generic;

namespace Lab1.Functions
{
    class InsertSort : IFunctions
    {
        public int Number
        {
            get
            {
                return 13;
            }
        }
        public string Name
        {
            get
            {
                return "Сортировка глобального массива вставками";
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
            
            for(int i = 1; i < global.Count; i++)
            {
                int currentPos = i;
                while(currentPos >= 1 && global[currentPos - 1] > global[currentPos])
                {
                    (global[currentPos], global[currentPos - 1]) = (global[currentPos - 1], global[currentPos]);
                    currentPos--;
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
            
        }
    }
}
