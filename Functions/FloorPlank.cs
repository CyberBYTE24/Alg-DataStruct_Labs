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
        public char Symbol;
        public enum PlankDirection
        {
            Up,
            Right,
            Down,
            Left
        }
        public PlankPlacement(int Ycoord, int Xcoord, char symbol)
        {
            this.Xcoord = Xcoord;
            this.Ycoord = Ycoord;
            this.Symbol = symbol;
        }

        public int Xcoord;
        public int Ycoord;
    }
    class FloorPlank : IFunctions
    {
        static int variantCount = 1;
        static char[][] floorPlan;
        static List<PlankPlacement> variables = new List<PlankPlacement>();
        
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
            char symbol = 'a';
            for (int y = 0; y < floorPlan.Count(); y++)
            {
                if (floorPlan[y].Count() % 2 == 0)
                {
                    white = !white;
                }

                for (int x = 0; x < floorPlan[y].Count(); x++)
                {
                    if (white && floorPlan[y][x]=='-')
                    {
                        variables.Add(new PlankPlacement(y, x, symbol++));
                    }
                    white = !white;
                }
                Console.Write("\n");
            }
            RecursiveEnumeration(floorPlan, 0);
            variables.Clear();
        }
        static private bool DoPlacePlank(char[][] floor, PlankPlacement plank, PlankPlacement.PlankDirection direction)
        {
            if (floor[plank.Ycoord][plank.Xcoord] == '-')
            {
                switch (direction)
                {
                    case PlankPlacement.PlankDirection.Up:
                        if (plank.Ycoord - 1 < 0)
                            return false;
                        if (floor[plank.Ycoord - 1][plank.Xcoord] == '-')
                        {
                            floor[plank.Ycoord][plank.Xcoord] = plank.Symbol;
                            floor[plank.Ycoord - 1][plank.Xcoord] = plank.Symbol;
                            return true;
                        }
                        return false;
                    case PlankPlacement.PlankDirection.Right:
                        if (plank.Xcoord + 1 > floor[plank.Ycoord].Length - 1)
                            return false;
                        if (floor[plank.Ycoord][plank.Xcoord + 1] == '-')
                        {
                            floor[plank.Ycoord][plank.Xcoord] = plank.Symbol;
                            floor[plank.Ycoord][plank.Xcoord + 1] = plank.Symbol;
                            return true;
                        }
                        return false;
                    case PlankPlacement.PlankDirection.Down:
                        if (plank.Ycoord + 1 > floor.Length - 1)
                            return false;
                        if (floor[plank.Ycoord + 1][plank.Xcoord] == '-')
                        {
                            floor[plank.Ycoord][plank.Xcoord] = plank.Symbol;
                            floor[plank.Ycoord + 1][plank.Xcoord] = plank.Symbol;
                            return true;
                        }
                        return false;
                    case PlankPlacement.PlankDirection.Left:
                        if (plank.Xcoord - 1 < 0)
                            return false;
                        if (floor[plank.Ycoord][plank.Xcoord - 1] == '-')
                        {
                            floor[plank.Ycoord][plank.Xcoord] = plank.Symbol;
                            floor[plank.Ycoord][plank.Xcoord - 1] = plank.Symbol;
                            return true;
                        }
                        return false;
                }
            }
            return false;
        }
        static private void RecursiveEnumeration(char[][] floor, int currentPlankId)
        {
            char[][] currentFloor = new char[floor.Length][];
            
            foreach(PlankPlacement.PlankDirection plankDirection in Enum.GetValues(typeof(PlankPlacement.PlankDirection)))
            {
                for (int i = 0; i < floor.Length; i++)
                {
                    currentFloor[i] = new char[floor[i].Length];
                    floor[i].CopyTo(currentFloor[i], 0);
                }
                if (DoPlacePlank(currentFloor, variables[currentPlankId], plankDirection))
                {
                    if (currentPlankId >= variables.Count - 1)
                    {
                        Console.WriteLine($"Вариант укладки #{variantCount++}:");
                        foreach (char[] line in currentFloor)
                        {
                            Console.WriteLine(line);
                        }
                        Console.WriteLine("Any key - Следующий вариант;\nESC - Выход;\n");
                        if(Console.ReadKey().Key == ConsoleKey.Escape)
                        {
                            throw new Exception("Выход");
                        }
                    }
                    else
                    {
                        RecursiveEnumeration(currentFloor, currentPlankId + 1);
                    }
                }
            }
        }
    }
}
