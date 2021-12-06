using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day06
    {
        public static void Part1()
        {
            var inputs = File.ReadAllLines("Inputs/day06.txt").ToList();
            var fishes = inputs[0].Split(",").Select(f => new Fish(int.Parse(f))).ToList();
            Dictionary<int, long> library = new Dictionary<int, long>();
            for (int i = 0; i < 9; i++)
            {
                library.Add(i, fishes.Count(f => f.DaysLeft == i));
            }
            for (int i = 0; i < 80; i++)
            {
                var newLib = new Dictionary<int, long>();
                for (int y = 0; y < 8; y++)
                {
                    newLib.Add(y, library[y + 1]);
                }
                newLib[6] += library[0];
                newLib.Add(8, library[0]);
                library = newLib;
            }
            Console.WriteLine(library.Values.Sum(v => v));
        }
        public static void Part2()
        {
            var inputs = File.ReadAllLines("Inputs/day06.txt").ToList();
            var fishes = inputs[0].Split(",").Select(f => new Fish(int.Parse(f))).ToList();
            Dictionary<int, long> library = new Dictionary<int, long>();
            for (int i = 0; i < 9; i++)
            {
                library.Add(i, fishes.Count(f => f.DaysLeft == i));
            }
            for (int i = 0; i < 256; i++)
            {
                var newLib = new Dictionary<int, long>();
                for (int y = 0; y < 8; y++)
                {
                    newLib.Add(y, library[y + 1]);
                }
                newLib[6] += library[0];
                newLib.Add(8, library[0]);
                library = newLib;
            }
            Console.WriteLine(library.Values.Sum(v => v));
        }
        public class Fish
        {
            public Fish(int daysLeft)
            {
                DaysLeft = daysLeft;
            }
            public int DaysLeft { get; set; }
            public override string ToString()
            {
                return DaysLeft.ToString();
            }
        }
    }
}
