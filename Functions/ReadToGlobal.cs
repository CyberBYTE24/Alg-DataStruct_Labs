using System;
using System.Threading;

namespace Lab1.Functions
{
    class ReadToGlobal : IFunctions
    {
        public int Number
        {
            get
            {
                return 6;
            }
        }
        public string Name
        {
            get
            {
                return "Поместить числа из файла в глобальный целочисленный массив";
            }
        }
        public GlobalCommand Command()
        {
            ReadToGlobalFunc();
            return GlobalCommand.Continue;
        }
        static private void ReadToGlobalFunc()
        {
            Program.GlobalIntMassive.Clear();
            Program.GlobalIntMassive = Utilities.ReadFileInt();
            Utilities.WriteMessage("\nОперация завершена", MessageType.Success, Lab1.Command.WaitingTwoSeconds);
        }
    }
}
