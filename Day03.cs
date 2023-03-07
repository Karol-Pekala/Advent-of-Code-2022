using System.IO;
using System.Collections.Generic;

// Problem: https://adventofcode.com/2022/day/3

namespace Advent2022
{
    static class Day03
    {
        static List<string> input;
        static int sumOfPriorities;


        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/03.txt");
            input = new List<string>(inputFile);
            sumOfPriorities = 0;
        }

        static int GetPriority(char c)
        {
            if (c < 91)
            {
                return c - 38;
                // Getting priority from ascii values 65-90 to 27-52
            }
            else
            {
                return c - 96;
                // Getting priority from ascii values 97-122 to 1-26
            }
        }

        static void Task1()
        {
            foreach (var line in input)
            {
                for (int i = 0; i < (line.Length/2); ++i)
                {
                    for (int j = (line.Length / 2); j < line.Length; ++j)
                    {
                        if (line[i] == line[j])
                        {
                            sumOfPriorities += GetPriority(line[i]);
                            i = line.Length / 2;
                            break;
                        }
                    }
                }
            }
            File.WriteAllText("../../Output/03.txt", string.Concat(sumOfPriorities));
        }

        static void Task2()
        {
            var counter = 0;
            string[] group = new string[3];
            foreach (var line in input)
            {            
                group[counter] = line;
                counter = (counter + 1) % 3;
                if (counter == 0)
                {
                    foreach (var sign0 in group[0])
                    {
                        foreach (var sign1 in group[1])
                        {
                            if (sign0 == sign1)
                            {
                                foreach (var sign2 in group[2])
                                {
                                    if (sign1 == sign2)
                                    {
                                        sumOfPriorities += GetPriority(sign2);
                                       goto NextGroup;
                                    }
                                }                                
                            }

                        }
                    }
                }
                NextGroup:;
            }
            File.WriteAllText("../../Output/03.txt", string.Concat(sumOfPriorities));
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }
}
