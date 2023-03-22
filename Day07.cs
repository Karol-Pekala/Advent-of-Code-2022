using System.IO;
using System.Collections.Generic;

// Problem: https://adventofcode.com/2022/day/7

namespace Advent2022
{
    static class Day07
    {
        static List<string> input;
        static ulong sumOfTotalSizes;
        static List<ulong> directoriesToRemove;
        static Dictionary<string, ulong> folders;
        static List<string> currentPath;

        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/07.txt");
            input = new List<string>(inputFile);
            sumOfTotalSizes = 0;

            folders = new Dictionary<string, ulong>();
            folders.Add(" /", 0);

            currentPath = new List<string>();
            currentPath.Add("/");

            directoriesToRemove = new List<ulong>();
        }

        static void GetDirectoriesSizes()
        {
            foreach (var line in input)
            {
                var words = line.Split(' ');

                if (words[0] == "$")
                {
                    if (words[1] == "cd")
                    {
                        if (words[2] == "..")
                        {
                            currentPath.RemoveAt(currentPath.Count - 1);
                        }
                        else if (words[2] == "/")
                        {
                            currentPath.Clear();
                            currentPath.Add("/");
                        }
                        else
                        {
                            currentPath.Add(words[2]);
                        }
                    }
                    if (words[1] == "ls")
                    {

                    }
                }
                else
                {
                    if (words[0] == "dir")
                    {
                        string path = "";
                        foreach (var folder in currentPath)
                        {
                            path += " " + folder;
                        }
                        folders.Add(path + " " + words[1], 0);
                    }
                    else
                    {
                        string path = "";
                        foreach (var folder in currentPath)
                        {
                            path += " " + folder;
                            if (folders.ContainsKey(path))
                            {
                                folders[path] += ulong.Parse(words[0]);
                            }
                        }
                    }
                }
            }
        }

        static void Task1()
        {
            foreach (var pair in folders)
            {
                if(pair.Value < 100000)
                {
                    sumOfTotalSizes += pair.Value;
                }
            }
            File.WriteAllText("../../Output/07.txt", sumOfTotalSizes.ToString());
        }

        static void Task2()
        {
            var spaceToRemove = 70000000 - folders[" /"];
            spaceToRemove = 30000000 - spaceToRemove;
            foreach (var pair in folders)
            {
                if (pair.Value >= spaceToRemove)
                {
                    directoriesToRemove.Add(pair.Value);
                }
            }
            directoriesToRemove.Sort();
            File.WriteAllText("../../Output/07.txt", directoriesToRemove[0].ToString());
        }

        static void Main(string[] args)
        {
            Setup();
            GetDirectoriesSizes();
            Task2();
        }
    }

}
