using System;
using System.IO;
using System.Threading;

namespace Lab1.Functions
{
    class WriteManualInt : IFunctions
    {
        public int Number
        {
            get
            {
                return 5;
            }
        }
        public string Name
        {
            get
            {
                return "Записать в текстовый файл N целых чисел, используя ручной ввод";
            }
        }
        public GlobalCommand Command()
        {
            WriteManualIntFunc();
            return GlobalCommand.Continue;
        }
        static private void WriteManualIntFunc()
        {
            Console.Write("\n\nВведите количество чисел для записи в файл: ");
            int count = Console.ReadLine().ConvertStringToInt();

            StreamWriter streamWriter = new StreamWriter(Program.FilePath);
            for (int i = 0; i < count - 1; i++)
            {
                Console.Write($"\nВведите {i + 1}-й элемент: ");
                streamWriter.Write($"{Console.ReadLine()} ");
            }
            Console.Write($"\nВведите {count}-й элемент: ");
            streamWriter.Write(Console.ReadLine());

            streamWriter.Flush();
            streamWriter.Close();
            streamWriter.Dispose();
            Utilities.WriteMessage("\nОперация завершена", MessageType.Success);
            Thread.Sleep(2000);
        }
    }
}
