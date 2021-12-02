using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public static class Day01
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Inputs/day01.txt").ToList();
            var increment = 0;
            for (int i = 1; i < lines.Count; i++)
            {
                if (int.Parse(lines[i]) > int.Parse(lines[i - 1])) increment++;
            }
            Console.WriteLine(increment);
        }

        public static void Part2()
        {
            var lines = File.ReadAllLines("Inputs/day01.txt").ToList();
            var increment = 0;
            for (int i = 3; i < lines.Count; i++)
            {
                var previous = int.Parse(lines[i - 3]) + int.Parse(lines[i - 2]) + int.Parse(lines[i - 1]);
                var current = int.Parse(lines[i - 2]) + int.Parse(lines[i - 1]) + int.Parse(lines[i]);
                if (current > previous) increment++;
            }
            Console.WriteLine(increment);
        }
    }
}
