using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class PlankPlacement
    {
        public enum PlankDirection
        {
            Up,
            Right,
            Down,
            Left
        }

        public PlankDirection PlankDirectionPlace;
        public int Xcoord;
        public int Ycoord;
    }
    class FloorPlank : IFunctions
    {
        static char[][] floorPlan;
        
        public int Number
        {
            get
            {
                return 19;
            }
        }
        public string Name
        {
            get
            {
                return "Паркет (ввод из файла)";
            }
        }
        public GlobalCommand Command()
        {
            ComputeFunc();
            return GlobalCommand.Continue;

        }
        static private void ComputeFunc()
        {
            //Открытие потока
            StreamReader stream = new StreamReader(Program.FilePath);
            string[] lines = stream.ReadToEnd().Split('\n');
            List<char[]> floor = new List<char[]>();

            //Разбор файла и заполнение массива
            int height, width;
            height = lines.Count();
            width = lines[0].Count();
            foreach (string line in lines)
            {
                floor.Add(line.ToCharArray().Where(x=>x!='\r').ToArray());
            }
            floorPlan = floor.ToArray();

            //Метод "Шахматной доски"
            bool white = false;
            for (int i = 0; i < floorPlan.Count(); i++)
            {
                if (floorPlan[0].Count() % 2 == 0)
                {
                    white = !white;
                }

                for (int j = 0; j < floorPlan[i].Count(); j++)
                {
                    if (white)
                    {
                        
                    }
                    white = !white;
                }
                Console.Write("\n");
            }
        }
    }
}
