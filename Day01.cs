using System;
using System.IO;
using System.Collections.Generic;

// Problem: https://adventofcode.com/2022/day/1

namespace Advent2022
{
    static class Day01
    {
        static List<string> input;
        static int highestCalories;
        static int[] highestCaloriesArray;
        static int currentCalories = 0;

        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/01.txt");
            input = new List<string>(inputFile);
            highestCalories = 0;
        }

        static void Task1()
        {
            foreach (var line in input)
            {
                if (line == "")
                {
                    if (currentCalories > highestCalories)
                    {
                        highestCalories = currentCalories;
                    }
                    currentCalories = 0;
                }
                else
                {
                    currentCalories += int.Parse(line);
                }
            }
            File.WriteAllText("../../Output/01.txt", string.Concat(highestCalories));
        }

        static void Task2()
        {
            highestCaloriesArray = new int[3];
            foreach (var line in input)
            {
                if (line == "")
                {
                    if (currentCalories > highestCaloriesArray[0])
                    {
                        highestCaloriesArray[2] = highestCaloriesArray[1];
                        highestCaloriesArray[1] = highestCaloriesArray[0];
                        highestCaloriesArray[0] = currentCalories;
                    }
                    else if (currentCalories > highestCaloriesArray[1])
                    {
                        highestCaloriesArray[2] = highestCaloriesArray[1];
                        highestCaloriesArray[1] = currentCalories;
                    }
                    else if (currentCalories > highestCaloriesArray[2])
                    {
                        highestCaloriesArray[2] = currentCalories;
                    }
                    currentCalories = 0;
                }
                else
                {
                    currentCalories += int.Parse(line);
                }
            }
            highestCalories = highestCaloriesArray[2] + highestCaloriesArray[1] + highestCaloriesArray[0];
            File.WriteAllText("../../Output/01.txt", string.Concat(highestCalories));
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
            
        }
    }
}
