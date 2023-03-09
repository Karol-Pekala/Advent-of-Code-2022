using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

// Problem: https://adventofcode.com/2022/day/6

namespace Advent2022
{
    static class Day06
    {
        static List<string> input;
        static int position, markerLength;
        static Queue marker;

        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/06.txt");
            input = new List<string>(inputFile);
            position = 0;
            marker = new Queue();
        }

        static bool IsNewPacket()
        {
            char[] packet = new char[markerLength];
            int i = 0;
            foreach (char c in marker)
            {
                packet[i] = c;
                ++i;
            }
            for (i = 0; i < markerLength; ++i)
            {
                for (int j = 0; j < markerLength; ++j)
                {
                    if (i == j) continue;
                    if (packet[i] == packet[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static void Task1()
        {
            markerLength = 4;
            foreach (var letter in input[0])
            {
                ++position;
                marker.Enqueue(letter);
                if(marker.Count == markerLength)
                {
                    if(IsNewPacket())
                    {
                        break;
                    }
                    marker.Dequeue();
                }
            }
            File.WriteAllText("../../Output/06.txt", position.ToString());
        }

        static void Task2()
        {
            markerLength = 14;
            foreach (var letter in input[0])
            {
                ++position;
                marker.Enqueue(letter);
                if (marker.Count == markerLength)
                {
                    if (IsNewPacket())
                    {
                        break;
                    }
                    marker.Dequeue();
                }
            }
            File.WriteAllText("../../Output/06.txt", position.ToString());
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }

}
