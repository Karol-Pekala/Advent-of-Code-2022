using System.IO;
using System.Collections.Generic;

// Problem: https://adventofcode.com/2022/day/8

namespace Advent2022
{
    static class Day08
    {
        static List<string> input;
        static int visibleTrees;
        static int highestScenicScore;
        static int rows, columns;
        static byte[,] map;

        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/08.txt");
            input = new List<string>(inputFile);
            rows = input.Count;
            columns = input[0].Length;
            map = new byte[rows, columns];
            GetMap();
        }

        static void GetMap()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    map[i, j] = (byte)char.GetNumericValue(input[i][j]);
                }
            }
        }

        static bool CheckVisibility(int row, int column)
        {
            int visibleFromSides = 4;
            if (row == 0 || column == 0 || row == rows - 1 || column == columns - 1)
            {
                return true;
            }
            // WEST Visibility
            for (int i = 0; i < row; ++i)
            {
                if (map[i, column] >= map[row, column])
                {
                    --visibleFromSides;
                    break;
                }
            }
            // EAST Visibility
            for (int i = row + 1; i < rows; ++i)
            {
                if (map[i, column] >= map[row, column])
                {
                    --visibleFromSides;
                    break;
                }
            }
            // NORTH Visibility
            for (int i = 0; i < column; ++i)
            {
                if (map[row, i] >= map[row, column])
                {
                    --visibleFromSides;
                    break;
                }
            }
            // SOUTH Visibility
            for (int i = column + 1; i < columns; ++i)
            {
                if (map[row, i] >= map[row, column])
                {
                    --visibleFromSides;
                    break;
                }
            }
            if (visibleFromSides == 0)
            {
                return false;
            }
            return true;
        }

        static int GetScenicScore(int row, int column)
        {
            if (row == 0 || column == 0 || row == rows - 1 || column == columns - 1)
            {
                return 0;
            }
            int scenicScore = 1;
            int distance = 0;
            // WEST viewing distance
            for (int i = row - 1; i >= 0; --i)
            {
                if (map[i, column] >= map[row, column])
                {
                    ++distance;
                    break;
                }
                ++distance;
            }
            scenicScore *= distance;
            distance = 0;
            // EAST viewing distance
            for (int i = row + 1; i < rows; ++i)
            {
                if (map[i, column] >= map[row, column])
                { 
                    ++distance;
                    break;
                }
                ++distance;
            }
            scenicScore *= distance;
            distance = 0;
            // NORTH viewing distance
            for (int i = column - 1; i >= 0; --i)
            {
                if (map[row, i] >= map[row, column])
                {
                    ++distance;
                    break;
                }
                ++distance;
            }
            scenicScore *= distance;
            distance = 0;
            // SOUTH viewing distance
            for (int i = column + 1; i < columns; ++i)
            {
                if (map[row, i] >= map[row, column])
                {
                    ++distance;
                    break;
                }
                ++distance;
            }
            scenicScore *= distance;
            return scenicScore;
        }

        static void Task1()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    if(CheckVisibility(i,j))
                    {
                        ++visibleTrees;
                    }
                }
            }
            File.WriteAllText("../../Output/08.txt", visibleTrees.ToString());
        }

        static void Task2()
        {
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    int current = GetScenicScore(i, j);
                    if (current > highestScenicScore)
                    {
                        highestScenicScore = current;
                    }
                }
            }
            File.WriteAllText("../../Output/08.txt", highestScenicScore.ToString());
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }

}
