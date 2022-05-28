using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Functions
{
    class ChessHorse : IFunctions
    {
        enum HorseMove
        {
            UpLeft,
            UpRight,
            LeftUp,
            LeftDown,
            DownLeft,
            DownRight,
            RightUp,
            RightDown
        }

        static private int[] MoveCoord(int[]currentCoord, HorseMove direction)
        {
            int[] newCoord = new int[2];
            switch (direction)
            {
                case HorseMove.UpLeft:
                    newCoord[0] = currentCoord[0] - 2;
                    newCoord[1] = currentCoord[1] - 1;
                    return newCoord;
                case HorseMove.UpRight:
                    newCoord[0] = currentCoord[0] - 2;
                    newCoord[1] = currentCoord[1] + 1;
                    return newCoord;
                case HorseMove.LeftUp:
                    newCoord[0] = currentCoord[0] - 1;
                    newCoord[1] = currentCoord[1] - 2;
                    return newCoord;
                case HorseMove.LeftDown:
                    newCoord[0] = currentCoord[0] + 1;
                    newCoord[1] = currentCoord[1] - 2;
                    return newCoord;
                case HorseMove.DownLeft:
                    newCoord[0] = currentCoord[0] + 2;
                    newCoord[1] = currentCoord[1] - 1;
                    return newCoord;
                case HorseMove.DownRight:
                    newCoord[0] = currentCoord[0] + 2;
                    newCoord[1] = currentCoord[1] + 1;
                    return newCoord;
                case HorseMove.RightUp:
                    newCoord[0] = currentCoord[0] - 1;
                    newCoord[1] = currentCoord[1] + 2;
                    return newCoord;
                case HorseMove.RightDown:
                    newCoord[0] = currentCoord[0] + 1;
                    newCoord[1] = currentCoord[1] + 2;
                    return newCoord;
                default:
                    return newCoord;
            }
        }

        static int Count;
        public int Number
        {
            get
            {
                return 18;
            }
        }
        public string Name
        {
            get
            {
                return "Обход шахматной доски фигурой коня";
            }
        }
        public GlobalCommand Command()
        {
            ChessHorseFunc();
            Utilities.WriteMessage("", MessageType.Success, Lab1.Command.WaitingKeyPress);
            return GlobalCommand.Continue;
        }
        static private List<int[][]> ChessHorseFunc()
        {
            List<int[][]> result = new List<int[][]>();
            int[] coord = new int[2];

            Console.Write("\n\nВведите размерность игровой доски N: ");
            Count = Console.ReadLine().ConvertStringToInt();
            Console.Write($"\n\nВведите начальное положение игровой фигуры коня X (1-{Count}): ");
            coord[0] = Console.ReadLine().ConvertStringToInt()-1;
            Console.Write($"\n\nВведите начальное положение игровой фигуры коня Y (1-{Count}): ");
            coord[1] = Console.ReadLine().ConvertStringToInt()-1;

            int[][] field = new int[Count][];
            for(int i = 0; i<Count; i++)
            {
                field[i] = new int[Count];
            }

            Move(coord, 1, field, ref result);

            Console.WriteLine($"Успешных путей обхода: {result.Count}");
            foreach(int[][] res in result)
                PrintField(res);
            return result;
        }

        static private void Move(int[] coord, int moveNum, int[][] field, ref List<int[][]> result)
        {
            if (coord[0]> field.Count()-1 || coord[0]<0)
                return;
            if (coord[1] > field[0].Count() - 1 || coord[1] < 0)
                return;
            if (field[coord[0]][coord[1]] != 0)
                return;

            int[][] resultField = new int[field.Count()][];

            for(int i = 0; i<field.Count();i++)
            {
                resultField[i] = new int[field.Count()];
                field[i].CopyTo(resultField[i], 0);
            }

            resultField[coord[0]][coord[1]] = moveNum;

            if (moveNum >= field.Count() * field[0].Count())
            {
                result.Add(resultField);
                PrintField(resultField);
                return;
            }
            //PrintField(resultField);

            foreach (HorseMove horseMove in Enum.GetValues(typeof(HorseMove))){
                Move(MoveCoord(coord, horseMove), moveNum + 1, resultField, ref result);
            }
        }

        static private void PrintField(int[][] field)
        {
            Console.WriteLine();
            bool white = false;
            ConsoleColor foreground = Console.ForegroundColor;
            ConsoleColor background = Console.BackgroundColor;
            Console.Write("\t");
            for(int i=0; i <field.Count(); i++)
            {
                Console.Write($"   {i+1}\t");
            }
            Console.Write("\n");
            for(int i=0; i<field.Count(); i++)
            {
                if (field.Count() % 2 == 0)
                {
                    white = !white;
                }
                Console.Write($"   {i + 1}\t");
                for (int j = 0; j < field[i].Count(); j++)
                {
                    if (white)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write($"   {field[i][j]}\t");
                    white = !white;
                    Console.ForegroundColor = foreground;
                    Console.BackgroundColor = background;
                }
                Console.Write("\n");
            }
            Console.WriteLine("Any key - Следующий вариант;\nESC - Выход;");
            if(Console.ReadKey().Key== ConsoleKey.Escape)
            {
                throw new Exception("Выход");
            }
        }
    }
}
