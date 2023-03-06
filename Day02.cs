using System.IO;
using System.Collections.Generic;
using System.Linq;

// Problem: https://adventofcode.com/2022/day/2
// A - Rock, B - Paper, C - Scissors
// X - Rock, Y - Paper, Z - Scissors or
// X - lose, Y - draw,  Z - win
// 1 - Rock, 2 - Paper, 3 - Scissors

namespace Advent2022
{
    static class Day02
    {
        static List<string> input;
        static Dictionary<string, int> shapePoints;
        static Dictionary<string, string> sameShape;
        static Dictionary<string, string> winningShape;
        static Dictionary<string, string> reversedLosingShape;
        static int score;


        static void Setup()
        {
            var inputFile = File.ReadAllLines("../../Input/02.txt");
            input = new List<string>(inputFile);
            shapePoints = new Dictionary<string, int>(){
                {"X", 1}, {"Y", 2}, {"Z", 3} };
            sameShape = new Dictionary<string, string>(){
                {"X", "A"}, {"Y", "B"}, {"Z", "C"} };
            winningShape = new Dictionary<string, string>(){
                {"X", "C"}, {"Y", "A"}, {"Z", "B"} };
            reversedLosingShape = new Dictionary<string, string>(){
                {"B", "X"}, { "C", "Y"}, {"A", "Z"} };
            score = 0;
        }

        static void Task1()
        {
            string[] shapes = new string[2];
            foreach (var line in input)
            {
                shapes = line.Split(' ');
                score += shapePoints[shapes[1]];
                if (shapes[0] == winningShape[shapes[1]])
                {
                    score += 6;
                }
                else if (shapes[0] == sameShape[shapes[1]])
                {
                    score += 3;
                }
            }
            File.WriteAllText("../../Output/02.txt", string.Concat(score));
        }

        static void Task2()
        {
            var reversedSameShape = sameShape.ToDictionary(x => x.Value, x => x.Key);
            var reversedWinningShape = winningShape.ToDictionary(x => x.Value, x => x.Key);
            string[] shapes = new string[2];
            foreach (var line in input)
            {
                shapes = line.Split(' ');
                if (shapes[1] == "Y")
                {
                    shapes[1] = reversedSameShape[shapes[0]];               
                }
                else if (shapes[1] == "Z")
                {
                    shapes[1] = reversedWinningShape[shapes[0]];
                }
                else if (shapes[1] == "X")
                {
                    shapes[1] = reversedLosingShape[shapes[0]];
                }

                score += shapePoints[shapes[1]];
                if (shapes[0] == winningShape[shapes[1]])
                {
                    score += 6;
                }
                else if (shapes[0] == sameShape[shapes[1]])
                {
                    score += 3;
                }
            }
            File.WriteAllText("../../Output/02.txt", string.Concat(score));
        }

        static void Main(string[] args)
        {
            Setup();
            Task2();
        }
    }
}
