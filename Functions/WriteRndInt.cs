using System;
using System.IO;
using System.Threading;

namespace Lab1.Functions
{
    class WriteRndInt : IFunctions
    {
        public int Number
        {
            get
            {
                return 1;
            }
        }
        public string Name{
            get
            {
                return "Запись в файл N случайных чисел";
            }
        }
        public GlobalCommand Command()
        {
            WriteRndIntFunc();
            return GlobalCommand.Continue;
        }
        static private void WriteRndIntFunc()
        {
            Console.Write("\n\nВведите количество случайных чисел для записи в файл: ");
            int count = Console.ReadLine().ConvertStringToInt();

            Random random = new Random();
            StreamWriter streamWriter = new StreamWriter(Program.FilePath);
            for (int i = 0; i < count - 1; i++)
            {
                streamWriter.Write($"{random.Next()} ");
            }
            streamWriter.Write(random.Next());

            streamWriter.Flush();
            streamWriter.Close();
            streamWriter.Dispose();
            Utilities.WriteMessage("\nОперация завершена", MessageType.Success);
            Thread.Sleep(2000);
        }
    }
}
