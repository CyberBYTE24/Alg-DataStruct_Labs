using System.Diagnostics;
using System.Collections.Generic;

namespace Lab1.Functions
{
    class GnomeSort : IFunctions
    {
        public int Number
        {
            get
            {
                return 14;
            }
        }
        public string Name
        {
            get
            {
                return "Сортировка глобального массива GNOME";
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
                if(i >= 1 && global[i - 1] > global[i])
                {
                    (global[i], global[i - 1]) = (global[i - 1], global[i]);
                    i-=2;
                }
            }

            sw.Stop();
            return sw.ElapsedMilliseconds;
            
        }
    }
}
