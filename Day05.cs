using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

// Problem: https://adventofcode.com/2022/day/5

namespace Advent2022
{
    static class Day05
    {
        static List<string> input;
        static Stack[] stacks;
        static int numberOfStacks;
        static int biggestStartingStack;

        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/05.txt");
            input = new List<string>(inputFile);
            biggestStartingStack = 0;
            numberOfStacks = GetNumberOfStacks();
            stacks = new Stack[numberOfStacks];
            for (int i = 0; i < stacks.Length; ++i)
            {
                stacks[i] = new Stack();
            }
            GetStartingStacks();
        }

        static int GetNumberOfStacks()
        {
            foreach (var line in input)
            {
                if (line[1] == '1')
                {
                    var count = line.Split(' ');
                    return count.Length - 1;
                }
                else ++biggestStartingStack;
            }
            return 0;
        }

        static void GetStartingStacks()
        {
            for (int j = biggestStartingStack - 1; j >=0; --j)
            {
                int currentStack = 0;
                for (int i = 1; i < input[j].Length; i = i + 4)
                {
                    if(input[j][i] != ' ' && currentStack < numberOfStacks)
                    {
                        stacks[currentStack].Push(input[j][i]);
                    }
                    ++currentStack;
                }
            }
        }

        static string GetFinalConfig()
        {
            var finalConfig = "";
            foreach (var stack in stacks)
            {
                if(stack.Count > 0)
                {
                    finalConfig += stack.Pop();
                }
            }
            return finalConfig;
        }

        static void Move1(int repetitions, int from, int to)
        {
            while (repetitions > 0)
            {
                if(stacks[from-1].Count > 0)
                {
                    stacks[to-1].Push(stacks[from-1].Pop());
                }
                --repetitions;
            }
        }

        static void Move2(int repetitions, int from, int to)
        {
            Stack temporary = new Stack();
            int repetitions2 = repetitions;
            while (repetitions > 0)
            {
                if (stacks[from - 1].Count > 0)
                {
                    temporary.Push(stacks[from - 1].Pop());
                }
                --repetitions;
            }
            while (repetitions2 > 0)
            {
                if (temporary.Count > 0)
                {
                    stacks[to - 1].Push(temporary.Pop());
                }
                --repetitions2;
            }
        }

        static void Task1()
        {
            foreach (var line in input)
            {
                if (line == "")
                {
                    continue;
                }
                if (line[0] == 'm')
                {
                    var command = line.Split(' ');
                    Move1(Int32.Parse(command[1]), Int32.Parse(command[3]), Int32.Parse(command[5]));
                }
            }
            File.WriteAllText("../../Output/05.txt", GetFinalConfig());
        }

        static void Task2()
        {
            foreach (var line in input)
            {
                if (line == "")
                {
                    continue;
                }
                if (line[0] == 'm')
                {
                    var command = line.Split(' ');
                    Move2(Int32.Parse(command[1]), Int32.Parse(command[3]), Int32.Parse(command[5]));
                }
            }
            File.WriteAllText("../../Output/05.txt", GetFinalConfig());
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }

}
