using System;
using System.IO;
using System.Collections.Generic;


// Problem: https://adventofcode.com/2022/day/4

namespace Advent2022
{
    static class Day04
    {
        static List<string> input;
        static int fullyContaining;
        static string[] section1;
        static string[] section2;


        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/04.txt");
            input = new List<string>(inputFile);
            fullyContaining = 0;
            section1 = new string[2];
            section2 = new string[2];
        }

        static void Task1()
        {
            string[] assignments = new string[2];
            foreach (var line in input)
            {
                assignments = line.Split(',');
                section1 = assignments[0].Split('-');
                section2 = assignments[1].Split('-');
                if ((Int32.Parse(section1[0]) >= Int32.Parse(section2[0]) && (Int32.Parse(section1[1]) <= Int32.Parse(section2[1]))) ||
                    (Int32.Parse(section1[0]) <= Int32.Parse(section2[0]) && (Int32.Parse(section1[1]) >= Int32.Parse(section2[1]))))
                {
                    ++fullyContaining;
                }
            }
            File.WriteAllText("../../Output/04.txt", string.Concat(fullyContaining));
        }

        static void Task2()
        {
            string[] assignments = new string[2];
            foreach (var line in input)
            {
                assignments = line.Split(',');
                section1 = assignments[0].Split('-');
                section2 = assignments[1].Split('-');
                if ((Int32.Parse(section1[0]) >= Int32.Parse(section2[0]) && (Int32.Parse(section1[0]) <= Int32.Parse(section2[1]))) ||
                    (Int32.Parse(section1[1]) >= Int32.Parse(section2[0]) && (Int32.Parse(section1[1]) <= Int32.Parse(section2[1]))) ||
                    (Int32.Parse(section2[0]) >= Int32.Parse(section1[0]) && (Int32.Parse(section2[0]) <= Int32.Parse(section1[1]))))
                {
                    ++fullyContaining;
                }
            }
            File.WriteAllText("../../Output/04.txt", string.Concat(fullyContaining));
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }

}
