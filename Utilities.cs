using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Lab1
{
    public enum GlobalCommand
    {
        Continue,
        Exit
    }
    public enum MessageType
    {
        Success,
        Error,
        Warning,
        Default
    }
    static public class Utilities
    {
        #region SpecFunc
        static internal void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Выберите текстовый файл";
            openFileDialog.Filter = "Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            Program.FilePath = openFileDialog.FileName;
        }

        static internal List<int> ReadFileInt(char[] separator = null)
        {
            if (separator == null)
                separator = new char[] { ' ', '\n', '\t' };
            StreamReader streamReader = new StreamReader(Program.FilePath);
            List<int> result = new List<int>();
            foreach (string str in streamReader.ReadToEnd().Split(separator))
            {
                result.Add(str.ConvertStringToInt());
            }
            streamReader.Close();
            streamReader.Dispose();
            return result;
        }

        static public int ConvertStringToInt(this string str)
        {
            int result = 0;
            try
            {
                result = int.Parse(str);
            }
            catch (FormatException ex)
            {
                WriteMessage($"Строка \"{str}\" не была распознана как целочисленный тип.\nИспользовано значение: 0", MessageType.Warning);
            }
            return result;
        }

        static public void WriteMessage(string message, MessageType messageType = MessageType.Default)
        {
            ConsoleColor currenttColor = Console.ForegroundColor;
            switch (messageType)
            {
                case MessageType.Default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = currenttColor;
        }
        #endregion
    }
}
