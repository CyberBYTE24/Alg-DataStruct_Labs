using System;
using System.IO;

namespace Lab1.Functions
{
    class PrintFile : IFunctions
    {
        public int Number
        {
            get
            {
                return 2;
            }
        }
        public string Name{
            get
            {
                return "Распечатать содержимое файла";
            }
        }
        public GlobalCommand Command()
        {
            PrintFileFunc();
            return GlobalCommand.Continue;
        }
        static private void PrintFileFunc()
        {
            StreamReader streamReader = new StreamReader(Program.FilePath);
            Console.Write("\n\nСодержимое файла:\n" + streamReader.ReadToEnd() + "\n\nНажмите любую кнопку, чтобы вернуться в меню");
            streamReader.Close();
            streamReader.Dispose();
            Console.ReadKey();
        }
    }
}
