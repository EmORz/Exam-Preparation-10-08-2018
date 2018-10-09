using System;
using System.Linq;

namespace Sneaking
{
    class SneakingStart
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            char[][] room = new char[n][];
            int r = 0;
            int col = 0;

            for (int row = 0; row < n; row++)
            {
                room[row] = Console.ReadLine().ToCharArray();
                if (room[row].Contains('S'))
                {
                    r = row;
                    col = Array.IndexOf(room[row], 'S');
                }
            }
            var directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies(room);
                if (room[r].Contains('d') && Array.IndexOf(room[r], 'd') > col)
                {
                    room[r][col] = 'X';
                    Console.WriteLine($"Sam died at {r}, {col}");
                    break;
                }
                else if (room[r].Contains('b') && Array.IndexOf(room[r], 'b') < col)
                {
                    room[r][col] = 'X';
                    Console.WriteLine($"Sam died at {r}, {col}");
                    break;
                }
                MoveSam(room, ref r, ref col, directions[i]);
                if (room[r].Contains('N'))
                {
                    int indexOfDead = Array.IndexOf(room[r], 'N');
                    room[r][indexOfDead] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    break;
                }
            }
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void MoveSam(char[][] room, ref int r, ref int col, char directions)
        {
            room[r][col] = '.';
            switch (directions)
            {
                case 'U':
                    r--;
                    break;
                case 'D':
                    r++;
                    break;
                case 'L':
                    col--;
                    break;
                case 'R':
                    col++;
                    break;
                default:
                    break;
            }
            room[r][col] = 'S';

        }

        private static void MoveEnemies(char[][] room)
        {
            for (int i = 0; i < room.Length; i++)
            {
                var indexB = Array.IndexOf(room[i], 'b');
                var indexD = Array.IndexOf(room[i], 'd');

                if (indexD !=-1)
                {
                    if (indexD ==0)
                    {
                        room[i][indexD] = 'b';
                    }
                    else
                    {
                        room[i][indexD] = '.';
                        indexD--;
                        room[i][indexD] = 'd';
                    }
                }
                else if (indexB != -1)
                {
                    if (indexB == room[i].Length-1)
                    {
                        room[i][indexB] = 'd';
                    }
                    else
                    {
                        room[i][indexB] = '.';
                        indexB++;
                        room[i][indexB] = 'b';
                    }
                }

            }
        }
    }
}
