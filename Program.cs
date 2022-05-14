using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;

namespace Lab1
{
    partial class Program
    {
        static internal string FilePath;

        static internal List<int> GlobalIntMassive = new List<int>();
        static private List<IFunctions> Functions = new List<IFunctions>();

        [STAThread]
        static void Main(string[] args)
        {
            if (!Utilities.OpenFile())
            {
                return;
            }
            reset:
            Console.Clear();
            Console.Write($"Выбран файл: {FilePath}\n\nВыберите действие:\n");

            Functions = (from t in Assembly.GetExecutingAssembly().GetTypes()
                         where t.GetInterfaces().Contains(typeof(IFunctions))
                                  && t.GetConstructor(Type.EmptyTypes) != null
                         select Activator.CreateInstance(t) as IFunctions).OrderBy(x=>x.Number).ToList<IFunctions>();

            foreach (var func in Functions)
            {
                Utilities.WriteMessage($"{func.Number}. {func.Name}", MessageType.Default);
            }
            Console.Write("Ввод: ");
            int selectedFunc = Console.ReadLine().ConvertStringToInt();
            try
            {
                if (Functions.Where<IFunctions>(x => x.Number == selectedFunc).First().Command() == GlobalCommand.Continue)
                    goto reset;
            }
            catch (Exception e)
            {
                Utilities.WriteMessage(e.Message, MessageType.Error,Command.WaitingKeyPress);
                goto reset;
            }
            return;
        }
    }
}
